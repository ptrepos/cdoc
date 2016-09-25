using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Pgdoc.Clang
{
    public class CHeaderFile
    {
        internal CDocument parent;

        private CTypeCollection types;
        private CFunctionCollection functions;
        private CConstCollection consts;

        public CHeaderFile()
        {
            types = new CTypeCollection(this);
            functions = new CFunctionCollection(this);
            consts = new CConstCollection(this);
        }

        public CDocument Parent { get { return parent; } }

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public CTypeCollection Types
        {
            get { return this.types; }
        }

        public Collection<CFunction> Functions
        {
            get { return this.functions; }
        }

        public Collection<CConst> Consts
        {
            get { return this.consts; }
        }

        public CHeaderFile Copy()
        {
            CHeaderFile obj = (CHeaderFile)MemberwiseClone();

            obj.parent = null;
            obj.types = new CTypeCollection(obj);
            obj.functions = new CFunctionCollection(obj);
            obj.consts = new CConstCollection(obj);

            return obj;
        }

        public class CTypeCollection : AttachableCollection<CType>
        {
            CHeaderFile headerFile;

            internal CTypeCollection(CHeaderFile headerFile)
            {
                this.headerFile = headerFile;
            }

            protected override void Attach(CType item)
            {
                item.parent = headerFile;
            }

            protected override void Dettach(CType item)
            {
                item.parent = null;
            }
        }

        public class CFunctionCollection : AttachableCollection<CFunction>
        {
            CHeaderFile headerFile;

            internal CFunctionCollection(CHeaderFile headerFile)
            {
                this.headerFile = headerFile;
            }

            protected override void Attach(CFunction item)
            {
                item.parent = headerFile;
            }

            protected override void Dettach(CFunction item)
            {
                item.parent = null;
            }
        }

        public class CConstCollection : AttachableCollection<CConst>
        {
            CHeaderFile headerFile;

            internal CConstCollection(CHeaderFile headerFile)
            {
                this.headerFile = headerFile;
            }

            protected override void Attach(CConst item)
            {
                item.parent = headerFile;
            }

            protected override void Dettach(CConst item)
            {
                item.parent = null;
            }
        }
    }
}
