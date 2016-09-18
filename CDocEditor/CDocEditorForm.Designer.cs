namespace CDocEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.treeContextMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pgTree);
            this.splitContainer1.Size = new System.Drawing.Size(852, 521);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            // 
            // pgTree
            // 
            this.pgTree.AllowDrop = true;
            this.pgTree.ContextMenuStrip = this.treeContextMenu;
            this.pgTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgTree.Location = new System.Drawing.Point(0, 0);
            this.pgTree.Name = "pgTree";
            this.pgTree.Size = new System.Drawing.Size(234, 521);
            this.pgTree.TabIndex = 0;
            this.pgTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.pgTree_ItemDrag);
            this.pgTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pgTree_AfterSelect);
            this.pgTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.pgTree_DragDrop);
            this.pgTree.DragOver += new System.Windows.Forms.DragEventHandler(this.pgTree_DragOver);
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.deleteMenuItem,
            this.toolStripSeparator1,
            this.headerAddMenuItem});
            this.treeContextMenu.Name = "treeContextMenu";
            this.treeContextMenu.Size = new System.Drawing.Size(135, 76);
            this.treeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.treeContextMenu_Opening);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(134, 22);
            this.addMenuItem.Text = "追加";
            this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteMenuItem.Text = "削除";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // headerAddMenuItem
            // 
            this.headerAddMenuItem.Name = "headerAddMenuItem";
            this.headerAddMenuItem.Size = new System.Drawing.Size(134, 22);
            this.headerAddMenuItem.Text = "ヘッダを追加";
            this.headerAddMenuItem.Click += new System.EventHandler(this.headerAddMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(852, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenuItem,
            this.toolStripSeparator2,
            this.fileSaveOverrideMenuItem,
            this.fileSaveMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fileMenuItem.Text = "ファイル(&F)";
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fileOpenMenuItem.Text = "ファイルを開く(&O)";
            this.fileOpenMenuItem.Click += new System.EventHandler(this.fileOpenMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // fileSaveOverrideMenuItem
            // 
            this.fileSaveOverrideMenuItem.Name = "fileSaveOverrideMenuItem";
            this.fileSaveOverrideMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileSaveOverrideMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fileSaveOverrideMenuItem.Text = "上書き保存(&S)";
            this.fileSaveOverrideMenuItem.Click += new System.EventHandler(this.fileSaveOverrideMenuItem_Click);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Name = "fileSaveMenuItem";
            this.fileSaveMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fileSaveMenuItem.Text = "名前を付けて保存(&N)";
            this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(152, 571);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(852, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(160, 16);
            // 
            // PgdocEditorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 570);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Name = "PgdocEditorForm";
            this.Text = "プログラミングドキュメントエディタ(C言語)";
            this.Load += new System.EventHandler(this.PgdocEditorForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PgdocEditorForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PgdocEditorForm_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.treeContextMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}