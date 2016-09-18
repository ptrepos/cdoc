namespace CDocEditor
{
    partial class CHeaderEditor
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
            this.remarksLabel = new System.Windows.Forms.Label();
            this.remarksBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.summaryBox = new System.Windows.Forms.TextBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // remarksLabel
            // 
            this.remarksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksLabel.AutoSize = true;
            this.remarksLabel.Location = new System.Drawing.Point(64, 77);
            this.remarksLabel.Name = "remarksLabel";
            this.remarksLabel.Size = new System.Drawing.Size(29, 12);
            this.remarksLabel.TabIndex = 35;
            this.remarksLabel.Text = "備考";
            // 
            // remarksBox
            // 
            this.remarksBox.AcceptsReturn = true;
            this.remarksBox.AcceptsTab = true;
            this.remarksBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksBox.Location = new System.Drawing.Point(99, 74);
            this.remarksBox.Multiline = true;
            this.remarksBox.Name = "remarksBox";
            this.remarksBox.Size = new System.Drawing.Size(452, 261);
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
            this.nameLabel.Location = new System.Drawing.Point(50, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(43, 12);
            this.nameLabel.TabIndex = 32;
            this.nameLabel.Text = "ヘッダ名";
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
            this.summaryBox.Size = new System.Drawing.Size(452, 43);
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
            // CHeaderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.remarksLabel);
            this.Controls.Add(this.remarksBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.summaryBox);
            this.Controls.Add(this.summaryLabel);
            this.Name = "CHeaderEditor";
            this.Size = new System.Drawing.Size(566, 338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label remarksLabel;
        private System.Windows.Forms.TextBox remarksBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox summaryBox;
        private System.Windows.Forms.Label summaryLabel;
    }
}
