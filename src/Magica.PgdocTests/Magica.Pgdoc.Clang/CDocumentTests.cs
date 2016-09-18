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
<c-doc>
    <header-file name=""header1"">
        <summary>summary1</summary>
        <description>description1</description>
        <type name=""type1"" kind=""struct"">
            <summary>type-summary1</summary>
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
        </type>
        <type name=""type2"" kind=""union"">
            <summary>type-summary2</summary>
            <description>type-description2</description>
        </type>
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

            Assert.AreEqual(doc.Headers[0].Name, "header1");
            Assert.AreEqual(doc.Headers[0].Summary, "summary1");
            Assert.AreEqual(doc.Headers[0].Description, "description1");

            Assert.AreEqual(doc.Headers[0].Types[0].Name, "type1");
            Assert.AreEqual(doc.Headers[0].Types[0].Kind, TypeKind.Struct);
            Assert.AreEqual(doc.Headers[0].Types[0].Summary, "type-summary1");
            Assert.AreEqual(doc.Headers[0].Types[0].Description, "type-description1");

            Assert.AreEqual(doc.Headers[0].Types[0].Fields[0].Name, "field1");
            Assert.AreEqual(doc.Headers[0].Types[0].Fields[0].Type, "type1");
            Assert.AreEqual(doc.Headers[0].Types[0].Fields[0].Description, "aaaaa1");

            Assert.AreEqual(doc.Headers[0].Types[0].Fields[1].Name, "field2");
            Assert.AreEqual(doc.Headers[0].Types[0].Fields[1].Type, "type2");
            Assert.AreEqual(doc.Headers[0].Types[0].Fields[1].Description, "aaaaa2");

            Assert.AreEqual(doc.Headers[0].Types[0].Fields[2].Name, "field3");
            Assert.AreEqual(doc.Headers[0].Types[0].Fields[2].Type, "type3");
            Assert.AreEqual(doc.Headers[0].Types[0].Fields[2].Description, "aaaaa3");

            Assert.AreEqual(doc.Headers[0].Types[0].Constants[0].Name, "constants1");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[0].Type, "int");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[0].Summary, "aaa1");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[0].Description, "bbbbb1");

            Assert.AreEqual(doc.Headers[0].Types[0].Constants[1].Name, "constants2");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[1].Type, "long");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[1].Summary, "aaa2");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[1].Description, "bbbbb2");

            Assert.AreEqual(doc.Headers[0].Types[0].Constants[2].Name, "constants3");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[2].Type, "long long");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[2].Summary, "aaa3");
            Assert.AreEqual(doc.Headers[0].Types[0].Constants[2].Description, "bbbbb3");

            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Name, "func1");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Summary, "func-summary1");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Definition, "func-definition1");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Parameters[0].Name, "param1");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Parameters[0].Description, "param-description1");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Parameters[1].Name, "param2");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Parameters[1].Description, "param-description2");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Return, "func-return1");
            Assert.AreEqual(doc.Headers[0].Types[0].Functions[0].Description, "func-description1");

            Assert.AreEqual(doc.Headers[0].Types[1].Name, "type2");
            Assert.AreEqual(doc.Headers[0].Types[1].Kind, TypeKind.Union);
            Assert.AreEqual(doc.Headers[0].Types[1].Summary, "type-summary2");
            Assert.AreEqual(doc.Headers[0].Types[1].Description, "type-description2");

            Assert.AreEqual(doc.Headers[1].Name, "header2");
            Assert.AreEqual(doc.Headers[1].Summary, "summary2");
            Assert.AreEqual(doc.Headers[1].Description, "description2");

            Assert.AreEqual(doc.Headers[1].Types[0].Name, "type3");
            Assert.AreEqual(doc.Headers[1].Types[0].Kind, TypeKind.Enum);
            Assert.AreEqual(doc.Headers[1].Types[0].Summary, "type-summary3");
            Assert.AreEqual(doc.Headers[1].Types[0].Description, "type-description3");

            Assert.AreEqual(doc.Headers[1].Types[1].Name, "type4");
            Assert.AreEqual(doc.Headers[1].Types[1].Kind, TypeKind.Typedef);
            Assert.AreEqual(doc.Headers[1].Types[1].Summary, "type-summary4");
            Assert.AreEqual(doc.Headers[1].Types[1].Description, "type-description4");

            Assert.AreEqual(doc.Headers[2].Name, "header3");
            Assert.AreEqual(doc.Headers[2].Summary, "summary3");
            Assert.AreEqual(doc.Headers[2].Description, "description3");
        }

        [TestMethod()]
        public void SaveTest()
        {
        }
    }
}