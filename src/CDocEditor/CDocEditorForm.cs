using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CDocEditorForm : Form
    {
        private CDocTreeNode cdocNode;

        private string filename = null;
        private IPgdocEditor currentEditor = null;

        public CDocEditorForm()
        {
            InitializeComponent();

            FormUtil.AutoTabIndex(this);

            CDocument doc = new CDocument();
            doc.Name = "LIBRARY 1";

            SetData(doc);
        }

        private void PgdocEditorForm_Load(object sender, EventArgs e)
        {
            SetMode();
        }

        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadFile(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }

        }

        private void fileSaveOverrideMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CDocument doc = GetData();

                doc.Save(this.filename);

                SetMode();
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }

        }

        private void htmlEncodeMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                CDocument doc = GetData();

                CDocHtmlGenerator docEncoder = new CDocHtmlGenerator();

                string path = Path.Combine(
                        dialog.SelectedPath, 
                        Path.GetFileNameWithoutExtension(filename));
                docEncoder.Encode(path, doc);
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void PgdocEditorForm_DragEnter(object sender, DragEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void PgdocEditorForm_DragDrop(object sender, DragEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }


        private void addMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pgTree.SelectedNode is GroupTreeNode)
                {
                    GroupTreeNode node = (GroupTreeNode)pgTree.SelectedNode;

                    IPgdocEditor control = null;
                    switch (node.Type)
                    {
                        case GroupType.Type:
                            CTypeTreeNode typeNode = new CTypeTreeNode(new CType());
                            node.Nodes.Add(typeNode);
                            control = typeNode.CreateEditor();
                            break;
                        case GroupType.Constants:
                            CConstTreeNode constNode = new CConstTreeNode(new CConst());
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

                    node.Parent.Expand();
                    node.Expand();
                    pgTree.SelectedNode = node;
                }
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void headerAddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CHeaderFileTreeNode headerFileNode = new CHeaderFileTreeNode(new CHeaderFile());

                headerFileNode.Nodes.Add(new GroupTreeNode(GroupType.Type));
                headerFileNode.Nodes.Add(new GroupTreeNode(GroupType.Constants));
                headerFileNode.Nodes.Add(new GroupTreeNode(GroupType.Function));

                pgTree.Nodes[0].Nodes.Add(headerFileNode);

                IPgdocEditor control = headerFileNode.CreateEditor();

                headerFileNode.Parent.Expand();
                headerFileNode.Expand();
                pgTree.SelectedNode = headerFileNode;

                ChangeEditor(control);
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void treeContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (pgTree.SelectedNode is GroupTreeNode)
                {
                    addMenuItem.Enabled = true;
                    deleteMenuItem.Enabled = false;
                }
                else if (pgTree.SelectedNode is CDocTreeNode)
                {
                    addMenuItem.Enabled = false;
                    deleteMenuItem.Enabled = false;
                }
                else
                {
                    addMenuItem.Enabled = false;
                    deleteMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void pgTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (pgTree.SelectedNode is IPgTreeNode)
                {
                    IPgTreeNode node = (IPgTreeNode)pgTree.SelectedNode;
                    ChangeEditor(node.CreateEditor());
                }
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        private void pgTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node is IPgTreeNode)
                {
                    IPgTreeNode node = (IPgTreeNode)e.Node;
                    ChangeEditor(node.CreateEditor());
                }
            }
            catch (Exception ex)
            {
                FormUtil.ShowException(this, ex);
            }
        }

        public void SetData(CDocument data)
        {
            pgTree.Nodes.Clear();
            this.cdocNode = null;

            ChangeEditor(null);

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
                foreach (CConst j in header.Consts)
                {
                    constNode.Nodes.Add(new CConstTreeNode(j));
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

            this.pgTree.ExpandAll();
        }

        public CDocument GetData()
        {
            if (currentEditor != null)
            {
                currentEditor.GetData();
            }

            CDocument data = cdocNode.Data;

            data.HeaderFiles.Clear();

            foreach (CHeaderFileTreeNode headerNode in cdocNode.Nodes)
            {
                CHeaderFile header = headerNode.Data;

                header.Types.Clear();
                header.Consts.Clear();
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
                            foreach (CConstTreeNode constNode in groupNode.Nodes)
                            {
                                header.Consts.Add(constNode.Data);
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

        private void ChangeEditor(IPgdocEditor control)
        {
            if (currentEditor != null)
            {
                currentEditor.GetData();

                this.splitContainer.Panel2.Controls.Remove(currentEditor.Control);
                currentEditor.Control.Dispose();
            }

            currentEditor = control;

            if (currentEditor != null)
            {
                currentEditor.SetData();

                currentEditor.Control.Dock = DockStyle.Fill;
                this.splitContainer.Panel2.Controls.Add(currentEditor.Control);

                currentEditor.FocusControl();
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

            o = obj.GetData(typeof(CHeaderFileTreeNode));
            if (o != null)
                return (TreeNode)o;
            o = obj.GetData(typeof(CTypeTreeNode));
            if (o != null)
                return (TreeNode)o;
            o = obj.GetData(typeof(CFunctionTreeNode));
            if (o != null)
                return (TreeNode)o;
            o = obj.GetData(typeof(CConstTreeNode));
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
                    if (node is CHeaderFileTreeNode)
                    {
                        // ヘッダノードの場合
                        CDocTreeNode parent = (CDocTreeNode)node.Parent;

                        TreeNode target = pgTree.GetNodeAt(pgTree.PointToClient(new Point(e.X, e.Y)));

                        if (target != node)
                        {
                            if (target is CDocTreeNode)
                            {
                                target.Nodes.Add((TreeNode)node.Clone());
                            }
                            else
                            {
                                if (target.Parent == parent)
                                {
                                    target.Parent.Nodes.Insert(target.Index, (TreeNode)node.Clone());
                                }
                                else
                                {
                                    e.Effect = DragDropEffects.None;
                                }
                            }
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                        }
                    }
                    else
                    {
                        // 型、定数、関数ノードの場合
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
                                }
                                else
                                {
                                    e.Effect = DragDropEffects.None;
                                }
                            }
                            else
                            {
                                GroupTreeNode groupNode2 = (GroupTreeNode)target.Parent;
                                if (groupNode2.Type == parent.Type)
                                {
                                    groupNode2.Nodes.Insert(target.Index, (TreeNode)node.Clone());
                                }
                                else
                                {
                                    e.Effect = DragDropEffects.None;
                                }
                            }
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                        }
                    }
                }
            }
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
