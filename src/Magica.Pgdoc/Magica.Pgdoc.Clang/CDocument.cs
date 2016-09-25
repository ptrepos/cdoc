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
    public class CDocument
    {
        public const string FileExtension = ".pgdoc";

        private CHeaderFileCollection headerFiles;

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public CDocument()
        {
            this.headerFiles = new CHeaderFileCollection(this);
        }

        public CHeaderFileCollection HeaderFiles
        {
            get { return headerFiles; }
        }

        public CDocument Copy()
        {
            CDocument obj = (CDocument)MemberwiseClone();

            obj.headerFiles = new CHeaderFileCollection(obj);

            return obj;
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
            CDocReader docReader = new CDocReader();
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
            CDocWriter docWriter = new CDocWriter();
            docWriter.Write(writer, this);
        }

        public class CHeaderFileCollection : AttachableCollection<CHeaderFile>
        {
            CDocument doc;

            internal CHeaderFileCollection(CDocument doc)
            {
                this.doc = doc;
            }

            protected override void Attach(CHeaderFile item)
            {
                item.parent = doc;
            }

            protected override void Dettach(CHeaderFile item)
            {
                item.parent = null;
            }
        }
    }
}
