using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CConstantsEditor : UserControl, IPgdocEditor
    {
        private CConstantsTreeNode node;

        public CConstantsEditor(CConstantsTreeNode node)
        {
            InitializeComponent();

            this.node = node;

            nameBox.Text = this.node.Data.Name;
            typeBox.Text = this.node.Data.Type;
            summaryBox.Text = this.node.Data.Summary;
            descriptionBox.Text = this.node.Data.Description;
        }

        public void RefreshData()
        {
            this.node.Data.Name = nameBox.Text;
            this.node.Data.Type = typeBox.Text;
            this.node.Data.Summary = summaryBox.Text;
            this.node.Data.Description = descriptionBox.Text;

            this.node.Text = this.node.Data.Name;
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
