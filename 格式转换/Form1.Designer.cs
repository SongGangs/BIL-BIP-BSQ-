namespace 格式转换
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectFileBtu = new System.Windows.Forms.Button();
            this.Txt_Openfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DispalyBtu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_bsq = new System.Windows.Forms.RadioButton();
            this.radioButton_bil = new System.Windows.Forms.RadioButton();
            this.radioButton_bip = new System.Windows.Forms.RadioButton();
            this.ConvertBtu = new System.Windows.Forms.Button();
            this.SaveFileBtu = new System.Windows.Forms.Button();
            this.Txt_SaveFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Column = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_FIleFormat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_Row = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txt_TM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_DataFormat = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.QurryInfoBtu = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.OrginFile_Btu = new System.Windows.Forms.Button();
            this.Txt_OrginFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFileBtu
            // 
            this.SelectFileBtu.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectFileBtu.Location = new System.Drawing.Point(576, 18);
            this.SelectFileBtu.Name = "SelectFileBtu";
            this.SelectFileBtu.Size = new System.Drawing.Size(75, 28);
            this.SelectFileBtu.TabIndex = 0;
            this.SelectFileBtu.Text = "选 择";
            this.SelectFileBtu.UseVisualStyleBackColor = true;
            this.SelectFileBtu.Click += new System.EventHandler(this.SelectFileBtu_Click);
            // 
            // Txt_Openfile
            // 
            this.Txt_Openfile.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Openfile.Location = new System.Drawing.Point(187, 18);
            this.Txt_Openfile.Name = "Txt_Openfile";
            this.Txt_Openfile.ReadOnly = true;
            this.Txt_Openfile.Size = new System.Drawing.Size(344, 28);
            this.Txt_Openfile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(57, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "输入文件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SelectFileBtu);
            this.panel1.Controls.Add(this.Txt_Openfile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 60);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.OrginFile_Btu);
            this.panel2.Controls.Add(this.Txt_OrginFile);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.DispalyBtu);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.ConvertBtu);
            this.panel2.Controls.Add(this.SaveFileBtu);
            this.panel2.Controls.Add(this.Txt_SaveFile);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(709, 211);
            this.panel2.TabIndex = 4;
            // 
            // DispalyBtu
            // 
            this.DispalyBtu.Location = new System.Drawing.Point(604, 172);
            this.DispalyBtu.Name = "DispalyBtu";
            this.DispalyBtu.Size = new System.Drawing.Size(100, 33);
            this.DispalyBtu.TabIndex = 9;
            this.DispalyBtu.Text = "图像显示";
            this.DispalyBtu.UseVisualStyleBackColor = true;
            this.DispalyBtu.Click += new System.EventHandler(this.DispalyBtu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_bsq);
            this.groupBox1.Controls.Add(this.radioButton_bil);
            this.groupBox1.Controls.Add(this.radioButton_bip);
            this.groupBox1.Location = new System.Drawing.Point(59, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 60);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_bsq
            // 
            this.radioButton_bsq.AutoSize = true;
            this.radioButton_bsq.Location = new System.Drawing.Point(491, 27);
            this.radioButton_bsq.Name = "radioButton_bsq";
            this.radioButton_bsq.Size = new System.Drawing.Size(60, 23);
            this.radioButton_bsq.TabIndex = 2;
            this.radioButton_bsq.TabStop = true;
            this.radioButton_bsq.Text = "bsq";
            this.radioButton_bsq.UseVisualStyleBackColor = true;
            this.radioButton_bsq.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_bil
            // 
            this.radioButton_bil.AutoSize = true;
            this.radioButton_bil.Location = new System.Drawing.Point(265, 27);
            this.radioButton_bil.Name = "radioButton_bil";
            this.radioButton_bil.Size = new System.Drawing.Size(60, 23);
            this.radioButton_bil.TabIndex = 1;
            this.radioButton_bil.TabStop = true;
            this.radioButton_bil.Text = "bil";
            this.radioButton_bil.UseVisualStyleBackColor = true;
            this.radioButton_bil.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_bip
            // 
            this.radioButton_bip.AutoSize = true;
            this.radioButton_bip.Location = new System.Drawing.Point(39, 27);
            this.radioButton_bip.Name = "radioButton_bip";
            this.radioButton_bip.Size = new System.Drawing.Size(60, 23);
            this.radioButton_bip.TabIndex = 0;
            this.radioButton_bip.TabStop = true;
            this.radioButton_bip.Text = "bip";
            this.radioButton_bip.UseVisualStyleBackColor = true;
            this.radioButton_bip.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // ConvertBtu
            // 
            this.ConvertBtu.Location = new System.Drawing.Point(252, 152);
            this.ConvertBtu.Name = "ConvertBtu";
            this.ConvertBtu.Size = new System.Drawing.Size(138, 47);
            this.ConvertBtu.TabIndex = 6;
            this.ConvertBtu.Text = "转   换";
            this.ConvertBtu.UseVisualStyleBackColor = true;
            this.ConvertBtu.Click += new System.EventHandler(this.ConvertBtu_Click);
            // 
            // SaveFileBtu
            // 
            this.SaveFileBtu.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveFileBtu.Location = new System.Drawing.Point(576, 58);
            this.SaveFileBtu.Name = "SaveFileBtu";
            this.SaveFileBtu.Size = new System.Drawing.Size(75, 28);
            this.SaveFileBtu.TabIndex = 3;
            this.SaveFileBtu.Text = "选 择";
            this.SaveFileBtu.UseVisualStyleBackColor = true;
            this.SaveFileBtu.Click += new System.EventHandler(this.SaveFileBtu_Click);
            // 
            // Txt_SaveFile
            // 
            this.Txt_SaveFile.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_SaveFile.Location = new System.Drawing.Point(187, 58);
            this.Txt_SaveFile.Name = "Txt_SaveFile";
            this.Txt_SaveFile.Size = new System.Drawing.Size(344, 28);
            this.Txt_SaveFile.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(57, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "输出文件";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "像素列数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_Column
            // 
            this.Txt_Column.Location = new System.Drawing.Point(118, 18);
            this.Txt_Column.Name = "Txt_Column";
            this.Txt_Column.ReadOnly = true;
            this.Txt_Column.Size = new System.Drawing.Size(108, 25);
            this.Txt_Column.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(249, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "波段个数";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_FIleFormat
            // 
            this.Txt_FIleFormat.Location = new System.Drawing.Point(584, 18);
            this.Txt_FIleFormat.Name = "Txt_FIleFormat";
            this.Txt_FIleFormat.ReadOnly = true;
            this.Txt_FIleFormat.Size = new System.Drawing.Size(108, 25);
            this.Txt_FIleFormat.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(482, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "解译格式";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_Row
            // 
            this.Txt_Row.Location = new System.Drawing.Point(118, 75);
            this.Txt_Row.Name = "Txt_Row";
            this.Txt_Row.ReadOnly = true;
            this.Txt_Row.Size = new System.Drawing.Size(108, 25);
            this.Txt_Row.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "像素行数";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_TM
            // 
            this.Txt_TM.Location = new System.Drawing.Point(351, 18);
            this.Txt_TM.Name = "Txt_TM";
            this.Txt_TM.ReadOnly = true;
            this.Txt_TM.Size = new System.Drawing.Size(108, 25);
            this.Txt_TM.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(249, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "数据格式";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_DataFormat
            // 
            this.Txt_DataFormat.Location = new System.Drawing.Point(351, 75);
            this.Txt_DataFormat.Name = "Txt_DataFormat";
            this.Txt_DataFormat.ReadOnly = true;
            this.Txt_DataFormat.Size = new System.Drawing.Size(108, 25);
            this.Txt_DataFormat.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.QurryInfoBtu);
            this.panel3.Controls.Add(this.Txt_DataFormat);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.Txt_TM);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.Txt_Row);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.Txt_FIleFormat);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.Txt_Column);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 119);
            this.panel3.TabIndex = 5;
            // 
            // QurryInfoBtu
            // 
            this.QurryInfoBtu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QurryInfoBtu.Location = new System.Drawing.Point(527, 75);
            this.QurryInfoBtu.Name = "QurryInfoBtu";
            this.QurryInfoBtu.Size = new System.Drawing.Size(133, 25);
            this.QurryInfoBtu.TabIndex = 13;
            this.QurryInfoBtu.Text = "从文件中获取";
            this.QurryInfoBtu.UseVisualStyleBackColor = true;
            this.QurryInfoBtu.Click += new System.EventHandler(this.QurryInfoBtu_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(2, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "文件信息";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(2, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 21);
            this.label10.TabIndex = 15;
            this.label10.Text = "格式转换";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrginFile_Btu
            // 
            this.OrginFile_Btu.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OrginFile_Btu.Location = new System.Drawing.Point(576, 9);
            this.OrginFile_Btu.Name = "OrginFile_Btu";
            this.OrginFile_Btu.Size = new System.Drawing.Size(75, 28);
            this.OrginFile_Btu.TabIndex = 10;
            this.OrginFile_Btu.Text = "加 载";
            this.OrginFile_Btu.UseVisualStyleBackColor = true;
            this.OrginFile_Btu.Click += new System.EventHandler(this.OrginFile_Btu_Click);
            // 
            // Txt_OrginFile
            // 
            this.Txt_OrginFile.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_OrginFile.Location = new System.Drawing.Point(187, 9);
            this.Txt_OrginFile.Name = "Txt_OrginFile";
            this.Txt_OrginFile.ReadOnly = true;
            this.Txt_OrginFile.Size = new System.Drawing.Size(344, 28);
            this.Txt_OrginFile.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(57, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 28);
            this.label9.TabIndex = 12;
            this.label9.Text = " 源文件";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 390);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "格式转换";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SelectFileBtu;
        private System.Windows.Forms.TextBox Txt_Openfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ConvertBtu;
        private System.Windows.Forms.Button SaveFileBtu;
        private System.Windows.Forms.TextBox Txt_SaveFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Column;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_FIleFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_Row;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_TM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_DataFormat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button QurryInfoBtu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_bil;
        private System.Windows.Forms.RadioButton radioButton_bip;
        private System.Windows.Forms.RadioButton radioButton_bsq;
        private System.Windows.Forms.Button DispalyBtu;
        private System.Windows.Forms.Button OrginFile_Btu;
        private System.Windows.Forms.TextBox Txt_OrginFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

