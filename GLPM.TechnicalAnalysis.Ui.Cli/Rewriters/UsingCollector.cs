namespace GLPM.TechnicalAnalysis.Ui.Cli.Rewriters
{
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    class UsingCollector : CSharpSyntaxWalker
    {
        public readonly List<UsingDirectiveSyntax> Usings = new List<UsingDirectiveSyntax>();

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            if (node.Name.ToString() != "System" &&
                !node.Name.ToString().StartsWith("System."))
            {
                this.Usings.Add(node);
            }
        }
    }

    class MethodCollector : CSharpSyntaxWalker
    {
        public readonly List<MethodDeclarationSyntax> Methods = new List<MethodDeclarationSyntax>();

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (!node.Identifier.ToString().Contains("Lookback"))
            {
                this.Methods.Add(node);
            }
        }
    }
}
