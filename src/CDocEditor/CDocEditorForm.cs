using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CDocEditorForm : Form
    {
        private CDocTreeNode cdocNode;

        private string filename = null;
        private Control currentEditor = null;

        public CDocEditorForm()
        {
            InitializeComponent();

            CDocument doc = new CDocument();
            doc.Id = "lib1";
            doc.Name = "library-1";

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
                CDocument doc = GetData();

                doc.Save(dialog.FileName);

                this.filename = dialog.FileName;

                SetMode();
            }

        }

        private void fileSaveOverrideMenuItem_Click(object sender, EventArgs e)
        {
            CDocument doc = GetData();

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
            CHeaderFileTreeNode headerFileNode = new CHeaderFileTreeNode(new CHeaderFile());

            headerFileNode.Nodes.Add(new GroupTreeNode(GroupType.Type));
            headerFileNode.Nodes.Add(new GroupTreeNode(GroupType.Constants));
            headerFileNode.Nodes.Add(new GroupTreeNode(GroupType.Function));

            pgTree.Nodes[0].Nodes.Add(headerFileNode);

            Control control = headerFileNode.CreateEditor();

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
            this.cdocNode = null;

            CDocTreeNode cdocNode = new CDocTreeNode(data);

            foreach (CHeaderFile header in data.HeaderFiles)
            {
                CHeaderFileTreeNode headerNode = new CHeaderFileTreeNode(header);

                GroupTreeNode typeNode = new GroupTreeNode(GroupType.Type);

                foreach (CType i in header.Types)
                {
                    typeNode.Nodes.Add(
                        new CTypeTreeNode(i));
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

                cdocNode.Nodes.Add(headerNode);
            }

            this.cdocNode = cdocNode;

            this.pgTree.Nodes.Add(cdocNode);
        }

        public CDocument GetData()
        {
            if (currentEditor is IPgdocEditor)
            {
                IPgdocEditor editor = (IPgdocEditor)currentEditor;
                editor.RefreshData();
            }

            CDocument data = cdocNode.Data;

            data.HeaderFiles.Clear();

            foreach (CHeaderFileTreeNode headerNode in cdocNode.Nodes)
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

                data.HeaderFiles.Add(header);
            }

            return data;
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

                this.splitContainer.Panel2.Controls.Remove(currentEditor);
                currentEditor.Dispose();
            }

            currentEditor = control;

            if (currentEditor != null)
            {
                control.Dock = DockStyle.Fill;
                this.splitContainer.Panel2.Controls.Add(currentEditor);
            }
        }

        private void LoadFile(string filename)
        {
            this.filename = filename;
            CDocument doc = CDocument.Load(filename);

            SetData(doc);
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
