using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Pgdoc.Clang
{
    public class CHeaderFile : ICloneable
    {
        private List<CType> types = new List<CType>();
        private List<CFunction> functions = new List<CFunction>();
        private List<CConst> consts = new List<CConst>();

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public List<CType> Types
        {
            get { return types; }
        }

        public List<CFunction> Functions
        {
            get { return functions; }
        }

        public List<CConst> Consts
        {
            get { return consts; }
        }

        public object Clone()
        {
            CHeaderFile def = (CHeaderFile)MemberwiseClone();

            def.types = ListUtil.Clone(def.types);
            def.functions = ListUtil.Clone(def.functions);
            def.consts = ListUtil.Clone(def.consts);

            return def;
        }
    }
}
