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

        public List<CFunction> Functions { get { return functions; } }
        public List<CConst> Constants { get { return constants; } }

        private List<CTypeField> fields = new List<CTypeField>();
        private List<CFunction> functions = new List<CFunction>();
        private List<CConst> constants = new List<CConst>();

        public object Clone()
        {
            CType def = (CType)MemberwiseClone();

            def.functions = ListUtil.Clone(def.functions);
            def.constants = ListUtil.Clone(def.constants);

            return def;
        }
    }
}
