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
    public class CConst
    {
        internal CHeaderFile parent;

        public CHeaderFile Parent { get { return parent; } }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public CConst Copy()
        {
            CConst obj = (CConst)MemberwiseClone();

            obj.parent = null;

            return obj;
        }
    }
}
