namespace KGSurvey
{
    partial class KGSurvey_PointInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KGSurvey_PointInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "번호 :";
            // 
            // tbNum
            // 
            this.tbNum.Location = new System.Drawing.Point(77, 26);
            this.tbNum.Name = "tbNum";
            this.tbNum.ReadOnly = true;
            this.tbNum.Size = new System.Drawing.Size(125, 21);
            this.tbNum.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboLayer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbZ);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 168);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "정보";
            // 
            // cboLayer
            // 
            this.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayer.FormattingEnabled = true;
            this.cboLayer.Location = new System.Drawing.Point(76, 53);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(125, 20);
            this.cboLayer.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "레이어 :";
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(77, 134);
            this.tbZ.Name = "tbZ";
            this.tbZ.ReadOnly = true;
            this.tbZ.Size = new System.Drawing.Size(125, 21);
            this.tbZ.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Elev(Z) :";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(77, 107);
            this.tbX.Name = "tbX";
            this.tbX.ReadOnly = true;
            this.tbX.Size = new System.Drawing.Size(125, 21);
            this.tbX.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "East(X) :";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(77, 80);
            this.tbY.Name = "tbY";
            this.tbY.ReadOnly = true;
            this.tbY.Size = new System.Drawing.Size(125, 21);
            this.tbY.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "North(Y) :";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(86, 265);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(125, 21);
            this.tbCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "코드 :";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(51, 321);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(59, 35);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(119, 321);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 35);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(91, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 35);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "닫기";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // KGSurvey_PointInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 234);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KGSurvey_PointInfo";
            this.Text = "측점 - KGSurvey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.Label label6;
    }
}