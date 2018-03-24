namespace GLPM.TechnicalAnalysis.Ui.Cli.Rewriters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class TaFuncInfo
    {
        public TaFuncInfo(CompilationUnitSyntax root)
        {
            var usingCollector = new UsingCollector();
            usingCollector.Visit(root);
            this.UsingDirectives = usingCollector.Usings;

            var methodCollector = new MethodCollector();
            methodCollector.Visit(root);
            this.MethodDeclarations = methodCollector.Methods;
        }

        public List<UsingDirectiveSyntax> UsingDirectives { get; }
        public List<MethodDeclarationSyntax> MethodDeclarations { get; }

        public string FileName
            => this.MethodDeclarations.First().Identifier.ToString();

        public bool HasStartIdx
            => this.MethodDeclarations.First().ParameterList.Parameters.Any(x => x.Identifier.ToString() == "startIdx") ;

        public bool HasEndIdx
            => this.MethodDeclarations.First().ParameterList.Parameters.Any(x => x.Identifier.ToString() == "endIdx");

        public List<ParameterSyntax> GetInParameters(int methodIdx)
        {
            var result = this.MethodDeclarations[methodIdx].ParameterList.Parameters
                .Where(x => x.Identifier.ToString() == "startIdx" ||
                            x.Identifier.ToString() == "endIdx" ||
                            x.Identifier.ToString().StartsWith("in"))
                .ToList();

            return result;
        }

        public List<ParameterSyntax> GetOptInParameters(int methodIdx)
        {
            var result = this.MethodDeclarations[methodIdx].ParameterList.Parameters
                .Where(x => x.Identifier.ToString().StartsWith("optIn"))
                .ToList();

            return result;
        }

        public List<ParameterSyntax> GetOutParameters(int methodIdx)
        {
            var result = this.MethodDeclarations[methodIdx].ParameterList.Parameters
                .Where(x => x.Identifier.ToString().StartsWith("out"))
                .ToList();

            return result;
        }

        public object GetOptInParameterValue(int methodIdx, int parameterIdx)
        {
            throw new NotImplementedException();
        }
    }
}