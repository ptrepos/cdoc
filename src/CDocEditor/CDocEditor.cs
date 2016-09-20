using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CDocEditor : UserControl, IPgdocEditor
    {
        private CDocTreeNode node;

        public CDocEditor(CDocTreeNode node)
        {
            InitializeComponent();

            this.node = node;

            idBox.Text = this.node.Data.Id;
            nameBox.Text = this.node.Data.Name;
            summaryBox.Text = this.node.Data.Summary;
            descriptionBox.Text = this.node.Data.Description;
        }

        public void RefreshData()
        {
            this.node.Data.Id = idBox.Text;
            this.node.Data.Name = nameBox.Text;
            this.node.Data.Summary = summaryBox.Text;
            this.node.Data.Description = descriptionBox.Text;

            this.node.Text = nameBox.Text;
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
