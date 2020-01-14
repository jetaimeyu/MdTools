namespace MdTools
{
    partial class FormScanCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScanCode));
            this.ScanStart = new System.Windows.Forms.Button();
            this.ScanStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ScanIP = new System.Windows.Forms.TextBox();
            this.Tips = new System.Windows.Forms.Label();
            this.ScanPoint = new System.Windows.Forms.Label();
            this.ScanList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ScanStart
            // 
            this.ScanStart.Location = new System.Drawing.Point(533, 28);
            this.ScanStart.Name = "ScanStart";
            this.ScanStart.Size = new System.Drawing.Size(75, 23);
            this.ScanStart.TabIndex = 0;
            this.ScanStart.Text = "开始扫码";
            this.ScanStart.UseVisualStyleBackColor = true;
            this.ScanStart.Click += new System.EventHandler(this.ScanStart_Click);
            // 
            // ScanStop
            // 
            this.ScanStop.Enabled = false;
            this.ScanStop.Location = new System.Drawing.Point(631, 28);
            this.ScanStop.Name = "ScanStop";
            this.ScanStop.Size = new System.Drawing.Size(75, 23);
            this.ScanStop.TabIndex = 1;
            this.ScanStop.Text = "结束";
            this.ScanStop.UseVisualStyleBackColor = true;
            this.ScanStop.Click += new System.EventHandler(this.ScanStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "扫码设备IP：";
            // 
            // ScanIP
            // 
            this.ScanIP.Location = new System.Drawing.Point(112, 30);
            this.ScanIP.Name = "ScanIP";
            this.ScanIP.Size = new System.Drawing.Size(221, 21);
            this.ScanIP.TabIndex = 3;
            this.ScanIP.TextChanged += new System.EventHandler(this.Scan_TextChanged);
            // 
            // Tips
            // 
            this.Tips.AutoSize = true;
            this.Tips.ForeColor = System.Drawing.Color.Red;
            this.Tips.Location = new System.Drawing.Point(29, 71);
            this.Tips.Name = "Tips";
            this.Tips.Size = new System.Drawing.Size(0, 12);
            this.Tips.TabIndex = 5;
            // 
            // ScanPoint
            // 
            this.ScanPoint.AutoSize = true;
            this.ScanPoint.Location = new System.Drawing.Point(339, 33);
            this.ScanPoint.Name = "ScanPoint";
            this.ScanPoint.Size = new System.Drawing.Size(35, 12);
            this.ScanPoint.TabIndex = 6;
            this.ScanPoint.Text = "51236";
            // 
            // ScanList
            // 
            this.ScanList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScanList.FormattingEnabled = true;
            this.ScanList.ItemHeight = 12;
            this.ScanList.Location = new System.Drawing.Point(12, 113);
            this.ScanList.Name = "ScanList";
            this.ScanList.Size = new System.Drawing.Size(776, 304);
            this.ScanList.TabIndex = 7;
            // 
            // FormScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ScanList);
            this.Controls.Add(this.ScanPoint);
            this.Controls.Add(this.Tips);
            this.Controls.Add(this.ScanIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScanStop);
            this.Controls.Add(this.ScanStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormScanCode";
            this.RightToLeftLayout = true;
            this.Text = "扫码测试";
            this.Load += new System.EventHandler(this.FormScanCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScanStart;
        private System.Windows.Forms.Button ScanStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ScanIP;
        private System.Windows.Forms.Label Tips;
        private System.Windows.Forms.Label ScanPoint;
        private System.Windows.Forms.ListBox ScanList;
    }
}