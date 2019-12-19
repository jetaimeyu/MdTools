namespace MdTools
{
    partial class ModelList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelList));
            this.ModelListGridView = new System.Windows.Forms.DataGridView();
            this.型号ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.型号名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ModelListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ModelListGridView
            // 
            this.ModelListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ModelListGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.型号ID,
            this.型号名称});
            this.ModelListGridView.Location = new System.Drawing.Point(1, 2);
            this.ModelListGridView.Name = "ModelListGridView";
            this.ModelListGridView.RowTemplate.Height = 23;
            this.ModelListGridView.Size = new System.Drawing.Size(377, 606);
            this.ModelListGridView.TabIndex = 0;
            this.ModelListGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // 型号ID
            // 
            this.型号ID.DataPropertyName = "SkuID";
            this.型号ID.HeaderText = "型号ID";
            this.型号ID.Name = "型号ID";
            this.型号ID.ReadOnly = true;
            // 
            // 型号名称
            // 
            this.型号名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.型号名称.DataPropertyName = "SkuName";
            this.型号名称.HeaderText = "型号名称";
            this.型号名称.Name = "型号名称";
            // 
            // TipsLabel
            // 
            this.TipsLabel.AutoSize = true;
            this.TipsLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TipsLabel.Location = new System.Drawing.Point(125, 226);
            this.TipsLabel.Name = "TipsLabel";
            this.TipsLabel.Size = new System.Drawing.Size(56, 16);
            this.TipsLabel.TabIndex = 1;
            this.TipsLabel.Text = "label1";
            // 
            // ModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 612);
            this.Controls.Add(this.TipsLabel);
            this.Controls.Add(this.ModelListGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModelList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "型号列表";
            this.Load += new System.EventHandler(this.ModelList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ModelListGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ModelListGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn 型号ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 型号名称;
        private System.Windows.Forms.Label TipsLabel;
    }
}