using System;
using System.CodeDom;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Compilation;
using System.Xml;

namespace Chapter08.BuildProviders
{
    public class AbcBuildProvider : BuildProvider
    {
        
        public const string RootPath = "/dataClass";
        public const string FieldsAddPath = "fields/add";
        
        public override void GenerateCode(AssemblyBuilder assemblyBuilder)
        {
            assemblyBuilder.AddCodeCompileUnit(this, GetGeneratedCode());
        }
        
        private CodeCompileUnit GetGeneratedCode()
        {
            CodeCompileUnit code = new CodeCompileUnit();

            CodeNamespace ns = new CodeNamespace(GetNamespace());
            CodeNamespaceImport import = new CodeNamespaceImport("System");
            ns.Imports.Add(import);
            code.Namespaces.Add(ns);

            string className = GetClassName();
            CodeTypeDeclaration generatedClass = 
                new CodeTypeDeclaration(className);
            generatedClass.IsPartial = true;
            ns.Types.Add(generatedClass);

            XmlDocument document = new XmlDocument();
            using (Stream stream = OpenStream()) {
                document.Load(stream);
                XmlNode rootNode = document.SelectSingleNode(RootPath);
                if (rootNode != null) 
                {
                    ProcessFieldNodes(generatedClass, rootNode);
                }
            }

            return code;
        }

        private void ProcessFieldNodes(
            CodeTypeDeclaration generatedClass, XmlNode rootNode)
        {
            XmlNodeList fieldNodes = rootNode.SelectNodes(FieldsAddPath);
            foreach (XmlNode addFieldNode in fieldNodes)
            {
                XmlNode nameNode = addFieldNode.SelectSingleNode("@name");
                XmlNode typeNode = addFieldNode.SelectSingleNode("@type");

                string propertyName = nameNode.Value;
                string fieldName = GetFieldName(propertyName);
                Type fieldType = Type.GetType(typeNode.Value);

                // private field
                CodeMemberField field = new CodeMemberField(fieldType, fieldName);
                generatedClass.Members.Add(field);

                AttachProperty(generatedClass, propertyName, fieldName, fieldType);
            }
        }

        private static void AttachProperty(
            CodeTypeDeclaration generatedClass, 
            string propertyName, 
            string fieldName, 
            Type fieldType)
        {

            // public property
            CodeMemberProperty prop = new CodeMemberProperty();
            prop.Name = propertyName;
            prop.Type = new CodeTypeReference(fieldType);
            prop.Attributes = MemberAttributes.Public;

            CodeFieldReferenceExpression fieldRef;
            fieldRef = new CodeFieldReferenceExpression();
            fieldRef.TargetObject = new CodeThisReferenceExpression();
            fieldRef.FieldName = fieldName;

            // property getter
            CodeMethodReturnStatement ret;
            ret = new CodeMethodReturnStatement(fieldRef);
            prop.GetStatements.Add(ret);

            // property setter
            CodeAssignStatement assign = new CodeAssignStatement();
            assign.Left = fieldRef;
            assign.Right = new CodePropertySetValueReferenceExpression();
            prop.SetStatements.Add(assign);

            generatedClass.Members.Add(prop);
        }

        private string GetNamespace() 
        {
            string ns = ConfigurationManager.AppSettings["AbcNamespace"];
            if (String.IsNullOrEmpty(ns)) 
            {
                ns = "Abc";
            }
            return ns;
        }

        private string GetClassName()
        {
            int startIndex = VirtualPath.LastIndexOf("/") + 1;
            int length = VirtualPath.IndexOf(".") - startIndex;
            string className = VirtualPath.Substring(startIndex, length);
            return className;
        }

        /// <summary>
        /// Converts a property name to field name (Name to _name)
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private string GetFieldName(string propertyName)
        {
            return "_" + 
                propertyName.Substring(0,1).ToLower() + 
                propertyName.Substring(1);
        }

    }
}
