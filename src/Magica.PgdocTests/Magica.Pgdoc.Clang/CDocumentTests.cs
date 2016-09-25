using Microsoft.VisualStudio.TestTools.UnitTesting;
using Magica.Pgdoc.Clang;
using System;
using System.Collections.Generic;
using System.IO;

namespace Magica.Pgdoc.Clang.Tests
{
    [TestClass()]
    public class CDocumentTests
    {
        [TestMethod()]
        public void LoadTest()
        {
            const string TEST_XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<c-doc name=""c-doc-name"">
    <summary>c-doc-summary</summary>
    <description>c-doc-description</description>
    <header-file name=""header1"">
        <summary>summary1</summary>
        <description>description1</description>
        <type name=""type1"" kind=""struct"">
            <summary>type-summary1</summary>
            <definition>type-definition1</definition>
            <description>type-description1</description>
            <field name=""field1"" type=""type1"">
                <description>aaaaa1</description>
            </field>
            <field name=""field2"" type=""type2"">
                <description>aaaaa2</description>
            </field>
            <field name=""field3"" type=""type3"">
                <description>aaaaa3</description>
            </field>
        </type>
        <type name=""type2"" kind=""union"">
            <summary>type-summary2</summary>
            <definition>type-definition2</definition>
            <description>type-description2</description>
        </type>
        <const name=""constants1"" type=""int"">
            <summary>aaa1</summary>
            <description>bbbbb1</description>
        </const>
        <const name=""constants2"" type=""long"">
            <summary>aaa2</summary>
            <description>bbbbb2</description>
        </const>
        <const name=""constants3"" type=""long long"">
            <summary>aaa3</summary>
            <description>bbbbb3</description>
        </const>
        <function name=""func1"">
            <summary>func-summary1</summary>
            <definition>func-definition1</definition>
            <parameter name=""param1"">
                <description>param-description1</description>
            </parameter>
            <parameter name=""param2"">
                <description>param-description2</description>
            </parameter>
            <return>func-return1</return>
            <description>func-description1</description>
        </function>
    </header-file>
    <header-file name=""header2"">
        <summary>summary2</summary>
        <description>description2</description>
        <type name=""type3"" kind=""enum"">
            <summary>type-summary3</summary>
            <description>type-description3</description>
        </type>
        <type name=""type4"" kind=""typedef"">
            <summary>type-summary4</summary>
            <description>type-description4</description>
        </type>
    </header-file>
    <header-file name=""header3"">
        <summary>summary3</summary>
        <description>description3</description>
    </header-file>
</c-doc>";

            CDocument doc = CDocument.Load(new StringReader(TEST_XML));

            Assert.AreEqual(doc.Name, "c-doc-name");
            Assert.AreEqual(doc.Summary, "c-doc-summary");
            Assert.AreEqual(doc.Description, "c-doc-description");

            Assert.AreSame(doc.HeaderFiles[0].Parent, doc);
            Assert.AreEqual(doc.HeaderFiles[0].Name, "header1");
            Assert.AreEqual(doc.HeaderFiles[0].Summary, "summary1");
            Assert.AreEqual(doc.HeaderFiles[0].Description, "description1");

            Assert.AreSame(doc.HeaderFiles[0].Types[0].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Name, "type1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Kind, TypeKind.Struct);
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Summary, "type-summary1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Definition, "type-definition1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Description, "type-description1");

            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[0].Name, "field1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[0].Type, "type1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[0].Description, "aaaaa1");

            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[1].Name, "field2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[1].Type, "type2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[1].Description, "aaaaa2");

            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[2].Name, "field3");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[2].Type, "type3");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[2].Description, "aaaaa3");

            Assert.AreSame(doc.HeaderFiles[0].Types[1].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Name, "type2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Kind, TypeKind.Union);
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Summary, "type-summary2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Definition, "type-definition2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Description, "type-description2");

            Assert.AreSame(doc.HeaderFiles[0].Consts[0].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Name, "constants1");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Type, "int");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Summary, "aaa1");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Description, "bbbbb1");

            Assert.AreSame(doc.HeaderFiles[0].Consts[1].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Name, "constants2");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Type, "long");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Summary, "aaa2");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Description, "bbbbb2");

            Assert.AreSame(doc.HeaderFiles[0].Consts[2].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Name, "constants3");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Type, "long long");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Summary, "aaa3");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Description, "bbbbb3");

            Assert.AreSame(doc.HeaderFiles[0].Functions[0].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Name, "func1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Summary, "func-summary1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Definition, "func-definition1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[0].Name, "param1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[0].Description, "param-description1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[1].Name, "param2");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[1].Description, "param-description2");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Return, "func-return1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Description, "func-description1");

            Assert.AreSame(doc.HeaderFiles[1].Parent, doc);
            Assert.AreEqual(doc.HeaderFiles[1].Name, "header2");
            Assert.AreEqual(doc.HeaderFiles[1].Summary, "summary2");
            Assert.AreEqual(doc.HeaderFiles[1].Description, "description2");

            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Name, "type3");
            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Kind, TypeKind.Enum);
            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Summary, "type-summary3");
            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Description, "type-description3");

            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Name, "type4");
            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Kind, TypeKind.Typedef);
            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Summary, "type-summary4");
            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Description, "type-description4");

            Assert.AreEqual(doc.HeaderFiles[2].Name, "header3");
            Assert.AreEqual(doc.HeaderFiles[2].Summary, "summary3");
            Assert.AreEqual(doc.HeaderFiles[2].Description, "description3");
        }

        [TestMethod()]
        public void SaveTest()
        {
            const string TEST_XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<c-doc name=""c-doc-name"">
    <summary>c-doc-summary</summary>
    <description>c-doc-description</description>
    <header-file name=""header1"">
        <summary>summary1</summary>
        <description>description1</description>
        <type name=""type1"" kind=""struct"">
            <summary>type-summary1</summary>
            <definition>type-definition1</definition>
            <description>type-description1</description>
            <field name=""field1"" type=""type1"">
                <description>aaaaa1</description>
            </field>
            <field name=""field2"" type=""type2"">
                <description>aaaaa2</description>
            </field>
            <field name=""field3"" type=""type3"">
                <description>aaaaa3</description>
            </field>
        </type>
        <type name=""type2"" kind=""union"">
            <summary>type-summary2</summary>
            <definition>type-definition2</definition>
            <description>type-description2</description>
        </type>
        <const name=""constants1"" type=""int"">
            <summary>aaa1</summary>
            <description>bbbbb1</description>
        </const>
        <const name=""constants2"" type=""long"">
            <summary>aaa2</summary>
            <description>bbbbb2</description>
        </const>
        <const name=""constants3"" type=""long long"">
            <summary>aaa3</summary>
            <description>bbbbb3</description>
        </const>
        <function name=""func1"">
            <summary>func-summary1</summary>
            <definition>func-definition1</definition>
            <parameter name=""param1"">
                <description>param-description1</description>
            </parameter>
            <parameter name=""param2"">
                <description>param-description2</description>
            </parameter>
            <return>func-return1</return>
            <description>func-description1</description>
        </function>
    </header-file>
    <header-file name=""header2"">
        <summary>summary2</summary>
        <description>description2</description>
        <type name=""type3"" kind=""enum"">
            <summary>type-summary3</summary>
            <description>type-description3</description>
        </type>
        <type name=""type4"" kind=""typedef"">
            <summary>type-summary4</summary>
            <description>type-description4</description>
        </type>
    </header-file>
    <header-file name=""header3"">
        <summary>summary3</summary>
        <description>description3</description>
    </header-file>
</c-doc>";

            CDocument doc = CDocument.Load(new StringReader(TEST_XML));

            using (StringWriter writer = new StringWriter())
            {
                doc.Save(writer);
                doc = CDocument.Load(new StringReader(writer.ToString()));
            }

            Assert.AreEqual(doc.Name, "c-doc-name");
            Assert.AreEqual(doc.Summary, "c-doc-summary");
            Assert.AreEqual(doc.Description, "c-doc-description");

            Assert.AreSame(doc.HeaderFiles[0].Parent, doc);
            Assert.AreEqual(doc.HeaderFiles[0].Name, "header1");
            Assert.AreEqual(doc.HeaderFiles[0].Summary, "summary1");
            Assert.AreEqual(doc.HeaderFiles[0].Description, "description1");

            Assert.AreSame(doc.HeaderFiles[0].Types[0].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Name, "type1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Kind, TypeKind.Struct);
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Summary, "type-summary1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Definition, "type-definition1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Description, "type-description1");

            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[0].Name, "field1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[0].Type, "type1");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[0].Description, "aaaaa1");

            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[1].Name, "field2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[1].Type, "type2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[1].Description, "aaaaa2");

            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[2].Name, "field3");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[2].Type, "type3");
            Assert.AreEqual(doc.HeaderFiles[0].Types[0].Fields[2].Description, "aaaaa3");

            Assert.AreSame(doc.HeaderFiles[0].Types[1].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Name, "type2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Kind, TypeKind.Union);
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Summary, "type-summary2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Definition, "type-definition2");
            Assert.AreEqual(doc.HeaderFiles[0].Types[1].Description, "type-description2");

            Assert.AreSame(doc.HeaderFiles[0].Consts[0].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Name, "constants1");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Type, "int");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Summary, "aaa1");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[0].Description, "bbbbb1");

            Assert.AreSame(doc.HeaderFiles[0].Consts[1].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Name, "constants2");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Type, "long");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Summary, "aaa2");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[1].Description, "bbbbb2");

            Assert.AreSame(doc.HeaderFiles[0].Consts[2].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Name, "constants3");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Type, "long long");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Summary, "aaa3");
            Assert.AreEqual(doc.HeaderFiles[0].Consts[2].Description, "bbbbb3");

            Assert.AreSame(doc.HeaderFiles[0].Functions[0].Parent, doc.HeaderFiles[0]);
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Name, "func1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Summary, "func-summary1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Definition, "func-definition1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[0].Name, "param1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[0].Description, "param-description1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[1].Name, "param2");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Parameters[1].Description, "param-description2");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Return, "func-return1");
            Assert.AreEqual(doc.HeaderFiles[0].Functions[0].Description, "func-description1");

            Assert.AreSame(doc.HeaderFiles[1].Parent, doc);
            Assert.AreEqual(doc.HeaderFiles[1].Name, "header2");
            Assert.AreEqual(doc.HeaderFiles[1].Summary, "summary2");
            Assert.AreEqual(doc.HeaderFiles[1].Description, "description2");

            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Name, "type3");
            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Kind, TypeKind.Enum);
            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Summary, "type-summary3");
            Assert.AreEqual(doc.HeaderFiles[1].Types[0].Description, "type-description3");

            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Name, "type4");
            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Kind, TypeKind.Typedef);
            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Summary, "type-summary4");
            Assert.AreEqual(doc.HeaderFiles[1].Types[1].Description, "type-description4");

            Assert.AreEqual(doc.HeaderFiles[2].Name, "header3");
            Assert.AreEqual(doc.HeaderFiles[2].Summary, "summary3");
            Assert.AreEqual(doc.HeaderFiles[2].Description, "description3");
        }

        [TestMethod()]
        public void HeaderFileAttachTest()
        {
            CDocument doc = new CDocument();
            CHeaderFile h1 = new CHeaderFile();
            CHeaderFile h2 = new CHeaderFile();

            doc.HeaderFiles.Add(h1);

            Assert.AreSame(h1.Parent, doc);
            Assert.IsNull(h2.Parent);

            doc.HeaderFiles.Add(h2);

            Assert.AreSame(h1.Parent, doc);
            Assert.AreSame(h2.Parent, doc);

            doc.HeaderFiles.RemoveAt(0);

            Assert.IsNull(h1.Parent);
            Assert.AreSame(h2.Parent, doc);
            
            doc.HeaderFiles[0] = h1;

            Assert.AreSame(h1.Parent, doc);
            Assert.IsNull(h2.Parent);

            CDocument doc2 = doc.Copy();
            Assert.AreEqual(doc2.HeaderFiles.Count, 0);

            doc2.HeaderFiles.Add(h2);
            Assert.AreSame(h2.Parent, doc2);
        }

        [TestMethod()]
        public void TypesFileAttachTest()
        {
            CHeaderFile h = new CHeaderFile();
            CType t1 = new CType();
            CType t2 = new CType();

            h.Types.Add(t1);

            Assert.AreSame(t1.Parent, h);
            Assert.IsNull(t2.Parent);

            h.Types.Add(t2);

            Assert.AreSame(t1.Parent, h);
            Assert.AreSame(t2.Parent, h);

            h.Types.RemoveAt(0);

            Assert.IsNull(t1.Parent);
            Assert.AreSame(t2.Parent, h);

            h.Types[0] = t1;

            Assert.AreSame(t1.Parent, h);
            Assert.IsNull(t2.Parent);

            CHeaderFile h2 = h.Copy();
            Assert.AreEqual(h2.Types.Count, 0);

            h2.Types.Add(t2);
            Assert.AreSame(t2.Parent, h2);
        }

        [TestMethod()]
        public void FunctionsFileAttachTest()
        {
            CHeaderFile h = new CHeaderFile();
            CFunction f1 = new CFunction();
            CFunction f2 = new CFunction();

            h.Functions.Add(f1);

            Assert.AreSame(f1.Parent, h);
            Assert.IsNull(f2.Parent);

            h.Functions.Add(f2);

            Assert.AreSame(f1.Parent, h);
            Assert.AreSame(f2.Parent, h);

            h.Functions.RemoveAt(0);

            Assert.IsNull(f1.Parent);
            Assert.AreSame(f2.Parent, h);

            h.Functions[0] = f1;

            Assert.AreSame(f1.Parent, h);
            Assert.IsNull(f2.Parent);

            CHeaderFile h2 = h.Copy();
            Assert.AreEqual(h2.Functions.Count, 0);

            h2.Functions.Add(f2);
            Assert.AreSame(f2.Parent, h2);
        }

        [TestMethod()]
        public void ConstsFileAttachTest()
        {
            CHeaderFile h = new CHeaderFile();
            CConst c1 = new CConst();
            CConst c2 = new CConst();

            h.Consts.Add(c1);

            Assert.AreSame(c1.Parent, h);
            Assert.IsNull(c2.Parent);

            h.Consts.Add(c2);

            Assert.AreSame(c1.Parent, h);
            Assert.AreSame(c2.Parent, h);

            h.Consts.RemoveAt(0);

            Assert.IsNull(c1.Parent);
            Assert.AreSame(c2.Parent, h);

            h.Consts[0] = c1;

            Assert.AreSame(c1.Parent, h);
            Assert.IsNull(c2.Parent);

            CHeaderFile h2 = h.Copy();
            Assert.AreEqual(h2.Consts.Count, 0);

            h2.Consts.Add(c2);
            Assert.AreSame(c2.Parent, h2);
        }
    }
}