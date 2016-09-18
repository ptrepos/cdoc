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
        private CHeaderTreeNode node;

        public CHeaderEditor(CHeaderTreeNode node)
        {
            InitializeComponent();

            this.node = node;

            nameBox.Text = this.node.Data.Name;
            summaryBox.Text = this.node.Data.Summary;
            remarksBox.Text = this.node.Data.Description;
        }

        public void RefreshData()
        {
            this.node.Data.Name = nameBox.Text;
            this.node.Data.Summary = summaryBox.Text;
            this.node.Data.Description = remarksBox.Text;

            this.node.Text = this.node.Data.Name;
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
