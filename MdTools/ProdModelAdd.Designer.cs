namespace MdTools
{
    partial class ProdModelAdd
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdModelAdd));
            this.DirTree = new System.Windows.Forms.TreeView();
            this.ProdListGrid = new System.Windows.Forms.DataGridView();
            this.产品ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.型号列表 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.操作 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TipsLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.uploadPro = new System.Windows.Forms.Label();
            this.LastPage = new System.Windows.Forms.Button();
            this.NextPage = new System.Windows.Forms.Button();
            this.PageTips = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProdListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DirTree
            // 
            this.DirTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DirTree.Location = new System.Drawing.Point(12, 12);
            this.DirTree.Name = "DirTree";
            this.DirTree.Size = new System.Drawing.Size(172, 426);
            this.DirTree.TabIndex = 0;
            this.DirTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DirTree_NodeMouseClick);
            // 
            // ProdListGrid
            // 
            this.ProdListGrid.AllowUserToAddRows = false;
            this.ProdListGrid.AllowUserToDeleteRows = false;
            this.ProdListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProdListGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ProdListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProdListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.产品ID,
            this.产品名称,
            this.型号列表,
            this.操作});
            this.ProdListGrid.Location = new System.Drawing.Point(190, 12);
            this.ProdListGrid.Name = "ProdListGrid";
            this.ProdListGrid.RowTemplate.Height = 23;
            this.ProdListGrid.Size = new System.Drawing.Size(610, 407);
            this.ProdListGrid.TabIndex = 1;
            this.ProdListGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProdListGrid_CellContentClick);
            // 
            // 产品ID
            // 
            this.产品ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.产品ID.DataPropertyName = "ProdID";
            this.产品ID.HeaderText = "产品ID";
            this.产品ID.Name = "产品ID";
            this.产品ID.ReadOnly = true;
            this.产品ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.产品ID.Width = 47;
            // 
            // 产品名称
            // 
            this.产品名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.产品名称.DataPropertyName = "ProdName";
            this.产品名称.HeaderText = "产品名称";
            this.产品名称.Name = "产品名称";
            this.产品名称.ReadOnly = true;
            this.产品名称.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 型号列表
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "型号列表";
            this.型号列表.DefaultCellStyle = dataGridViewCellStyle1;
            this.型号列表.HeaderText = "型号列表";
            this.型号列表.MinimumWidth = 100;
            this.型号列表.Name = "型号列表";
            this.型号列表.ReadOnly = true;
            this.型号列表.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // 操作
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.NullValue = "导入型号";
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.GreenYellow;
            this.操作.DefaultCellStyle = dataGridViewCellStyle2;
            this.操作.HeaderText = "操作";
            this.操作.MinimumWidth = 100;
            this.操作.Name = "操作";
            this.操作.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.操作.ToolTipText = "导入型号";
            // 
            // TipsLabel
            // 
            this.TipsLabel.AutoSize = true;
            this.TipsLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TipsLabel.Location = new System.Drawing.Point(342, 139);
            this.TipsLabel.Name = "TipsLabel";
            this.TipsLabel.Size = new System.Drawing.Size(104, 19);
            this.TipsLabel.TabIndex = 2;
            this.TipsLabel.Text = "数据加载中";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(266, 210);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(338, 27);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // uploadPro
            // 
            this.uploadPro.AutoSize = true;
            this.uploadPro.Location = new System.Drawing.Point(400, 210);
            this.uploadPro.Name = "uploadPro";
            this.uploadPro.Size = new System.Drawing.Size(0, 12);
            this.uploadPro.TabIndex = 4;
            // 
            // LastPage
            // 
            this.LastPage.Location = new System.Drawing.Point(321, 425);
            this.LastPage.Name = "LastPage";
            this.LastPage.Size = new System.Drawing.Size(75, 23);
            this.LastPage.TabIndex = 5;
            this.LastPage.Text = "上一页";
            this.LastPage.UseVisualStyleBackColor = true;
            this.LastPage.Click += new System.EventHandler(this.LastPage_Click);
            // 
            // NextPage
            // 
            this.NextPage.Location = new System.Drawing.Point(432, 425);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(75, 23);
            this.NextPage.TabIndex = 6;
            this.NextPage.TabStop = false;
            this.NextPage.Text = "下一页";
            this.NextPage.UseVisualStyleBackColor = true;
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // PageTips
            // 
            this.PageTips.AutoSize = true;
            this.PageTips.Location = new System.Drawing.Point(569, 431);
            this.PageTips.Name = "PageTips";
            this.PageTips.Size = new System.Drawing.Size(0, 12);
            this.PageTips.TabIndex = 7;
            // 
            // ProdModelAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PageTips);
            this.Controls.Add(this.NextPage);
            this.Controls.Add(this.LastPage);
            this.Controls.Add(this.uploadPro);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.TipsLabel);
            this.Controls.Add(this.ProdListGrid);
            this.Controls.Add(this.DirTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProdModelAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品列表";
            this.Load += new System.EventHandler(this.ProdModelAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProdListGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView DirTree;
        private System.Windows.Forms.DataGridView ProdListGrid;
        private System.Windows.Forms.Label TipsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品名称;
        private System.Windows.Forms.DataGridViewButtonColumn 型号列表;
        private System.Windows.Forms.DataGridViewButtonColumn 操作;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label uploadPro;
        private System.Windows.Forms.Button LastPage;
        private System.Windows.Forms.Button NextPage;
        private System.Windows.Forms.Label PageTips;
    }
}

