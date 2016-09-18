namespace CDocEditor
{
    partial class CTypeEditor
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.remarksLabel = new System.Windows.Forms.Label();
            this.remarksBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.definitionBox = new System.Windows.Forms.TextBox();
            this.definitionLabel = new System.Windows.Forms.Label();
            this.summaryBox = new System.Windows.Forms.TextBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.fieldLabel = new System.Windows.Forms.Label();
            this.fieldGrid = new System.Windows.Forms.DataGridView();
            this.fieldNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fieldGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // typeBox
            // 
            this.typeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(414, 0);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(182, 20);
            this.typeBox.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "型タイプ";
            // 
            // remarksLabel
            // 
            this.remarksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksLabel.AutoSize = true;
            this.remarksLabel.Location = new System.Drawing.Point(64, 306);
            this.remarksLabel.Name = "remarksLabel";
            this.remarksLabel.Size = new System.Drawing.Size(29, 12);
            this.remarksLabel.TabIndex = 35;
            this.remarksLabel.Text = "備考";
            // 
            // remarksBox
            // 
            this.remarksBox.AcceptsReturn = true;
            this.remarksBox.AcceptsTab = true;
            this.remarksBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksBox.Location = new System.Drawing.Point(99, 281);
            this.remarksBox.Multiline = true;
            this.remarksBox.Name = "remarksBox";
            this.remarksBox.Size = new System.Drawing.Size(497, 128);
            this.remarksBox.TabIndex = 34;
            // 
            // nameBox
            // 
            this.nameBox.AcceptsTab = true;
            this.nameBox.Location = new System.Drawing.Point(99, 0);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(260, 19);
            this.nameBox.TabIndex = 33;
            this.nameBox.Validated += new System.EventHandler(this.nameBox_Validated);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(64, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 12);
            this.nameLabel.TabIndex = 32;
            this.nameLabel.Text = "型名";
            // 
            // definitionBox
            // 
            this.definitionBox.AcceptsReturn = true;
            this.definitionBox.AcceptsTab = true;
            this.definitionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.definitionBox.Location = new System.Drawing.Point(99, 74);
            this.definitionBox.Multiline = true;
            this.definitionBox.Name = "definitionBox";
            this.definitionBox.Size = new System.Drawing.Size(497, 93);
            this.definitionBox.TabIndex = 31;
            // 
            // definitionLabel
            // 
            this.definitionLabel.AutoSize = true;
            this.definitionLabel.Location = new System.Drawing.Point(64, 77);
            this.definitionLabel.Name = "definitionLabel";
            this.definitionLabel.Size = new System.Drawing.Size(29, 12);
            this.definitionLabel.TabIndex = 30;
            this.definitionLabel.Text = "定義";
            // 
            // summaryBox
            // 
            this.summaryBox.AcceptsReturn = true;
            this.summaryBox.AcceptsTab = true;
            this.summaryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryBox.Location = new System.Drawing.Point(99, 25);
            this.summaryBox.Multiline = true;
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.Size = new System.Drawing.Size(497, 43);
            this.summaryBox.TabIndex = 29;
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Location = new System.Drawing.Point(64, 28);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(29, 12);
            this.summaryLabel.TabIndex = 28;
            this.summaryLabel.Text = "概要";
            // 
            // fieldLabel
            // 
            this.fieldLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldLabel.AutoSize = true;
            this.fieldLabel.Location = new System.Drawing.Point(27, 173);
            this.fieldLabel.Name = "fieldLabel";
            this.fieldLabel.Size = new System.Drawing.Size(66, 12);
            this.fieldLabel.TabIndex = 40;
            this.fieldLabel.Text = "メンバー変数";
            // 
            // fieldGrid
            // 
            this.fieldGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fieldGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldNameColumn,
            this.fieldTypeColumn,
            this.fieldDescriptionColumn});
            this.fieldGrid.Location = new System.Drawing.Point(99, 173);
            this.fieldGrid.Name = "fieldGrid";
            this.fieldGrid.RowTemplate.Height = 21;
            this.fieldGrid.Size = new System.Drawing.Size(497, 105);
            this.fieldGrid.TabIndex = 41;
            // 
            // fieldNameColumn
            // 
            this.fieldNameColumn.DataPropertyName = "Name";
            this.fieldNameColumn.HeaderText = "メンバー名";
            this.fieldNameColumn.Name = "fieldNameColumn";
            // 
            // fieldTypeColumn
            // 
            this.fieldTypeColumn.DataPropertyName = "Type";
            this.fieldTypeColumn.HeaderText = "型名";
            this.fieldTypeColumn.Name = "fieldTypeColumn";
            // 
            // fieldDescriptionColumn
            // 
            this.fieldDescriptionColumn.DataPropertyName = "Description";
            this.fieldDescriptionColumn.HeaderText = "説明";
            this.fieldDescriptionColumn.Name = "fieldDescriptionColumn";
            this.fieldDescriptionColumn.Width = 200;
            // 
            // CTypeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fieldGrid);
            this.Controls.Add(this.fieldLabel);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remarksLabel);
            this.Controls.Add(this.remarksBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.definitionBox);
            this.Controls.Add(this.definitionLabel);
            this.Controls.Add(this.summaryBox);
            this.Controls.Add(this.summaryLabel);
            this.Name = "CTypeEditor";
            this.Size = new System.Drawing.Size(611, 415);
            ((System.ComponentModel.ISupportInitialize)(this.fieldGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label remarksLabel;
        private System.Windows.Forms.TextBox remarksBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox definitionBox;
        private System.Windows.Forms.Label definitionLabel;
        private System.Windows.Forms.TextBox summaryBox;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.Label fieldLabel;
        private System.Windows.Forms.DataGridView fieldGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldDescriptionColumn;
    }
}
