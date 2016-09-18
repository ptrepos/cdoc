using System;
using System.Collections.Generic;

namespace Magica.Pgdoc.Clang
{
    public class CFunction : ICloneable
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Definition { get; set; }
        public List<CFunctionParameter> Parameters { get { return parameters; } }
        public string Return { get; set; }
        public string Description { get; set; }

        private List<CFunctionParameter> parameters = new List<CFunctionParameter>();

        public object Clone()
        {
            CFunction def = (CFunction)MemberwiseClone();

            def.parameters = ListUtil.Clone(def.parameters);

            return def;
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
