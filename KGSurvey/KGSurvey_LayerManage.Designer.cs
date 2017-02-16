namespace KGSurvey
{
    partial class KGSurvey_LayerManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KGSurvey_LayerManage));
            this.lstLayer = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExit = new System.Windows.Forms.Button();
            this.cboList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.chkDel = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstLayer
            // 
            this.lstLayer.CheckBoxes = true;
            this.lstLayer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstLayer.Location = new System.Drawing.Point(14, 52);
            this.lstLayer.Name = "lstLayer";
            this.lstLayer.Size = new System.Drawing.Size(190, 260);
            this.lstLayer.TabIndex = 15;
            this.lstLayer.UseCompatibleStateImageBehavior = false;
            this.lstLayer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "  ";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "이름";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 102;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(301, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 42);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "닫기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboList
            // 
            this.cboList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboList.FormattingEnabled = true;
            this.cboList.Location = new System.Drawing.Point(220, 52);
            this.cboList.Name = "cboList";
            this.cboList.Size = new System.Drawing.Size(156, 20);
            this.cboList.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "현재 레이어 목록";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(220, 270);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 42);
            this.btnCopy.TabIndex = 20;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // chkDel
            // 
            this.chkDel.AutoSize = true;
            this.chkDel.Location = new System.Drawing.Point(14, 344);
            this.chkDel.Name = "chkDel";
            this.chkDel.Size = new System.Drawing.Size(158, 16);
            this.chkDel.TabIndex = 19;
            this.chkDel.Text = "복사/병합된 레이어 삭제";
            this.chkDel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "대상 레이어 목록";
            // 
            // KGSurvey_LayerManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 325);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstLayer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.chkDel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KGSurvey_LayerManage";
            this.Text = "레이어 관리 - KGSurvey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstLayer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cboList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox chkDel;
        private System.Windows.Forms.Label label2;
    }
}