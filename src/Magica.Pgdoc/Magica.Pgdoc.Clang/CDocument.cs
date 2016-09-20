using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Magica.Pgdoc.Clang
{
    public class CDocument : ICloneable
    {
        public const string FileExtension = ".pgdoc";

        private List<CHeaderFile> headerFiles = new List<CHeaderFile>();

        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public List<CHeaderFile> HeaderFiles
        {
            get { return headerFiles; }
        }

        public static CDocument Load(string filename)
        {
            using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
            {
                return Load(reader);
            }
        }

        public static CDocument Load(TextReader reader)
        {
            CDocumentReader docReader = new CDocumentReader();
            return docReader.Read(reader);
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8))
            {
                Save(writer);
            }
        }

        public void Save(TextWriter writer)
        {
            CDocumentWriter docWriter = new CDocumentWriter();
            docWriter.Write(writer, this);
        }

        public object Clone()
        {
            CDocument def = (CDocument)MemberwiseClone();

            def.headerFiles = ListUtil.Clone(def.headerFiles);

            return def;
        }
    }
}
