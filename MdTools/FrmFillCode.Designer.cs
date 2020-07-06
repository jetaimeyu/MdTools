namespace MdTools
{
    partial class FrmFillCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CompID = new System.Windows.Forms.TextBox();
            this.CompIDLable = new System.Windows.Forms.Label();
            this.DownCodeButton = new System.Windows.Forms.Button();
            this.DownCount = new System.Windows.Forms.TextBox();
            this.downCountLable = new System.Windows.Forms.Label();
            this.currentCount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CompID
            // 
            this.CompID.Location = new System.Drawing.Point(294, 125);
            this.CompID.Name = "CompID";
            this.CompID.Size = new System.Drawing.Size(197, 21);
            this.CompID.TabIndex = 0;
            // 
            // CompIDLable
            // 
            this.CompIDLable.AutoSize = true;
            this.CompIDLable.Location = new System.Drawing.Point(236, 128);
            this.CompIDLable.Name = "CompIDLable";
            this.CompIDLable.Size = new System.Drawing.Size(41, 12);
            this.CompIDLable.TabIndex = 1;
            this.CompIDLable.Text = "企业ID";
            // 
            // DownCodeButton
            // 
            this.DownCodeButton.Location = new System.Drawing.Point(294, 214);
            this.DownCodeButton.Name = "DownCodeButton";
            this.DownCodeButton.Size = new System.Drawing.Size(172, 32);
            this.DownCodeButton.TabIndex = 2;
            this.DownCodeButton.Text = "设置";
            this.DownCodeButton.UseVisualStyleBackColor = true;
            this.DownCodeButton.Click += new System.EventHandler(this.DownCodeButton_Click);
            // 
            // DownCount
            // 
            this.DownCount.Location = new System.Drawing.Point(294, 171);
            this.DownCount.Name = "DownCount";
            this.DownCount.Size = new System.Drawing.Size(197, 21);
            this.DownCount.TabIndex = 3;
            // 
            // downCountLable
            // 
            this.downCountLable.AutoSize = true;
            this.downCountLable.Location = new System.Drawing.Point(224, 174);
            this.downCountLable.Name = "downCountLable";
            this.downCountLable.Size = new System.Drawing.Size(53, 12);
            this.downCountLable.TabIndex = 4;
            this.downCountLable.Text = "码池容量";
            // 
            // currentCount
            // 
            this.currentCount.Location = new System.Drawing.Point(587, 125);
            this.currentCount.Name = "currentCount";
            this.currentCount.Size = new System.Drawing.Size(100, 21);
            this.currentCount.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmFillCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentCount);
            this.Controls.Add(this.downCountLable);
            this.Controls.Add(this.DownCount);
            this.Controls.Add(this.DownCodeButton);
            this.Controls.Add(this.CompIDLable);
            this.Controls.Add(this.CompID);
            this.Name = "FrmFillCode";
            this.Text = "下载数量";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompID;
        private System.Windows.Forms.Label CompIDLable;
        private System.Windows.Forms.Button DownCodeButton;
        private System.Windows.Forms.TextBox DownCount;
        private System.Windows.Forms.Label downCountLable;
        private System.Windows.Forms.TextBox currentCount;
        private System.Windows.Forms.Button button1;
    }
}