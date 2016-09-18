using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Pgdoc
{
    class ListUtil
    {
        public static List<T> Clone<T>(List<T> list)
        {
            list = new List<T>(list);
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = (T)((ICloneable)list[i]).Clone();
            }
            return list;
        }
    }
}
