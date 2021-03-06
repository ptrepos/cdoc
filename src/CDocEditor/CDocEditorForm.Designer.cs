﻿namespace CDocEditor
{
    partial class CDocEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pgTree = new System.Windows.Forms.TreeView();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.headerAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileSaveOverrideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.htmlEncodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.treeContextMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 32);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pgTree);
            this.splitContainer.Size = new System.Drawing.Size(1136, 649);
            this.splitContainer.SplitterDistance = 312;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // pgTree
            // 
            this.pgTree.AllowDrop = true;
            this.pgTree.ContextMenuStrip = this.treeContextMenu;
            this.pgTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgTree.Location = new System.Drawing.Point(0, 0);
            this.pgTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pgTree.Name = "pgTree";
            this.pgTree.Size = new System.Drawing.Size(312, 649);
            this.pgTree.TabIndex = 0;
            this.pgTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.pgTree_ItemDrag);
            this.pgTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pgTree_AfterSelect);
            this.pgTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.pgTree_NodeMouseClick);
            this.pgTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.pgTree_DragDrop);
            this.pgTree.DragOver += new System.Windows.Forms.DragEventHandler(this.pgTree_DragOver);
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.deleteMenuItem,
            this.toolStripSeparator1,
            this.headerAddMenuItem});
            this.treeContextMenu.Name = "treeContextMenu";
            this.treeContextMenu.Size = new System.Drawing.Size(160, 88);
            this.treeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.treeContextMenu_Opening);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(159, 26);
            this.addMenuItem.Text = "追加";
            this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(159, 26);
            this.deleteMenuItem.Text = "削除";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // headerAddMenuItem
            // 
            this.headerAddMenuItem.Name = "headerAddMenuItem";
            this.headerAddMenuItem.Size = new System.Drawing.Size(159, 26);
            this.headerAddMenuItem.Text = "ヘッダを追加";
            this.headerAddMenuItem.Click += new System.EventHandler(this.headerAddMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1136, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenuItem,
            this.toolStripSeparator2,
            this.fileSaveOverrideMenuItem,
            this.fileSaveMenuItem,
            this.toolStripSeparator3,
            this.htmlEncodeMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(79, 24);
            this.fileMenuItem.Text = "ファイル(&F)";
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenuItem.Size = new System.Drawing.Size(234, 26);
            this.fileOpenMenuItem.Text = "ファイルを開く(&O)";
            this.fileOpenMenuItem.Click += new System.EventHandler(this.fileOpenMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // fileSaveOverrideMenuItem
            // 
            this.fileSaveOverrideMenuItem.Name = "fileSaveOverrideMenuItem";
            this.fileSaveOverrideMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileSaveOverrideMenuItem.Size = new System.Drawing.Size(234, 26);
            this.fileSaveOverrideMenuItem.Text = "上書き保存(&S)";
            this.fileSaveOverrideMenuItem.Click += new System.EventHandler(this.fileSaveOverrideMenuItem_Click);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Name = "fileSaveMenuItem";
            this.fileSaveMenuItem.Size = new System.Drawing.Size(234, 26);
            this.fileSaveMenuItem.Text = "名前を付けて保存(&N)";
            this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 686);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1136, 26);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(213, 20);
            // 
            // htmlEncodeMenuItem
            // 
            this.htmlEncodeMenuItem.Name = "htmlEncodeMenuItem";
            this.htmlEncodeMenuItem.Size = new System.Drawing.Size(234, 26);
            this.htmlEncodeMenuItem.Text = "HTMLへ変換する";
            this.htmlEncodeMenuItem.Click += new System.EventHandler(this.htmlEncodeMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(231, 6);
            // 
            // CDocEditorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 712);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CDocEditorForm";
            this.Text = "プログラミングドキュメントエディタ(C言語)";
            this.Load += new System.EventHandler(this.PgdocEditorForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PgdocEditorForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PgdocEditorForm_DragEnter);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.treeContextMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView pgTree;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fileSaveOverrideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem headerAddMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem htmlEncodeMenuItem;
    }
}