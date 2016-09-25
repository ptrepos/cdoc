using System;
using System.Collections.Generic;

namespace Magica.Pgdoc.Clang
{
    public class CFunction 
    {
        internal CHeaderFile parent;

        public CHeaderFile Parent { get { return parent; } }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Definition { get; set; }
        public List<CFunctionParameter> Parameters { get { return parameters; } }
        public string Return { get; set; }
        public string Description { get; set; }

        private List<CFunctionParameter> parameters = new List<CFunctionParameter>();

        public CFunction Copy()
        {
            CFunction obj = (CFunction)MemberwiseClone();

            obj.parent = null;
            obj.parameters = ListUtil.Clone(obj.parameters);

            return obj;
        }
    }

    public class CFunctionParameter : ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
