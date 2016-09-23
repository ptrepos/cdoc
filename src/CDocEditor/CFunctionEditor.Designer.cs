namespace CDocEditor
{
    partial class CFunctionEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.remarksLabel = new System.Windows.Forms.Label();
            this.remarksBox = new System.Windows.Forms.TextBox();
            this.returnBox = new System.Windows.Forms.TextBox();
            this.returnLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parameterGrid = new System.Windows.Forms.DataGridView();
            this.definitionBox = new System.Windows.Forms.TextBox();
            this.definitionLabel = new System.Windows.Forms.Label();
            this.summaryBox = new System.Windows.Forms.TextBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.parameterGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // remarksLabel
            // 
            this.remarksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remarksLabel.AutoSize = true;
            this.remarksLabel.Location = new System.Drawing.Point(25, 327);
            this.remarksLabel.Name = "remarksLabel";
            this.remarksLabel.Size = new System.Drawing.Size(29, 12);
            this.remarksLabel.TabIndex = 23;
            this.remarksLabel.Text = "備考";
            // 
            // remarksBox
            // 
            this.remarksBox.AcceptsReturn = true;
            this.remarksBox.AcceptsTab = true;
            this.remarksBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksBox.Location = new System.Drawing.Point(68, 324);
            this.remarksBox.Multiline = true;
            this.remarksBox.Name = "remarksBox";
            this.remarksBox.Size = new System.Drawing.Size(469, 99);
            this.remarksBox.TabIndex = 22;
            // 
            // returnBox
            // 
            this.returnBox.AcceptsReturn = true;
            this.returnBox.AcceptsTab = true;
            this.returnBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnBox.Location = new System.Drawing.Point(68, 275);
            this.returnBox.Multiline = true;
            this.returnBox.Name = "returnBox";
            this.returnBox.Size = new System.Drawing.Size(469, 43);
            this.returnBox.TabIndex = 21;
            // 
            // returnLabel
            // 
            this.returnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(25, 278);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(37, 12);
            this.returnLabel.TabIndex = 20;
            this.returnLabel.Text = "戻り値";
            // 
            // nameBox
            // 
            this.nameBox.AcceptsTab = true;
            this.nameBox.Location = new System.Drawing.Point(68, 8);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(290, 19);
            this.nameBox.TabIndex = 19;
            this.nameBox.Validated += new System.EventHandler(this.nameBox_Validated);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(21, 11);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 12);
            this.nameLabel.TabIndex = 18;
            this.nameLabel.Text = "関数名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "パラメータ";
            // 
            // parameterGrid
            // 
            this.parameterGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parameterGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.parameterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parameterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.descriptionColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parameterGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.parameterGrid.Location = new System.Drawing.Point(68, 181);
            this.parameterGrid.Name = "parameterGrid";
            this.parameterGrid.RowTemplate.Height = 21;
            this.parameterGrid.Size = new System.Drawing.Size(469, 88);
            this.parameterGrid.TabIndex = 16;
            // 
            // definitionBox
            // 
            this.definitionBox.AcceptsReturn = true;
            this.definitionBox.AcceptsTab = true;
            this.definitionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.definitionBox.Location = new System.Drawing.Point(68, 82);
            this.definitionBox.Multiline = true;
            this.definitionBox.Name = "definitionBox";
            this.definitionBox.Size = new System.Drawing.Size(469, 93);
            this.definitionBox.TabIndex = 15;
            // 
            // definitionLabel
            // 
            this.definitionLabel.AutoSize = true;
            this.definitionLabel.Location = new System.Drawing.Point(33, 85);
            this.definitionLabel.Name = "definitionLabel";
            this.definitionLabel.Size = new System.Drawing.Size(29, 12);
            this.definitionLabel.TabIndex = 14;
            this.definitionLabel.Text = "定義";
            // 
            // summaryBox
            // 
            this.summaryBox.AcceptsReturn = true;
            this.summaryBox.AcceptsTab = true;
            this.summaryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryBox.Location = new System.Drawing.Point(68, 33);
            this.summaryBox.Multiline = true;
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.Size = new System.Drawing.Size(469, 43);
            this.summaryBox.TabIndex = 13;
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Location = new System.Drawing.Point(33, 36);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(29, 12);
            this.summaryLabel.TabIndex = 12;
            this.summaryLabel.Text = "概要";
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "パラメータ名";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 120;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descriptionColumn.DataPropertyName = "Description";
            this.descriptionColumn.HeaderText = "説明";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.Width = 300;
            // 
            // CFunctionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.remarksLabel);
            this.Controls.Add(this.remarksBox);
            this.Controls.Add(this.returnBox);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parameterGrid);
            this.Controls.Add(this.definitionBox);
            this.Controls.Add(this.definitionLabel);
            this.Controls.Add(this.summaryBox);
            this.Controls.Add(this.summaryLabel);
            this.Name = "CFunctionEditor";
            this.Size = new System.Drawing.Size(553, 426);
            ((System.ComponentModel.ISupportInitialize)(this.parameterGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label remarksLabel;
        private System.Windows.Forms.TextBox remarksBox;
        private System.Windows.Forms.TextBox returnBox;
        private System.Windows.Forms.Label returnLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView parameterGrid;
        private System.Windows.Forms.TextBox definitionBox;
        private System.Windows.Forms.Label definitionLabel;
        private System.Windows.Forms.TextBox summaryBox;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
    }
}
