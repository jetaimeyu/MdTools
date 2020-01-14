namespace MdTools
{
    partial class FormGetRedCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGetRedCode));
            this.GetRedCodeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CodeCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetRedCodeButton
            // 
            this.GetRedCodeButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetRedCodeButton.Location = new System.Drawing.Point(295, 258);
            this.GetRedCodeButton.Name = "GetRedCodeButton";
            this.GetRedCodeButton.Size = new System.Drawing.Size(175, 43);
            this.GetRedCodeButton.TabIndex = 0;
            this.GetRedCodeButton.Text = "领取";
            this.GetRedCodeButton.UseVisualStyleBackColor = true;
            this.GetRedCodeButton.Click += new System.EventHandler(this.GetRedCodeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(248, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "领用数量：";
            // 
            // CodeCount
            // 
            this.CodeCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CodeCount.Location = new System.Drawing.Point(357, 140);
            this.CodeCount.Name = "CodeCount";
            this.CodeCount.Size = new System.Drawing.Size(100, 26);
            this.CodeCount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(263, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "领码时尽量少量多次，推荐一次领一万个";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 51);
            this.button1.TabIndex = 4;
            this.button1.Text = "日志测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormGetRedCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CodeCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetRedCodeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGetRedCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "红包码领用";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetRedCodeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CodeCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}