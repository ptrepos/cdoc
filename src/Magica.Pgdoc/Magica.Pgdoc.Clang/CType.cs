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
    public class CType
    {
        internal CHeaderFile parent;

        public CHeaderFile Parent { get { return parent; } }
        public string Name { get; set; }
        public TypeKind Kind { get; set; }
        public string Summary { get; set; }
        public string Definition { get; set; }
        public List<CTypeField> Fields { get { return fields;  } }
        public string Description { get; set; }

        private List<CTypeField> fields = new List<CTypeField>();

        public CType Copy()
        {
            CType obj = (CType)MemberwiseClone();

            obj.parent = null;
            obj.fields = ListUtil.Clone(obj.fields);

            return obj;
        }
    }
}
