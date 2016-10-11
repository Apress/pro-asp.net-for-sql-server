using System;
using System.CodeDom;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Compilation;

namespace Chapter08.BuildProviders
{
    /// <summary>
    /// Summary description for SampleBuildProvider
    /// </summary>
    public class XyzBuildProvider : BuildProvider
    {

        public override void GenerateCode(AssemblyBuilder assemblyBuilder)
        {
            assemblyBuilder.AddCodeCompileUnit(this, 
                new CodeSnippetCompileUnit(GetGeneratedCode()));
        }

        private string GetGeneratedCode()
        {
            string className = GetClassName();
            string contents = GetContents();

            StringBuilder code = new StringBuilder();
            code.AppendLine("namespace Chapter08.Website {");
            code.AppendLine("/// <summary>");
            code.AppendLine("/// " + contents);
            code.AppendLine("/// </summary>");
            code.AppendLine("public partial class " + className + " {");
            code.AppendLine("/// <summary>");
            code.AppendLine("/// Returns " + VirtualPath);
            code.AppendLine("/// </summary>");
            code.AppendLine("public static string GetVirtualPath() {");
            code.AppendLine("return \"" + VirtualPath + "\";");
            code.AppendLine("}\n}\n}");

            return code.ToString();
        }

        private string GetClassName()
        {
            int startIndex = VirtualPath.LastIndexOf("/") + 1;
            int length = VirtualPath.IndexOf(".") - startIndex;
            string className = VirtualPath.Substring(startIndex, length);
            return className;
        }

        private string GetContents()
        {
            TextReader reader = OpenReader();
            string contents = reader.ReadToEnd();
            reader.Close();
            return contents;
        }

    }
}
