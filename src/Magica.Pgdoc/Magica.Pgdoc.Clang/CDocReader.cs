using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;

namespace Magica.Pgdoc.Clang
{
    class CDocReader
    {
        public CDocument Read(string file)
        {
            using (StreamReader reader = new StreamReader(file, Encoding.UTF8, true))
            {
                return Read(reader);
            }
        }

        public CDocument Read(TextReader reader)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(reader);

            return Read(doc);
        }

        public CDocument Read(XmlDocument doc)
        {
            XmlNodeList nodes = doc.SelectNodes("c-doc");
            if (nodes.Count != 1)
            {
                throw new ApplicationException("c-doc format is invalid.");
            }

            CDocument cdoc = new CDocument();

            XmlElement cdocElem = (XmlElement)nodes[0];

            cdoc.Name = cdocElem.GetAttribute("name");
            cdoc.Summary = GetString(cdocElem, "summary");
            cdoc.Description = GetString(cdocElem, "description");


            XmlNodeList headerElems = cdocElem.SelectNodes("header-file");
            foreach (XmlElement headerElem in headerElems)
            {
                cdoc.HeaderFiles.Add(ParseHeader(headerElem));
            }

            return cdoc;
        }

        private CHeaderFile ParseHeader(XmlElement headerElem)
        {
            CHeaderFile header = new CHeaderFile();

            header.Name = headerElem.GetAttribute("name");

            header.Summary = GetString(headerElem, "summary");
            header.Description = GetString(headerElem, "description");
            
            XmlNodeList typeElems = headerElem.SelectNodes("type");
            foreach (XmlElement typeElem in typeElems)
            {
                header.Types.Add(ParseType(typeElem));
            }
            XmlNodeList constElems = headerElem.SelectNodes("const");
            foreach (XmlElement constElem in constElems)
            {
                header.Consts.Add(ParseConst(constElem));
            }
            XmlNodeList funcElems = headerElem.SelectNodes("function");
            foreach (XmlElement funcElem in funcElems)
            {
                header.Functions.Add(ParseFunction(funcElem));
            }

            return header;
        }

        private CType ParseType(XmlElement headerElem)
        {
            CType type = new CType();

            type.Name = headerElem.GetAttribute("name");
            type.Kind = Parsekind(headerElem.GetAttribute("kind"));

            type.Summary = GetString(headerElem, "summary");
            type.Definition = GetString(headerElem, "definition");
            XmlNodeList fieldElems = headerElem.SelectNodes("field");
            foreach (XmlElement fieldElem in fieldElems)
            {
                type.Fields.Add(ParseField(fieldElem));
            }
            type.Description = GetString(headerElem, "description");

            return type;
        }

        private CTypeField ParseField(XmlElement fieldElem)
        {
            CTypeField field = new CTypeField();

            field.Name = fieldElem.GetAttribute("name");
            field.Type = fieldElem.GetAttribute("type");

            field.Description = GetString(fieldElem, "description");

            return field;
        }

        private CConst ParseConst(XmlElement constElem)
        {
            CConst constants = new CConst();

            constants.Name = constElem.GetAttribute("name");
            constants.Type = constElem.GetAttribute("type");

            constants.Summary = GetString(constElem, "summary");
            constants.Description = GetString(constElem, "description");

            return constants;
        }

        private CFunction ParseFunction(XmlElement funcElem)
        {
            CFunction function = new CFunction();

            function.Name = funcElem.GetAttribute("name");

            function.Summary = GetString(funcElem, "summary");
            function.Definition = GetString(funcElem, "definition");
            XmlNodeList paramElems = funcElem.SelectNodes("parameter");
            foreach (XmlElement paramElem in paramElems)
            {
                function.Parameters.Add(ParseParameter(paramElem));
            }
            function.Return = GetString(funcElem, "return");
            function.Description = GetString(funcElem, "description");

            return function;
        }

        private CFunctionParameter ParseParameter(XmlElement paramElem)
        {
            CFunctionParameter parameter = new CFunctionParameter();

            parameter.Name = paramElem.GetAttribute("name");
            parameter.IoType = ParseIoType(paramElem.GetAttribute("io"));
            parameter.Description = GetString(paramElem, "description");

            return parameter;
        }

        private string GetString(XmlElement elem, string name)
        {
            XmlNode node = elem.SelectSingleNode(name);
            if (node == null)
                return null;
            return ((XmlCharacterData)node.FirstChild).Data;
        }

        private TypeKind Parsekind(string text)
        {
            if (text == "struct")
            {
                return TypeKind.Struct;
            }
            else if (text == "enum")
            {
                return TypeKind.Enum;
            }
            else if (text == "union")
            {
                return TypeKind.Union;
            }
            else if (text == "typedef")
            {
                return TypeKind.Typedef;
            }

            throw new Exception("invalid type kind [" + text + "]");
        }

        private IoType ParseIoType(string text)
        {
            if (text == "in")
            {
                return IoType.In;
            }
            else if (text == "out")
            {
                return IoType.Out;
            }
            else if (text == "inout")
            {
                return IoType.InOut;
            }
            return IoType.In;
        }
    }
}
