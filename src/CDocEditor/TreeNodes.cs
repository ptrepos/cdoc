using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public interface IPgTreeNode
    {
        IPgdocEditor CreateEditor();
    }

    public interface IPgdocEditor
    {
        Control Control { get; }

        void FocusControl();

        void SetData();
        void GetData();
    }

    public enum GroupType
    {
        Type,
        Constants,
        Function
    }

    public class CDocTreeNode : TreeNode, IPgTreeNode
    {
        private CDocument data;

        public CDocument Data
        {
            get { return data; }
        }

        public CDocTreeNode()
        {
        }

        public CDocTreeNode(CDocument data)
                : base(data.Name)
        {
            this.data = data;
        }

        public CDocTreeNode(CDocument data, TreeNode[] children)
                : base(data.Name, children)
        {
            this.data = data;
        }

        public IPgdocEditor CreateEditor()
        {
            CDocEditor editor = new CDocEditor(this);

            return editor;
        }

        public override object Clone()
        {
            throw new NotSupportedException();
        }
    }

    public class CHeaderFileTreeNode : TreeNode, IPgTreeNode
    {
        private CHeaderFile data;

        public CHeaderFile Data
        {
            get { return data; }
        }

        public CHeaderFileTreeNode()
        {
        }

        public CHeaderFileTreeNode(CHeaderFile data)
                : base(data.Name)
        {
            this.data = data;
        }

        public CHeaderFileTreeNode(CHeaderFile data, TreeNode[] children)
                : base(data.Name, children)
        {
            this.data = data;
        }

        public IPgdocEditor CreateEditor()
        {
            CHeaderEditor editor = new CHeaderEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CHeaderFileTreeNode node = (CHeaderFileTreeNode)base.Clone();

            node.data = this.data.Copy();

            return node;
        }
    }

    public class GroupTreeNode : TreeNode
    {
        public GroupType Type { get; set; }

        public GroupTreeNode()
        {
        }

        public GroupTreeNode(GroupType type)
        {
            this.Type = type;

            switch (type)
            {
                case GroupType.Type:
                    this.Text = MessageResource.Type;
                    break;
                case GroupType.Constants:
                    this.Text = MessageResource.Const;
                    break;
                case GroupType.Function:
                    this.Text = MessageResource.Function;
                    break;
            }
        }

        public override object Clone()
        {
            GroupTreeNode node = (GroupTreeNode)base.Clone();

            node.Type = this.Type;

            return node;
        }
    }

    public class CTypeTreeNode : TreeNode, IPgTreeNode
    {
        private CType data;

        public CType Data
        {
            get { return data; }
        }

        public CTypeTreeNode()
        {
        }

        public CTypeTreeNode(CType data)
                : base(data.Name)
        {
            this.data = data;
        }

        public CTypeTreeNode(CType data, TreeNode[] children)
                : base(data.Name, children)
        {
            this.data = data;
        }

        public IPgdocEditor CreateEditor()
        {
            CTypeEditor editor = new CTypeEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CTypeTreeNode view = (CTypeTreeNode)base.Clone();

            view.data = data.Copy();

            return view;
        }
    }

    public class CFunctionTreeNode : TreeNode, IPgTreeNode
    {
        private CFunction data;

        public CFunction Data
        {
            get { return data; }
        }

        public CFunctionTreeNode()
        {
        }

        public CFunctionTreeNode(CFunction data)
                : base(data.Name)
        {
            this.data = data;
        }

        public CFunctionTreeNode(CFunction data, TreeNode[] children)
                : base(data.Name, children)
        {
            this.data = data;
        }

        public IPgdocEditor CreateEditor()
        {
            CFunctionEditor editor = new CFunctionEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CFunctionTreeNode view = (CFunctionTreeNode)base.Clone();

            view.data = data.Copy();

            return view;
        }
    }

    public class CConstTreeNode : TreeNode, IPgTreeNode
    {
        private CConst data;

        public CConst Data
        {
            get { return data; }
        }

        public CConstTreeNode()
        {
        }

        public CConstTreeNode(CConst data)
                : base(data.Name)
        {
            this.data = data;
        }

        public CConstTreeNode(CConst data, TreeNode[] children)
                : base(data.Name, children)
        {
            this.data = data;
        }

        public IPgdocEditor CreateEditor()
        {
            CConstEditor editor = new CConstEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CConstTreeNode view = (CConstTreeNode)base.Clone();

            view.data = data.Copy();

            return view;
        }
    }
}
