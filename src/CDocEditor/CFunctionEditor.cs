using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CFunctionEditor : UserControl, IPgdocEditor
    {
        private CFunctionTreeNode node;

        public CFunctionEditor(CFunctionTreeNode node)
        {
            InitializeComponent();

            FormUtil.AutoTabIndex(this);

            this.node = node;

            InitializeComboBox();
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
            definitionBox.Text = this.node.Data.Definition;
            parameterGrid.DataSource
                = new BindingList<CFunctionParameter>(
                    new List<CFunctionParameter>(this.node.Data.Parameters));
            returnBox.Text = this.node.Data.Return;
            remarksBox.Text = this.node.Data.Description;
        }

        public void GetData()
        {
            this.node.Data.Name = nameBox.Text;
            this.node.Data.Summary = summaryBox.Text;
            this.node.Data.Definition = definitionBox.Text;

            this.node.Data.Parameters.Clear();
            foreach (CFunctionParameter parameter in (BindingList<CFunctionParameter>)parameterGrid.DataSource)
            {
                if (!IsParameterEmpty(parameter))
                {
                    this.node.Data.Parameters.Add(parameter);
                }
            }
            this.node.Data.Return = returnBox.Text;
            this.node.Data.Description = remarksBox.Text;

            this.node.Text = this.node.Data.Name;
        }

        private void InitializeComboBox()
        {
            List<IoTypeItem> dataSource = new List<IoTypeItem>();
            dataSource.Add(new IoTypeItem(MessageResource.IoType_In, IoType.In));
            dataSource.Add(new IoTypeItem(MessageResource.IoType_Out, IoType.Out));
            dataSource.Add(new IoTypeItem(MessageResource.IoType_InOut, IoType.InOut));

            IoTypeColumn.DisplayMember = "Name";
            IoTypeColumn.ValueMember = "Value";
            IoTypeColumn.DataSource = dataSource;
        }

        private class IoTypeItem
        {
            public IoTypeItem(string name, IoType value)
            {
                this.Value = value;
                this.Name = name;
            }

            public IoType Value { get; set; }
            public string Name { get; set; }
        }


        private void nameBox_Validated(object sender, EventArgs e)
        {
            GetData();
        }

        private bool IsParameterEmpty(CFunctionParameter field)
        {
            if (!string.IsNullOrEmpty(field.Name))
                return false;
            if (!string.IsNullOrEmpty(field.Description))
                return false;

            return true;
        }
    }
}
