namespace KGSurvey
{
    partial class KGSurvey_Mark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KGSurvey_Mark));
            this.rbtXY = new System.Windows.Forms.RadioButton();
            this.rbtYX = new System.Windows.Forms.RadioButton();
            this.lstLayer = new System.Windows.Forms.ListView();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnSelNone = new System.Windows.Forms.Button();
            this.rbtByLayer = new System.Windows.Forms.RadioButton();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.numericNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNum = new System.Windows.Forms.CheckBox();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.chkZ = new System.Windows.Forms.CheckBox();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTxtHeight = new System.Windows.Forms.TextBox();
            this.tbLayerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtXY
            // 
            this.rbtXY.AutoSize = true;
            this.rbtXY.Location = new System.Drawing.Point(405, 408);
            this.rbtXY.Name = "rbtXY";
            this.rbtXY.Size = new System.Drawing.Size(97, 16);
            this.rbtXY.TabIndex = 30;
            this.rbtXY.Text = "일반좌표(XY)";
            this.rbtXY.UseVisualStyleBackColor = true;
            // 
            // rbtYX
            // 
            this.rbtYX.AutoSize = true;
            this.rbtYX.Checked = true;
            this.rbtYX.Location = new System.Drawing.Point(279, 408);
            this.rbtYX.Name = "rbtYX";
            this.rbtYX.Size = new System.Drawing.Size(97, 16);
            this.rbtYX.TabIndex = 29;
            this.rbtYX.TabStop = true;
            this.rbtYX.Text = "토목좌표(YX)";
            this.rbtYX.UseVisualStyleBackColor = true;
            // 
            // lstLayer
            // 
            this.lstLayer.FullRowSelect = true;
            this.lstLayer.Location = new System.Drawing.Point(283, 173);
            this.lstLayer.Name = "lstLayer";
            this.lstLayer.Size = new System.Drawing.Size(215, 209);
            this.lstLayer.TabIndex = 28;
            this.lstLayer.UseCompatibleStateImageBehavior = false;
            this.lstLayer.View = System.Windows.Forms.View.Details;
            // 
            // btnSelAll
            // 
            this.btnSelAll.Location = new System.Drawing.Point(301, 144);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelAll.TabIndex = 27;
            this.btnSelAll.Text = "모두 선택";
            this.btnSelAll.UseVisualStyleBackColor = true;
            // 
            // btnSelNone
            // 
            this.btnSelNone.Location = new System.Drawing.Point(399, 144);
            this.btnSelNone.Name = "btnSelNone";
            this.btnSelNone.Size = new System.Drawing.Size(75, 23);
            this.btnSelNone.TabIndex = 26;
            this.btnSelNone.Text = "선택 해제";
            this.btnSelNone.UseVisualStyleBackColor = true;
            // 
            // rbtByLayer
            // 
            this.rbtByLayer.AutoSize = true;
            this.rbtByLayer.Location = new System.Drawing.Point(399, 122);
            this.rbtByLayer.Name = "rbtByLayer";
            this.rbtByLayer.Size = new System.Drawing.Size(99, 16);
            this.rbtByLayer.TabIndex = 25;
            this.rbtByLayer.Text = "레이어별 적용";
            this.rbtByLayer.UseVisualStyleBackColor = true;
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Checked = true;
            this.rbtAll.Location = new System.Drawing.Point(300, 122);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(75, 16);
            this.rbtAll.TabIndex = 24;
            this.rbtAll.TabStop = true;
            this.rbtAll.Text = "전체 적용";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // numericNum
            // 
            this.numericNum.Location = new System.Drawing.Point(131, 120);
            this.numericNum.Name = "numericNum";
            this.numericNum.Size = new System.Drawing.Size(92, 21);
            this.numericNum.TabIndex = 23;
            this.numericNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "소수점 자릿수 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNum);
            this.groupBox1.Controls.Add(this.chkCode);
            this.groupBox1.Controls.Add(this.chkY);
            this.groupBox1.Controls.Add(this.chkX);
            this.groupBox1.Controls.Add(this.chkZ);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 89);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "측점 표기 정보";
            // 
            // chkNum
            // 
            this.chkNum.AutoSize = true;
            this.chkNum.Checked = true;
            this.chkNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNum.Location = new System.Drawing.Point(18, 55);
            this.chkNum.Name = "chkNum";
            this.chkNum.Size = new System.Drawing.Size(48, 16);
            this.chkNum.TabIndex = 3;
            this.chkNum.Text = "번호";
            this.chkNum.UseVisualStyleBackColor = true;
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Checked = true;
            this.chkCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode.Location = new System.Drawing.Point(96, 55);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(48, 16);
            this.chkCode.TabIndex = 4;
            this.chkCode.Text = "코드";
            this.chkCode.UseVisualStyleBackColor = true;
            // 
            // chkY
            // 
            this.chkY.AutoSize = true;
            this.chkY.Checked = true;
            this.chkY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkY.Location = new System.Drawing.Point(18, 33);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(72, 16);
            this.chkY.TabIndex = 0;
            this.chkY.Text = "North(Y)";
            this.chkY.UseVisualStyleBackColor = true;
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.Checked = true;
            this.chkX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkX.Location = new System.Drawing.Point(96, 33);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(67, 16);
            this.chkX.TabIndex = 1;
            this.chkX.Text = "East(X)";
            this.chkX.UseVisualStyleBackColor = true;
            // 
            // chkZ
            // 
            this.chkZ.AutoSize = true;
            this.chkZ.Checked = true;
            this.chkZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZ.Location = new System.Drawing.Point(169, 33);
            this.chkZ.Name = "chkZ";
            this.chkZ.Size = new System.Drawing.Size(66, 16);
            this.chkZ.TabIndex = 2;
            this.chkZ.Text = "Elev(Z)";
            this.chkZ.UseVisualStyleBackColor = true;
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(110, 228);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(100, 34);
            this.btnRelease.TabIndex = 20;
            this.btnRelease.Text = "전체 적용 해제";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnAdjust
            // 
            this.btnAdjust.Location = new System.Drawing.Point(5, 228);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(97, 34);
            this.btnAdjust.TabIndex = 19;
            this.btnAdjust.Text = "측점 표기 적용";
            this.btnAdjust.UseVisualStyleBackColor = true;
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "텍스트 크기 :";
            // 
            // tbTxtHeight
            // 
            this.tbTxtHeight.Location = new System.Drawing.Point(131, 156);
            this.tbTxtHeight.Name = "tbTxtHeight";
            this.tbTxtHeight.Size = new System.Drawing.Size(92, 21);
            this.tbTxtHeight.TabIndex = 32;
            this.tbTxtHeight.Text = "0.5";
            this.tbTxtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbLayerName
            // 
            this.tbLayerName.Location = new System.Drawing.Point(131, 192);
            this.tbLayerName.Name = "tbLayerName";
            this.tbLayerName.Size = new System.Drawing.Size(92, 21);
            this.tbLayerName.TabIndex = 34;
            this.tbLayerName.Text = "측점표기";
            this.tbLayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "측점 레이어 :";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(218, 228);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(44, 34);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "닫기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // KGSurvey_Mark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 276);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbLayerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTxtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtXY);
            this.Controls.Add(this.rbtYX);
            this.Controls.Add(this.lstLayer);
            this.Controls.Add(this.btnSelAll);
            this.Controls.Add(this.btnSelNone);
            this.Controls.Add(this.rbtByLayer);
            this.Controls.Add(this.rbtAll);
            this.Controls.Add(this.numericNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnAdjust);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KGSurvey_Mark";
            this.Text = "측점 표기 - KGSurvey";
            ((System.ComponentModel.ISupportInitialize)(this.numericNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtXY;
        private System.Windows.Forms.RadioButton rbtYX;
        private System.Windows.Forms.ListView lstLayer;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.Button btnSelNone;
        private System.Windows.Forms.RadioButton rbtByLayer;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.NumericUpDown numericNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNum;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.CheckBox chkZ;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnAdjust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTxtHeight;
        private System.Windows.Forms.TextBox tbLayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
    }
}