namespace CDocEditor
{
    partial class CConstantsEditor
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.summaryBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.AcceptsTab = true;
            this.nameBox.Location = new System.Drawing.Point(99, 0);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(290, 19);
            this.nameBox.TabIndex = 33;
            this.nameBox.Validated += new System.EventHandler(this.nameBox_Validated);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(52, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 12);
            this.nameLabel.TabIndex = 32;
            this.nameLabel.Text = "定数名";
            // 
            // descriptionBox
            // 
            this.descriptionBox.AcceptsReturn = true;
            this.descriptionBox.AcceptsTab = true;
            this.descriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionBox.Location = new System.Drawing.Point(99, 93);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(445, 242);
            this.descriptionBox.TabIndex = 29;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(64, 96);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(29, 12);
            this.descriptionLabel.TabIndex = 28;
            this.descriptionLabel.Text = "説明";
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Location = new System.Drawing.Point(64, 53);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(29, 12);
            this.summaryLabel.TabIndex = 34;
            this.summaryLabel.Text = "概要";
            // 
            // summaryBox
            // 
            this.summaryBox.AcceptsReturn = true;
            this.summaryBox.AcceptsTab = true;
            this.summaryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryBox.Location = new System.Drawing.Point(99, 50);
            this.summaryBox.Multiline = true;
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.Size = new System.Drawing.Size(445, 37);
            this.summaryBox.TabIndex = 35;
            // 
            // typeBox
            // 
            this.typeBox.AcceptsReturn = true;
            this.typeBox.AcceptsTab = true;
            this.typeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeBox.Location = new System.Drawing.Point(99, 25);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(290, 19);
            this.typeBox.TabIndex = 37;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(64, 28);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(29, 12);
            this.typeLabel.TabIndex = 36;
            this.typeLabel.Text = "型名";
            // 
            // CConstantsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.summaryBox);
            this.Controls.Add(this.summaryLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.descriptionLabel);
            this.Name = "CConstantsEditor";
            this.Size = new System.Drawing.Size(561, 338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.TextBox summaryBox;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.Label typeLabel;
    }
}
