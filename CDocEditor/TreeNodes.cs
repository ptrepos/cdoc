using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public interface IPgTreeNode
    {
        Control CreateEditor();
    }

    public interface IPgdocEditor
    {
        void RefreshData();
    }

    public enum GroupType
    {
        Type,
        Constants,
        Function
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
                    this.Text = MessageResource.Constants;
                    break;
                case GroupType.Function:
                    this.Text = MessageResource.Function;
                    break;
            }
        }
    }

    public class CHeaderTreeNode : TreeNode, IPgTreeNode
    {
        private CHeaderFile data;

        public CHeaderFile Data
        {
            get { return data; }
        }

        public CHeaderTreeNode()
        {
        }

        public CHeaderTreeNode(CHeaderFile data)
                : base(data.Name)
        {
            this.data = data;
        }

        public CHeaderTreeNode(CHeaderFile data, TreeNode[] children)
                : base(data.Name, children)
        {
            this.data = data;
        }

        public Control CreateEditor()
        {
            Control editor = new CHeaderEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CHeaderTreeNode view = (CHeaderTreeNode)base.Clone();

            view.data = (CHeaderFile)data.Clone();

            return view;
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

        public Control CreateEditor()
        {
            Control editor = new CTypeEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CTypeTreeNode view = (CTypeTreeNode)base.Clone();

            view.data = (CType)data.Clone();

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

        public Control CreateEditor()
        {
            CFunctionEditor editor = new CFunctionEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CFunctionTreeNode view = (CFunctionTreeNode)base.Clone();

            view.data = (CFunction)data.Clone();

            return view;
        }
    }

    public class CConstantsTreeNode : TreeNode, IPgTreeNode
    {
        private CConst data;

        public CConst Data
        {
            get { return data; }
        }

        public CConstantsTreeNode()
        {
        }

        public CConstantsTreeNode(CConst data)
                : base(data.Name)
        {
            this.data = data;
        }

        public CConstantsTreeNode(CConst data, TreeNode[] children)
                : base(data.Name, children)
        {
            this.data = data;
        }

        public Control CreateEditor()
        {
            CConstantsEditor editor = new CConstantsEditor(this);

            return editor;
        }

        public override object Clone()
        {
            CConstantsTreeNode view = (CConstantsTreeNode)base.Clone();

            view.data = (CConst)data.Clone();

            return view;
        }
    }
}
