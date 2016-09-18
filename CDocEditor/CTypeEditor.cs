using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Magica.Pgdoc.Clang;

namespace CDocEditor
{
    public partial class CTypeEditor : UserControl, IPgdocEditor
    {
        private CTypeTreeNode node;

        public CTypeEditor(CTypeTreeNode node)
        {
            InitializeComponent();

            InitializeComboBox();

            this.node = node;

            nameBox.Text = this.node.Data.Name;
            typeBox.SelectedValue = this.node.Data.Kind;
            summaryBox.Text = this.node.Data.Summary;
            definitionBox.Text = this.node.Data.Definition;
            fieldGrid.DataSource
                = new BindingList<CTypeField>(
                    new List<CTypeField>(this.node.Data.Fields));
            remarksBox.Text = this.node.Data.Description;
        }

        public void RefreshData()
        {
            this.node.Data.Name = nameBox.Text;
            this.node.Data.Kind = (TypeKind)typeBox.SelectedValue;
            this.node.Data.Summary = summaryBox.Text;
            this.node.Data.Definition = definitionBox.Text;

            this.node.Data.Fields.Clear();
            foreach (CTypeField field in (BindingList<CTypeField>)fieldGrid.DataSource)
            {
                if (!IsFieldEmpty(field))
                {
                    this.node.Data.Fields.Add(field);
                }
            }

            this.node.Data.Description = remarksBox.Text;
            
            this.node.Text = this.node.Data.Name;
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void InitializeComboBox()
        {
            List<TypeItem> dataSource = new List<TypeItem>();
            dataSource.Add(new TypeItem(MessageResource.TypeEnum, TypeKind.Enum));
            dataSource.Add(new TypeItem(MessageResource.TypeUnion, TypeKind.Union));
            dataSource.Add(new TypeItem(MessageResource.TypeStruct, TypeKind.Struct));
            dataSource.Add(new TypeItem(MessageResource.TypeTypedef, TypeKind.Typedef));

            typeBox.DisplayMember = "Name";
            typeBox.ValueMember = "Value";
            typeBox.DataSource = dataSource;
        }

        private class TypeItem
        {
            public TypeKind Value { get; set; }
            public string Name { get; set; }

            public TypeItem(string name, TypeKind value)
            {
                this.Name = name;
                this.Value = value;
            }
        }

        private bool IsFieldEmpty(CTypeField field)
        {
            if (!string.IsNullOrEmpty(field.Name))
                return false;
            if (!string.IsNullOrEmpty(field.Type))
                return false;
            if (!string.IsNullOrEmpty(field.Description))
                return false;

            return true;
        }
    }
}
