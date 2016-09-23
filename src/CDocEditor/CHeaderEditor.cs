using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CHeaderEditor : UserControl, IPgdocEditor
    {
        private CHeaderFileTreeNode node;

        public CHeaderEditor(CHeaderFileTreeNode node)
        {
            InitializeComponent();

            FormUtil.AutoTabIndex(this);

            this.node = node;
        }

        public Control Control { get { return this; } }

        public void FocusControl()
        {
            nameBox.Focus();
        }

        public void SetData()
        {
            nameBox.Text = this.node.Data.Name;
            summaryBox.Text = this.node.Data.Summary;
            remarksBox.Text = this.node.Data.Description;
        }

        public void GetData()
        {
            this.node.Data.Name = nameBox.Text;
            this.node.Data.Summary = summaryBox.Text;
            this.node.Data.Description = remarksBox.Text;

            this.node.Text = this.node.Data.Name;
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
