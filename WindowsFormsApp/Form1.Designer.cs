namespace WindowsFormsApp
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ImageAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.TextBox();
            this.IdCard = new System.Windows.Forms.TextBox();
            this.Birthday = new System.Windows.Forms.TextBox();
            this.Sex = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Nation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片链接:";
            // 
            // ImageAddress
            // 
            this.ImageAddress.Location = new System.Drawing.Point(106, 12);
            this.ImageAddress.Multiline = true;
            this.ImageAddress.Name = "ImageAddress";
            this.ImageAddress.Size = new System.Drawing.Size(441, 47);
            this.ImageAddress.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(572, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "识别";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(12, 76);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(480, 300);
            this.ImageBox.TabIndex = 3;
            this.ImageBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(557, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(527, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "身份证号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(512, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "出生年月日:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(557, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "性别:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(527, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "家庭地址:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(557, 413);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "民族:";
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(621, 90);
            this.Name.Multiline = true;
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(250, 35);
            this.Name.TabIndex = 10;
            // 
            // IdCard
            // 
            this.IdCard.Location = new System.Drawing.Point(621, 149);
            this.IdCard.Multiline = true;
            this.IdCard.Name = "IdCard";
            this.IdCard.Size = new System.Drawing.Size(250, 35);
            this.IdCard.TabIndex = 11;
            // 
            // Birthday
            // 
            this.Birthday.Location = new System.Drawing.Point(621, 218);
            this.Birthday.Multiline = true;
            this.Birthday.Name = "Birthday";
            this.Birthday.Size = new System.Drawing.Size(250, 35);
            this.Birthday.TabIndex = 12;
            // 
            // Sex
            // 
            this.Sex.Location = new System.Drawing.Point(621, 277);
            this.Sex.Multiline = true;
            this.Sex.Name = "Sex";
            this.Sex.Size = new System.Drawing.Size(250, 35);
            this.Sex.TabIndex = 13;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(621, 342);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(250, 35);
            this.Address.TabIndex = 14;
            // 
            // Nation
            // 
            this.Nation.Location = new System.Drawing.Point(621, 401);
            this.Nation.Multiline = true;
            this.Nation.Name = "Nation";
            this.Nation.Size = new System.Drawing.Size(250, 35);
            this.Nation.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 450);
            this.Controls.Add(this.Nation);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.Sex);
            this.Controls.Add(this.Birthday);
            this.Controls.Add(this.IdCard);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ImageAddress);
            this.Controls.Add(this.label1);
            //this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ImageAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.TextBox IdCard;
        private System.Windows.Forms.TextBox Birthday;
        private System.Windows.Forms.TextBox Sex;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Nation;
    }
}

