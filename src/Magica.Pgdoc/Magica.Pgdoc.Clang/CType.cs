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
    public class CType : ICloneable
    {
        public string Name { get; set; }
        public TypeKind Kind { get; set; }
        public string Summary { get; set; }
        public string Definition { get; set; }
        public List<CTypeField> Fields { get { return fields;  } }
        public string Description { get; set; }

        private List<CTypeField> fields = new List<CTypeField>();

        public object Clone()
        {
            CType def = (CType)MemberwiseClone();

            def.fields = ListUtil.Clone(def.fields);

            return def;
        }
    }
}
