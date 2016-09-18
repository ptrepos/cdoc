using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CDocEditorForm : Form
    {
        private CDocument doc = null;
        private string filename = null;
        private Control currentEditor = null;

        public CDocEditorForm()
        {
            InitializeComponent();

            doc = new CDocument();

            SetData(doc);
        }

        private void PgdocEditorForm_Load(object sender, EventArgs e)
        {
            SetMode();
        }

        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(dialog.FileName);
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                GetData(this.doc);

                this.doc.Save(dialog.FileName);

                this.filename = dialog.FileName;

                SetMode();
            }

        }

        private void fileSaveOverrideMenuItem_Click(object sender, EventArgs e)
        {
            GetData(this.doc);

            doc.Save(this.filename);

            SetMode();
        }

        private void PgdocEditorForm_DragEnter(object sender, DragEventArgs e)
        {
            object obj = e.Data.GetData("FileNameW");
            if (obj == null)
                return;

            string[] fileNames = ((string[])obj);
            foreach (string fileName in fileNames)
            {
                if (fileName.EndsWith(CDocument.FileExtension))
                {
                    e.Effect = DragDropEffects.Copy;
                    break;
                }
            }
        }

        private void PgdocEditorForm_DragDrop(object sender, DragEventArgs e)
        {
            object obj = e.Data.GetData("FileNameW");
            if (obj == null)
                return;

            string[] fileNames = ((string[])obj);
            foreach (string fileName in fileNames)
            {
                if (fileName.EndsWith(CDocument.FileExtension))
                {
                    LoadFile(fileName);
                    break;
                }
            }
        }


        private void addMenuItem_Click(object sender, EventArgs e)
        {
            if (pgTree.SelectedNode is GroupTreeNode)
            {
                GroupTreeNode node = (GroupTreeNode)pgTree.SelectedNode;

                Control control = null;
                switch (node.Type)
                {
                    case GroupType.Type:
                        CTypeTreeNode typeNode = new CTypeTreeNode(new CType());

                        typeNode.Nodes.Add(new GroupTreeNode(GroupType.Constants));
                        typeNode.Nodes.Add(new GroupTreeNode(GroupType.Function));

                        node.Nodes.Add(typeNode);
                        control = typeNode.CreateEditor();
                        break;
                    case GroupType.Constants:
                        CConstantsTreeNode constNode = new CConstantsTreeNode(new CConst());
                        node.Nodes.Add(constNode);
                        control = constNode.CreateEditor();
                        break;
                    case GroupType.Function:
                        CFunctionTreeNode funcNode = new CFunctionTreeNode(new CFunction());
                        node.Nodes.Add(funcNode);
                        control = funcNode.CreateEditor();
                        break;
                }

                ChangeEditor(control);
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (pgTree.SelectedNode.Parent == null)
            {
                pgTree.Nodes.Remove(pgTree.SelectedNode);
            }
            else
            {
                pgTree.SelectedNode.Parent.Nodes.Remove(pgTree.SelectedNode);
            }
            ChangeEditor(null);
        }

        private void headerAddMenuItem_Click(object sender, EventArgs e)
        {
            CHeaderTreeNode headerNode = new CHeaderTreeNode(new CHeaderFile());

            headerNode.Nodes.Add(new GroupTreeNode(GroupType.Type));
            headerNode.Nodes.Add(new GroupTreeNode(GroupType.Constants));
            headerNode.Nodes.Add(new GroupTreeNode(GroupType.Function));

            pgTree.Nodes.Add(headerNode);

            Control control = headerNode.CreateEditor();

            ChangeEditor(control);
        }

        private void treeContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (pgTree.SelectedNode is GroupTreeNode)
            {
                addMenuItem.Enabled = true;
                deleteMenuItem.Enabled = false;
            }
            else
            {
                addMenuItem.Enabled = false;
                deleteMenuItem.Enabled = true;
            }
        }

        private void pgTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (pgTree.SelectedNode is IPgTreeNode)
            {
                IPgTreeNode node = (IPgTreeNode)pgTree.SelectedNode;
                ChangeEditor(node.CreateEditor());
            }
        }

        public void SetData(CDocument data)
        {
            pgTree.Nodes.Clear();

            foreach (CHeaderFile header in data.Headers)
            {
                CHeaderTreeNode headerNode = new CHeaderTreeNode(header);

                GroupTreeNode typeNode = new GroupTreeNode(GroupType.Type);

                foreach (CType i in header.Types)
                {
                    GroupTreeNode constNode2 = new GroupTreeNode(GroupType.Constants);
                    foreach (CConst j in i.Constants)
                    {
                        constNode2.Nodes.Add(new CConstantsTreeNode(j));
                    }

                    GroupTreeNode funcNode2 = new GroupTreeNode(GroupType.Function);
                    foreach (CFunction j in i.Functions)
                    {
                        funcNode2.Nodes.Add(new CFunctionTreeNode(j));
                    }

                    typeNode.Nodes.Add(
                        new CTypeTreeNode(
                            i,
                            new TreeNode[] { constNode2, funcNode2 }));
                }

                GroupTreeNode constNode = new GroupTreeNode(GroupType.Constants);
                foreach (CConst j in header.Constants)
                {
                    constNode.Nodes.Add(new CConstantsTreeNode(j));
                }

                GroupTreeNode funcNode = new GroupTreeNode(GroupType.Function);
                foreach (CFunction j in header.Functions)
                {
                    funcNode.Nodes.Add(new CFunctionTreeNode(j));
                }

                headerNode.Nodes.Add(typeNode);
                headerNode.Nodes.Add(constNode);
                headerNode.Nodes.Add(funcNode);

                pgTree.Nodes.Add(headerNode);
            }

        }

        public void GetData(CDocument data)
        {
            if (currentEditor is IPgdocEditor)
            {
                IPgdocEditor editor = (IPgdocEditor)currentEditor;
                editor.RefreshData();
            }

            data.Headers.Clear();

            foreach (CHeaderTreeNode headerNode in pgTree.Nodes)
            {
                CHeaderFile header = headerNode.Data;

                header.Types.Clear();
                header.Constants.Clear();
                header.Functions.Clear();

                foreach (GroupTreeNode groupNode in headerNode.Nodes)
                {
                    switch (groupNode.Type)
                    {
                        case GroupType.Type:
                            foreach (CTypeTreeNode typeNode in groupNode.Nodes)
                            {
                                CType type = typeNode.Data;
                                type.Functions.Clear();
                                type.Constants.Clear();

                                foreach (GroupTreeNode groupNode2 in typeNode.Nodes)
                                {
                                    switch (groupNode2.Type)
                                    {
                                        case GroupType.Constants:
                                            foreach (CConstantsTreeNode constNode2 in groupNode2.Nodes)
                                            {
                                                type.Constants.Add(constNode2.Data);
                                            }
                                            break;
                                        case GroupType.Function:
                                            foreach (CFunctionTreeNode funcNode2 in groupNode2.Nodes)
                                            {
                                                type.Functions.Add(funcNode2.Data);
                                            }
                                            break;
                                    }
                                }

                                header.Types.Add(type);
                            }
                            break;
                        case GroupType.Constants:
                            foreach (CConstantsTreeNode constNode in groupNode.Nodes)
                            {
                                header.Constants.Add(constNode.Data);
                            }
                            break;
                        case GroupType.Function:
                            foreach (CFunctionTreeNode funcNode in groupNode.Nodes)
                            {
                                header.Functions.Add(funcNode.Data);
                            }
                            break;
                    }
                }

                data.Headers.Add(header);
            }
        }

        private void SetMode()
        {
            if (string.IsNullOrEmpty(filename))
            {
                fileSaveOverrideMenuItem.Enabled = false;
            }
            else
            {
                fileSaveOverrideMenuItem.Enabled = true;
            }
        }

        private void ChangeEditor(Control control)
        {
            if (currentEditor != null)
            {
                if (currentEditor is IPgdocEditor)
                {
                    IPgdocEditor editor = (IPgdocEditor)currentEditor;
                    editor.RefreshData();
                }

                this.splitContainer1.Panel2.Controls.Remove(currentEditor);
                currentEditor.Dispose();
            }

            currentEditor = control;

            if (currentEditor != null)
            {
                control.Dock = DockStyle.Fill;
                this.splitContainer1.Panel2.Controls.Add(currentEditor);
            }
        }

        private void LoadFile(string filename)
        {
            this.filename = filename;
            this.doc = CDocument.Load(filename);

            SetData(this.doc);
            SetMode();
        }

        private TreeNode GetTreeNode(IDataObject obj)
        {
            object o;

            o = obj.GetData(typeof(CTypeTreeNode));
            if (o != null)
                return (TreeNode)o;
            o = obj.GetData(typeof(CFunctionTreeNode));
            if (o != null)
                return (TreeNode)o;
            o = obj.GetData(typeof(CConstantsTreeNode));
            if (o != null)
                return (TreeNode)o;

            return null;
        }

        private void pgTree_DragOver(object sender, DragEventArgs e)
        {
            TreeNode node = GetTreeNode(e.Data);

            if (node != null)
            {
                if ((e.KeyState & 8) != 0)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pgTree_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = GetTreeNode(e.Data);

            if (node != null)
            {
                if (e.Effect == DragDropEffects.Move ||
                    e.Effect == DragDropEffects.Copy)
                {
                    GroupTreeNode parent = (GroupTreeNode)node.Parent;

                    TreeNode target = pgTree.GetNodeAt(pgTree.PointToClient(new Point(e.X, e.Y)));

                    if (target != node)
                    {
                        if (target is GroupTreeNode)
                        {
                            GroupTreeNode groupNode2 = (GroupTreeNode)target;
                            if (groupNode2.Type == parent.Type)
                            {
                                groupNode2.Nodes.Add((TreeNode)node.Clone());
                                return;
                            }
                        }
                        else
                        {
                            GroupTreeNode groupNode2 = (GroupTreeNode)target.Parent;
                            if (groupNode2.Type == parent.Type)
                            {
                                groupNode2.Nodes.Insert(target.Index, (TreeNode)node.Clone());
                                return;
                            }
                        }
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void pgTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            pgTree.SelectedNode = (TreeNode)e.Item;
            pgTree.Focus();

            TreeNode node = (TreeNode)e.Item;

            DragDropEffects effects = pgTree.DoDragDrop(e.Item, DragDropEffects.All);

            if ((effects & DragDropEffects.Move) != 0)
            {
                if (node.Parent == null)
                {
                    pgTree.Nodes.Remove(node);
                }
                else
                {
                    node.Parent.Nodes.Remove(node);
                }
            }
        }
    }
}
