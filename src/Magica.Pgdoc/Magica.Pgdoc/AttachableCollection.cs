using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Magica.Pgdoc
{
    public abstract class AttachableCollection<T> : Collection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            Attach(item);
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            Dettach(this[index]);
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            Dettach(this[index]);
            Attach(item);
            base.SetItem(index, item);
        }

        protected abstract void Attach(T obj);
        protected abstract void Dettach(T obj);
    }
}
