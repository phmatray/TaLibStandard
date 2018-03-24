namespace GLPM.TechnicalAnalysis.Ui.Cli.Rewriters
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class TaFuncRewriter
    {
        public static void RewriteAll()
        {
            var path = "C:\\Users\\phmatray\\Desktop\\TaLibCore\\GLPM.TaLibStandard\\GLPM.TaLibStandard\\TAFunc\\";
            var filePaths = Directory.GetFiles(path);

            var sb = new StringBuilder();
            foreach (var fp in filePaths)
            {
                var source = File.ReadAllText(fp);
                var skeleton = Rewrite(source);
                sb.Append(skeleton).Append("\n\n\n\n\n\n\n\n\n\n");
            }

            var s = sb.ToString();
        }

        public static string Rewrite(string source)
        {
            var tree = CSharpSyntaxTree.ParseText(source);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            var info = new TaFuncInfo(root);

            var skeleton = 
$@"{WriteHeader(info)}

namespace GLPM.TechnicalAnalysis
{{
    using GLPM.TaLibStandard;

    public partial class TAMath
    {{
        {WriteMethods(info)}
    }}

    {WriteClassResult(info)}
}}";

            return skeleton;
        }

        private static string WriteHeader(TaFuncInfo info)
        {
            var result =
$@"// --------------------------------------------------------------------------------------------------------------------
// <copyright file=""{info.FileName}.cs"" company=""GLPM"">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines {info.FileName}.
// </summary>
// --------------------------------------------------------------------------------------------------------------------";

            return result;
        }

        private static string WriteMethods(TaFuncInfo info)
        {
            var result = info.MethodDeclarations
                .Select((x, i) => WriteMethod(info, i))
                .Aggregate((current, next) => current + "\n\n" + next);

            return result;
        }

        private static string WriteMethod(TaFuncInfo info, int methodIdx)
        {
            var inParameters = info.GetInParameters(methodIdx);
            var optInParameters = info.GetOptInParameters(methodIdx);
            var outParameters = info.GetOutParameters(methodIdx);

            var methodInParameters = inParameters
                .Select(x =>
                    {
                        var type = GetType(x);
                        var identifier = GetLowerIdentifier(x);
                        return $"{type} {identifier}";
                    });

            var methodOptInParameters = optInParameters
                .Select(x =>
                    {
                        var type = GetType(x);
                        var identifier = GetLowerIdentifier(x);
                        return $"{type} {identifier} = /*TODO*/";
                    });

            var methodParameters = methodInParameters
                .Concat(methodOptInParameters)
                .Aggregate((current, next) => current + ",\n            " + next);


            var methodBodyOutInit = outParameters
                .Select(x =>
                    {
                        var type = GetType(x);
                        var identifier = GetLowerIdentifier(x, false);

                        if (info.HasStartIdx && info.HasEndIdx && type.EndsWith("[]"))
                        {
                            var substring = type.Substring(0, type.Length - 1);
                            return $"{type} {identifier} = new {substring}endIdx - startIdx + 1];";
                        }

                        return $"{type} {identifier} = default({type});";
                    })
                .Aggregate((current, next) => current + "\n            " + next);

            var inParams = new List<string>(inParameters.Select(x => GetLowerIdentifier(x)));
            var optInParams = new List<string>(optInParameters.Select(x => GetLowerIdentifier(x)));
            var outParams = new List<string>(outParameters.Select(x => GetLowerIdentifier(x, false)));
            var refOutParams = new List<string>(outParameters.Select(x =>
                {
                    var type = GetType(x);
                    if (type.EndsWith("[]"))
                    {
                        return $"{GetLowerIdentifier(x, false)}";
                    }

                    return $"ref {GetLowerIdentifier(x, false)}";
                }));

            var methodCoreExecuteParams = inParams.Concat(optInParams).Concat(refOutParams)
                .Aggregate((current, next) => current + ", " + next);

            var methodResultParams = outParams
                .Aggregate((current, next) => current + ", " + next);

            var result = 
$@"public static {info.FileName}Result {info.FileName}(
            {methodParameters})
        {{
            {methodBodyOutInit}

            var retCode = Core.{info.FileName}({methodCoreExecuteParams});
            return new {info.FileName}Result(retCode, {methodResultParams});
        }}";

            return result;
        }

        private static string WriteClassResult(TaFuncInfo info)
        {
            var outParameters = info.GetOutParameters(0);

            var ctorParamaters = outParameters
                .Select(x =>
                {
                    var type = GetType(x);
                    var identifier = GetLowerIdentifier(x);
                    return $"{type} {identifier}";
                })
                .Aggregate((current, next) => current + ", " + next);

            var ctorContent = outParameters
                .Select(x =>
                {
                    var upperIdentifier = GetUpperIdentifier(x);
                    var lowerIdentifier = GetLowerIdentifier(x);
                    return $"this.{upperIdentifier} = {lowerIdentifier};";
                })
                .Aggregate((current, next) => current + "\n            " + next);

            var classParameters = outParameters
                .Select(x =>
                {
                    var type = GetType(x);
                    var upperIdentifier = GetUpperIdentifier(x);
                    return $"public {type} {upperIdentifier} {{ get; }}";
                })
                .Aggregate((current, next) => current + "\n\n        " + next);

            var result = 
$@"public class {info.FileName}Result
    {{
        public {info.FileName}Result(Core.RetCode retCode, {ctorParamaters})
        {{
            this.RetCode = retCode;
            {ctorContent}
        }}

        public Core.RetCode RetCode {{ get; }}

        {classParameters}
    }}";

            return result;
        }



        private static string GetType(ParameterSyntax x)
        {
            return x.Type.ToString();
        }

        private static string GetLowerIdentifier(ParameterSyntax x, bool removePrefix = true)
        {
            string identifier = x.Identifier.ToString();

            if (removePrefix)
            {
                identifier = RemoveIdentifierPrefix(x);
            }

            if (identifier.StartsWith("NB"))
            {
                // transform the two first characters into lower case
                identifier = "nb" + identifier.Substring(2);
            }
            else
            {
                // transform the first character into lower case
                identifier = char.ToLowerInvariant(identifier[0]) + identifier.Substring(1);
            }

            return identifier;
        }

        private static string GetUpperIdentifier(ParameterSyntax x, bool removePrefix = true)
        {
            string identifier = x.Identifier.ToString();

            if (removePrefix)
            {
                identifier = RemoveIdentifierPrefix(x);
            }

            return identifier;
        }

        private static string RemoveIdentifierPrefix(ParameterSyntax x)
        {
            string identifier = x.Identifier.ToString();

            // remove the prefix
            if (identifier.StartsWith("in"))
            {
                // get the original name and remove the "in"
                identifier = x.Identifier.ToString().Substring(2);
            }
            else if (identifier.StartsWith("out"))
            {
                // get the original name and remove the "out"
                identifier = x.Identifier.ToString().Substring(3);
            }
            else if (identifier.StartsWith("optIn"))
            {
                // get the original name and remove the "optIn"
                identifier = x.Identifier.ToString().Substring(5);
            }

            return identifier;
        }
    }
}
