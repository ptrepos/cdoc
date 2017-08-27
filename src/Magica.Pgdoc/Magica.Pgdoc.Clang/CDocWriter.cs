using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;


namespace Magica.Pgdoc.Clang
{
    class CDocWriter
    {
        public void Write(string filename, CDocument cdoc)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                Write(writer, cdoc);
            }
        }

        public void Write(TextWriter writer, CDocument cdoc)
        {
            XmlDocument doc = new XmlDocument();

            Write(doc, cdoc);

            doc.Save(writer);
        }

        public void Write(XmlDocument xmlDoc, CDocument cdoc)
        {
            XmlElement cdocElem = xmlDoc.CreateElement("c-doc");

            SetAttribute(cdocElem, "name", cdoc.Name);
            SetElement(cdocElem, "summary", cdoc.Summary);
            SetElement(cdocElem, "description", cdoc.Description);

            foreach (CHeaderFile headerFile in cdoc.HeaderFiles)
            {
                cdocElem.AppendChild(ConvertHeader(xmlDoc, headerFile));
            }

            xmlDoc.AppendChild(cdocElem);
        }

        private XmlElement ConvertHeader(XmlDocument xmlDoc, CHeaderFile headerFile)
        {
            XmlElement elem = xmlDoc.CreateElement("header-file");

            elem.SetAttribute("name", headerFile.Name);

            SetElement(elem, "summary", headerFile.Summary);
            SetElement(elem, "description", headerFile.Description);


            foreach (CType type in headerFile.Types)
            {
                elem.AppendChild(ConvertType(xmlDoc, type));
            }

            foreach (CConst constants in headerFile.Consts)
            {
                elem.AppendChild(ConvertConst(xmlDoc, constants));
            }

            foreach (CFunction function in headerFile.Functions)
            {
                elem.AppendChild(ConvertFunction(xmlDoc, function));
            }

            return elem;
        }

        private XmlElement ConvertType(XmlDocument xmlDoc, CType type)
        {
            XmlElement elem = xmlDoc.CreateElement("type");

            SetAttribute(elem, "name", type.Name);
            SetAttribute(elem, "kind", ConvertTypeKind(type.Kind));

            SetElement(elem, "summary", type.Summary);
            SetElement(elem, "definition", type.Definition);
            foreach (CTypeField field in type.Fields)
            {
                elem.AppendChild(ConvertTypeField(xmlDoc, field));
            }
            SetElement(elem, "description", type.Description);

            return elem;
        }

        private XmlElement ConvertTypeField(XmlDocument xmlDoc, CTypeField field)
        {
            XmlElement elem = xmlDoc.CreateElement("field");

            SetAttribute(elem, "name", field.Name);
            SetAttribute(elem, "type", field.Type);

            SetElement(elem, "description", field.Description);

            return elem;
        }

        private XmlElement ConvertConst(XmlDocument xmlDoc, CConst _const)
        {
            XmlElement elem = xmlDoc.CreateElement("const");

            SetAttribute(elem, "name", _const.Name);
            SetAttribute(elem, "type", _const.Type);

            SetElement(elem, "summary", _const.Summary);
            SetElement(elem, "description", _const.Description);

            return elem;
        }

        private XmlElement ConvertFunction(XmlDocument xmlDoc, CFunction function)
        {
            XmlElement elem = xmlDoc.CreateElement("function");

            SetAttribute(elem, "name", function.Name);

            SetElement(elem, "summary", function.Summary);
            SetElement(elem, "definition", function.Definition);
            foreach (CFunctionParameter parameter in function.Parameters)
            {
                elem.AppendChild(ConvertParameter(xmlDoc, parameter));
            }
            SetElement(elem, "return", function.Return);
            SetElement(elem, "description", function.Description);

            return elem;
        }

        private XmlElement ConvertParameter(XmlDocument xmlDoc, CFunctionParameter function)
        {
            XmlElement elem = xmlDoc.CreateElement("parameter");

            SetAttribute(elem, "name", function.Name);
            SetAttribute(elem, "io", ConvertIoType(function.IoType));

            SetElement(elem, "description", function.Description);

            return elem;
        }

        public string ConvertTypeKind(TypeKind kind)
        {
            switch (kind)
            {
                case TypeKind.Struct:
                    return "struct";
                case TypeKind.Enum:
                    return "enum";
                case TypeKind.Union:
                    return "union";
                case TypeKind.Typedef:
                    return "typedef";
            }
            return null;
        }

        public string ConvertIoType(IoType type)
        {
            switch (type)
            {
                case IoType.In:
                    return "in";
                case IoType.Out:
                    return "out";
                case IoType.InOut:
                    return "inout";
            }
            return null;
        }


        private void SetAttribute(XmlElement elem, string name, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;

            elem.SetAttribute(name, value);
        }

        private void SetElement(XmlElement elem, string name, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;

            XmlElement e = elem.OwnerDocument.CreateElement(name);

            e.AppendChild(elem.OwnerDocument.CreateTextNode(value));

            elem.AppendChild(e);
        }
    }
}
