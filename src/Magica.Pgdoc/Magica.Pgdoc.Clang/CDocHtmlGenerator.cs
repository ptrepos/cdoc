﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Mdoc;

namespace Magica.Pgdoc.Clang
{
    public class CDocHtmlGenerator
    {
        private const string CSS_DIR = "style";

        public void Encode(string path, CDocument doc)
        {
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(Path.Combine(path, CSS_DIR));

            string location = Assembly.GetEntryAssembly().Location;
            CopyCss(
                Path.Combine(Path.GetDirectoryName(location), CSS_DIR),
                Path.Combine(path, CSS_DIR));

            using (StreamWriter writer = new StreamWriter(
                        Path.Combine(path, GetPath(doc)), 
                        false, 
                        Encoding.UTF8))
            {
                GeneratePage(writer, Escape(doc.Name), GenerateMenu(doc), GenerateBody(doc));
            }

            foreach (CHeaderFile headerFile in doc.HeaderFiles)
            {
                using (StreamWriter writer = new StreamWriter(
                        Path.Combine(path, GetPath(headerFile)), 
                        false, 
                        Encoding.UTF8))
                {
                    GeneratePage(writer, Escape(doc.Name), GenerateMenu(headerFile), GenerateBody(headerFile));
                }

                foreach (CType type in headerFile.Types)
                {
                    using (StreamWriter writer = new StreamWriter(
                            Path.Combine(path, GetPath(type)), 
                            false, 
                            Encoding.UTF8))
                    {
                        GeneratePage(writer, Escape(doc.Name), GenerateMenu(headerFile), GenerateBody(type));
                    }
                }

                foreach (CConst _const in headerFile.Consts)
                {
                    using (StreamWriter writer = new StreamWriter(
                            Path.Combine(path, GetPath(_const)), 
                            false, 
                            Encoding.UTF8))
                    {
                        GeneratePage(writer, Escape(doc.Name), GenerateMenu(headerFile), GenerateBody(_const));
                    }
                }

                foreach (CFunction func in headerFile.Functions)
                {
                    using (StreamWriter writer = new StreamWriter(
                            Path.Combine(path, GetPath(func)), 
                            false, 
                            Encoding.UTF8))
                    {
                        GeneratePage(writer, Escape(doc.Name), GenerateMenu(headerFile), GenerateBody(func));
                    }
                }
            }
        }

        private void CopyCss(string sourcePath, string destPath)
        {
            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files)
            {
                File.Copy(file, Path.Combine(destPath, Path.GetFileName(file)), true);
            }
        }

        private void GeneratePage(TextWriter writer, string title, string menu, string body)
        {
            writer.WriteLine(@"<!DOC HTML>
<html>
<head>
<title>{0}</title>
<link rel=""stylesheet"" type=""text/css"" href=""style/doc.css""/>
</head>
<body>
<div id=""main"">
    <div id=""menu"">{1}</div>
    <div id=""contents"">{2}</div>
</div>
</body>
</html>", title, menu, body);
        }

        private string GenerateMenu(CDocument doc)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<h2>{0}</h2>", "ドキュメント");
            builder.AppendLine("<ul>");
            builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(doc.Name), GetPath(doc));
            builder.AppendLine("<ul>");
            foreach (CHeaderFile headerFile in doc.HeaderFiles)
            {
                builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(headerFile.Name), GetPath(headerFile));
                builder.Append("</li>");
            }
            builder.AppendLine("</ul>");
            builder.AppendLine("</li></ul>");

            return builder.ToString();
        }

        private string GenerateMenu(CHeaderFile headerFile)
        {
            CDocument doc = headerFile.Parent;

            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<h2>{0}</h2>", "ドキュメント");
            builder.AppendLine("<ul>");
            builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(doc.Name), GetPath(doc));
            builder.AppendLine("<ul>");
            foreach (CHeaderFile headerFile2 in doc.HeaderFiles)
            {
                if (headerFile2 != headerFile)
                {
                    builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(headerFile2.Name), GetPath(headerFile2));
                }
                else
                {
                    builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(headerFile2.Name), GetPath(headerFile2));
                    builder.AppendLine("<ul>");
                    if (headerFile2.Types.Count > 0)
                    {
                        builder.AppendLine("<li>型</li>");
                        builder.AppendLine("<ul>");
                        foreach (CType type in headerFile2.Types)
                        {
                            builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(type.Name), GetPath(type));
                        }
                        builder.AppendLine("</ul>");
                    }
                    if (headerFile2.Consts.Count > 0)
                    {
                        builder.AppendLine("<li>定数</li>");
                        builder.AppendLine("<ul>");
                        foreach (CConst _const in headerFile2.Consts)
                        {
                            builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(_const.Name), GetPath(_const));
                        }
                        builder.AppendLine("</ul>");
                    }
                    if (headerFile2.Functions.Count > 0)
                    {
                        builder.AppendLine("<li>関数</li>");
                        builder.AppendLine("<ul>");
                        foreach (CFunction function in headerFile2.Functions)
                        {
                            builder.AppendFormat("<li><a href=\"{1}\">{0}</a>", Escape(function.Name), GetPath(function));
                        }
                        builder.AppendLine("</ul>");
                    }
                    builder.AppendLine("</ul>");
                    builder.Append("</li>");
                }
            }
            builder.AppendLine("</ul>");
            builder.AppendLine("</li></ul>");
            return builder.ToString();
        }

        private string GenerateBody(CDocument doc)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<h1>{0}</h1>", Escape(doc.Name));
            if (!string.IsNullOrEmpty(doc.Summary))
            {
                builder.AppendFormat("<h2>{0}</h2>", "概要");
                builder.AppendLine(EncodeMdoc(doc.Summary));
            }
            if (!string.IsNullOrEmpty(doc.Description))
            {
                builder.AppendFormat("<h2>{0}</h2>", "説明");
                builder.AppendLine(EncodeMdoc(doc.Description));
            }

            builder.AppendFormat("<h2>{0}</h2>", "ヘッダ");
            builder.AppendLine("<table>");
            builder.AppendLine("<thead>");
            builder.AppendLine("<tr>");
            builder.AppendFormat("<th>{0}</th>", "ヘッダ名");
            builder.AppendFormat("<th>{0}</th>", "概要");
            builder.AppendLine("</tr>");
            builder.AppendLine("</thead>");
            builder.AppendLine("<tbody>");
            foreach (CHeaderFile i in doc.HeaderFiles)
            {
                builder.AppendLine("<tr>");
                builder.AppendFormat("<td class=\"name\"><a href=\"{1}\">{0}</a></td>", Escape(i.Name), GetPath(i));
                builder.AppendLine("<td class=\"summary\">");
                builder.AppendLine(EncodeMdoc(i.Summary));
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
            }
            builder.AppendLine("</tbody>");
            builder.AppendLine("</table>");

            return builder.ToString();
        }

        private string GenerateBody(CHeaderFile headerFile)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<h1>{0}</h1>", Escape(headerFile.Name));
            if (!string.IsNullOrEmpty(headerFile.Summary))
            {
                builder.AppendFormat("<h2>{0}</h2>", "概要");
                builder.AppendLine(EncodeMdoc(headerFile.Summary));
            }
            if (!string.IsNullOrEmpty(headerFile.Description))
            {
                builder.AppendFormat("<h2>{0}</h2>", "説明");
                builder.AppendLine(EncodeMdoc(headerFile.Description));
            }

            if (headerFile.Types.Count > 0)
            {
                builder.AppendFormat("<h2>{0}</h2>", "型");
                builder.AppendLine("<table>");
                builder.AppendLine("<thead>");
                builder.AppendLine("<tr>");
                builder.AppendFormat("<th>{0}</th>", "型名");
                builder.AppendFormat("<th>{0}</th>", "概要");
                builder.AppendLine("</tr>");
                builder.AppendLine("</thead>");
                builder.AppendLine("<tbody>");
                foreach (CType i in headerFile.Types)
                {
                    builder.AppendLine("<tr>");
                    builder.AppendFormat("<td class=\"name\"><a href=\"{2}\">{0}{1}</a></td>", Escape(i.Name), EncodeTypeKind(i.Kind), GetPath(i));
                    builder.AppendLine("<td class=\"summary\">");
                    builder.AppendLine(EncodeMdoc(i.Summary));
                    builder.AppendLine("</td>");
                    builder.AppendLine("</tr>");
                }
                builder.AppendLine("</tbody>");
                builder.AppendLine("</table>");
            }

            if (headerFile.Consts.Count > 0)
            {
                builder.AppendFormat("<h2>{0}</h2>", "定数");
                builder.AppendLine("<table>");
                builder.AppendLine("<thead>");
                builder.AppendLine("<tr>");
                builder.AppendFormat("<th>{0}</th>", "定数名");
                builder.AppendFormat("<th>{0}</th>", "概要");
                builder.AppendLine("</tr>");
                builder.AppendLine("</thead>");
                builder.AppendLine("<tbody>");
                foreach (CConst i in headerFile.Consts)
                {
                    builder.AppendLine("<tr>");
                    builder.AppendFormat("<td class=\"name\"><a href=\"{1}\">{0}</a></td>", Escape(i.Name), GetPath(i));
                    builder.AppendLine("<td class=\"summary\">");
                    builder.AppendLine(EncodeMdoc(i.Summary));
                    builder.AppendLine("</td>");
                    builder.AppendLine("</tr>");
                }
                builder.AppendLine("</tbody>");
                builder.AppendLine("</table>");
            }


            if (headerFile.Functions.Count > 0)
            {
                builder.AppendFormat("<h2>{0}</h2>", "関数");
                builder.AppendLine("<table>");
                builder.AppendLine("<thead>");
                builder.AppendLine("<tr>");
                builder.AppendFormat("<th>{0}</th>", "関数名");
                builder.AppendFormat("<th>{0}</th>", "概要");
                builder.AppendLine("</tr>");
                builder.AppendLine("</thead>");
                builder.AppendLine("<tbody>");
                foreach (CFunction i in headerFile.Functions)
                {
                    builder.AppendLine("<tr>");
                    builder.AppendFormat("<td class=\"name\"><a href=\"{1}\">{0}</a></td>", Escape(i.Name), GetPath(i));
                    builder.AppendLine("<td class=\"summary\">");
                    builder.AppendLine(EncodeMdoc(i.Summary));
                    builder.AppendLine("</td>");
                    builder.AppendLine("</tr>");
                }
                builder.AppendLine("</tbody>");
                builder.AppendLine("</table>");
            }

            return builder.ToString();
        }

        private string GenerateBody(CType type)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<h1>{0} {1}</h1>", Escape(type.Name), EncodeTypeKind(type.Kind));
            if (!string.IsNullOrEmpty(type.Summary))
            {
                builder.AppendFormat("<h2>{0}</h2>", "概要");
                builder.AppendLine(EncodeMdoc(type.Summary));
            }
            if (!string.IsNullOrEmpty(type.Definition))
            {
                builder.AppendFormat("<h2>{0}</h2>", "定義");
                builder.AppendFormat("<pre class=\"code\"><code>{0}</code></pre>", Escape(type.Definition));
            }
            if (type.Fields.Count > 0)
            {
                builder.AppendFormat("<h2>{0}</h2>", "フィールド");
                builder.AppendLine("<dl>");
                foreach (CTypeField f in type.Fields)
                {
                    builder.AppendFormat("<dt>{0}</dt>", Escape(f.Name));
                    builder.AppendLine("<dd>");
                    builder.AppendLine(EncodeMdoc(f.Description));
                    builder.AppendLine("</dd>");
                }
                builder.AppendLine("</dl>");
            }
            if (!string.IsNullOrEmpty(type.Description))
            {
                builder.AppendFormat("<h2>{0}</h2>", "説明");
                builder.AppendLine(EncodeMdoc(type.Description));
            }

            return builder.ToString();
        }

        private string GenerateBody(CFunction function)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<h1>{0}()</h1>", Escape(function.Name));
            if (!string.IsNullOrEmpty(function.Summary))
            {
                builder.AppendFormat("<h2>{0}</h2>", "概要");
                builder.AppendLine(EncodeMdoc(function.Summary));
            }

            if (!string.IsNullOrEmpty(function.Definition))
            {
                builder.AppendFormat("<h2>{0}</h2>", "定義");
                builder.AppendFormat("<pre class=\"code\"><code>{0}</code></pre>", Escape(function.Definition));
            }
            if (function.Parameters.Count > 0)
            {
                builder.AppendFormat("<h2>{0}</h2>", "引数");
                builder.AppendLine("<dl>");
                foreach (CFunctionParameter p in function.Parameters)
                {
                    if (p.IoType == IoType.In)
                    {
                        builder.AppendFormat("<dt>{0}</dt>", Escape(p.Name));
                    }
                    else
                    {
                        builder.AppendFormat("<dt>[{1}] {0}</dt>", Escape(p.Name), EncodeIoType(p.IoType));
                    }
                    builder.AppendLine("<dd>");
                    builder.AppendLine(EncodeMdoc(p.Description));
                    builder.AppendLine("</dd>");
                }
                builder.AppendLine("</dl>");
            }
            if (!string.IsNullOrEmpty(function.Return))
            {
                builder.AppendFormat("<h2>{0}</h2>", "戻り値");
                builder.AppendLine(EncodeMdoc(function.Return));
            }
            if (!string.IsNullOrEmpty(function.Description))
            {
                builder.AppendFormat("<h2>{0}</h2>", "説明");
                builder.AppendLine(EncodeMdoc(function.Description));
            }

            return builder.ToString();
        }

        private string GenerateBody(CConst _const)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<h1>{0}</h1>", Escape(_const.Name));
            if (!string.IsNullOrEmpty(_const.Summary))
            {
                builder.AppendFormat("<h2>{0}</h2>", "概要");
                builder.AppendLine(EncodeMdoc(_const.Summary));
            }
            if (!string.IsNullOrEmpty(_const.Description))
            {
                builder.AppendFormat("<h2>{0}</h2>", "説明");
                builder.AppendLine(EncodeMdoc(_const.Description));
            }

            return builder.ToString();
        }

        private string GetPath(CDocument obj)
        {
            return "index.html";
        }

        private string GetPath(CHeaderFile obj)
        {
            return "h-" + EscapeUrl(obj.Name) + ".html";
        }

        private string GetPath(CType obj)
        {
            return "t-" + EscapeUrl(obj.Name) + ".html";
        }

        private string GetPath(CConst obj)
        {
            return "c-" + EscapeUrl(obj.Name) + ".html";
        }

        private string GetPath(CFunction obj)
        {
            return "f-" + EscapeUrl(obj.Name) + ".html";
        }

        private string EscapeUrl(string text)
        {
            return text.Replace("/", "-");
        }

        private string EncodeTypeKind(TypeKind kind)
        {
            switch(kind)
            {
                case TypeKind.Struct:
                    return TextResource.Struct;
                case TypeKind.Enum:
                    return TextResource.Enum;
                case TypeKind.Union:
                    return TextResource.Union;
                case TypeKind.Typedef:
                    return "";
            }
            return "";
        }

        private string EncodeIoType(IoType type)
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
            return "";
        }

        private string Escape(string text)
        {
            StringBuilder builder = new StringBuilder(text);
            builder.Replace("&", "&amp;");
            builder.Replace("'", "&quot;");
            builder.Replace("<", "&lt;");
            builder.Replace(">", "&gt;");
            return builder.ToString();
        }

        private string EncodeMdoc(string text)
        {
            if (string.IsNullOrEmpty(text)) { 
                return "";
            }
            StringReader reader = new StringReader(text);
            StringWriter writer = new StringWriter();
            StringWriter messageWriter = new StringWriter();

            HtmlEncodeParameters parameters = new HtmlEncodeParameters();
            parameters.HeaderIncludes = false;

            MdocTool.EncodeHtml(writer, reader, messageWriter, parameters);

            string message = messageWriter.ToString();
            if (message.Length > 0)
                throw new PgdocException(message);
            return writer.ToString();
        }
    }
}
