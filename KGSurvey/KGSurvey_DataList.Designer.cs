namespace KGSurvey
{
    partial class KGSurvey_DataList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KGSurvey_DataList));
            this.grdPoints = new SourceGrid.Grid();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTri = new System.Windows.Forms.Button();
            this.btnCls = new System.Windows.Forms.Button();
            this.btnExc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grdPoints
            // 
            this.grdPoints.BackColor = System.Drawing.Color.White;
            this.grdPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPoints.EnableSort = true;
            this.grdPoints.Location = new System.Drawing.Point(12, 12);
            this.grdPoints.Name = "grdPoints";
            this.grdPoints.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grdPoints.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.grdPoints.Size = new System.Drawing.Size(484, 505);
            this.grdPoints.TabIndex = 0;
            this.grdPoints.TabStop = true;
            this.grdPoints.ToolTipText = "";
            this.grdPoints.Click += new System.EventHandler(this.grdPoints_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(213, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTri
            // 
            this.btnTri.Location = new System.Drawing.Point(320, 528);
            this.btnTri.Name = "btnTri";
            this.btnTri.Size = new System.Drawing.Size(58, 23);
            this.btnTri.TabIndex = 2;
            this.btnTri.Text = "Tri All";
            this.btnTri.UseVisualStyleBackColor = true;
            this.btnTri.Click += new System.EventHandler(this.btnTri_Click);
            // 
            // btnCls
            // 
            this.btnCls.Location = new System.Drawing.Point(379, 528);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(58, 23);
            this.btnCls.TabIndex = 3;
            this.btnCls.Text = "Cls All";
            this.btnCls.UseVisualStyleBackColor = true;
            this.btnCls.Click += new System.EventHandler(this.btnCls_Click);
            // 
            // btnExc
            // 
            this.btnExc.Location = new System.Drawing.Point(438, 528);
            this.btnExc.Name = "btnExc";
            this.btnExc.Size = new System.Drawing.Size(58, 23);
            this.btnExc.TabIndex = 4;
            this.btnExc.Text = "Exc All";
            this.btnExc.UseVisualStyleBackColor = true;
            this.btnExc.Click += new System.EventHandler(this.btnExc_Click);
            // 
            // KGSurvey_DataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 563);
            this.Controls.Add(this.btnExc);
            this.Controls.Add(this.btnCls);
            this.Controls.Add(this.btnTri);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdPoints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KGSurvey_DataList";
            this.Text = "측점 리스트 - KGSurvey";
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grdPoints;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTri;
        private System.Windows.Forms.Button btnCls;
        private System.Windows.Forms.Button btnExc;

    }
}