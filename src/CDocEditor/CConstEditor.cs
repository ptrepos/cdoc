using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CConstEditor : UserControl, IPgdocEditor
    {
        private CConstTreeNode node;

        public CConstEditor(CConstTreeNode node)
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
            typeBox.Text = this.node.Data.Type;
            summaryBox.Text = this.node.Data.Summary;
            descriptionBox.Text = this.node.Data.Description;
        }

        public void GetData()
        {
            this.node.Data.Name = nameBox.Text;
            this.node.Data.Type = typeBox.Text;
            this.node.Data.Summary = summaryBox.Text;
            this.node.Data.Description = descriptionBox.Text;

            this.node.Text = this.node.Data.Name;
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
