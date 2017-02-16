namespace KGSurvey
{
    partial class KGSurvey_Contour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KGSurvey_Contour));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMaxItv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMinItv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxElev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMinElev = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAuto);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbMaxItv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbMinItv);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbMaxElev);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbMinElev);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "등고선 옵션";
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(87, 24);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(104, 16);
            this.chkAuto.TabIndex = 2;
            this.chkAuto.Text = "표고 자동 적용";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "m";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "m";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "m";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "m";
            // 
            // tbMaxItv
            // 
            this.tbMaxItv.Location = new System.Drawing.Point(90, 159);
            this.tbMaxItv.Name = "tbMaxItv";
            this.tbMaxItv.ReadOnly = true;
            this.tbMaxItv.Size = new System.Drawing.Size(83, 21);
            this.tbMaxItv.TabIndex = 8;
            this.tbMaxItv.Text = "5";
            this.tbMaxItv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "주곡선 간격 :";
            // 
            // tbMinItv
            // 
            this.tbMinItv.Location = new System.Drawing.Point(90, 124);
            this.tbMinItv.Name = "tbMinItv";
            this.tbMinItv.Size = new System.Drawing.Size(83, 21);
            this.tbMinItv.TabIndex = 6;
            this.tbMinItv.Text = "1";
            this.tbMinItv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMinItv.TextChanged += new System.EventHandler(this.tbMinItv_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "조곡선 간격 :";
            // 
            // tbMaxElev
            // 
            this.tbMaxElev.Enabled = false;
            this.tbMaxElev.Location = new System.Drawing.Point(90, 89);
            this.tbMaxElev.Name = "tbMaxElev";
            this.tbMaxElev.Size = new System.Drawing.Size(83, 21);
            this.tbMaxElev.TabIndex = 4;
            this.tbMaxElev.Text = "10.0";
            this.tbMaxElev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "최고표고 :";
            // 
            // tbMinElev
            // 
            this.tbMinElev.Enabled = false;
            this.tbMinElev.Location = new System.Drawing.Point(90, 54);
            this.tbMinElev.Name = "tbMinElev";
            this.tbMinElev.Size = new System.Drawing.Size(83, 21);
            this.tbMinElev.TabIndex = 2;
            this.tbMinElev.Text = "0.0";
            this.tbMinElev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "최저표고 :";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(35, 229);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // KGSurvey_Contour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 261);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KGSurvey_Contour";
            this.Text = "등고선 - KGSurvey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMaxItv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMinItv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaxElev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMinElev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAuto;
    }
}