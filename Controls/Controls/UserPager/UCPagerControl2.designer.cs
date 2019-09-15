// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-15-2019
//
// ***********************************************************************
// <copyright file="UCPagerControl2.Designer.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System.Windows.Forms;

namespace Controls.UserPager
{
    /// <summary>
    /// Class UCPagerControl2.
    /// Implements the <see cref="HZH_Controls.Controls.UCPagerControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCPagerControlBase" />
    partial class UCPagerControl2
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFirst = new Button();
            this.btnPrevious = new Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.p9 = new Button();
            this.p1 = new Button();
            this.btnToPage = new Button();
            this.btnEnd = new Button();
            this.btnNext = new Button();
            this.p8 = new Button();
            this.p7 = new Button();
            this.p6 = new Button();
            this.p5 = new Button();
            this.p4 = new Button();
            this.p3 = new Button();
            this.p2 = new Button();
            this.txtPage = new TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.White;
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnFirst.ForeColor = System.Drawing.Color.Gray;
            this.btnFirst.Text = "<<";
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnFirst.Location = new System.Drawing.Point(5, 5);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.TabStop = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_BtnClick);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.Gray;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrevious.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnPrevious.Location = new System.Drawing.Point(45, 5);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 30);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Text = "";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_BtnClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.p9, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.p1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnToPage, 14, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEnd, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.p8, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.p7, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.p6, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.p5, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.p4, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.p3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.p2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrevious, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFirst, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPage, 13, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(129, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // p9
            // 
            this.p9.BackColor = System.Drawing.Color.White;
            this.p9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p9.ForeColor = System.Drawing.Color.Gray;
            this.p9.Text = "9";
            this.p9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p9.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p9.Location = new System.Drawing.Point(402, 5);
            this.p9.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p9.Name = "p9";
            this.p9.Size = new System.Drawing.Size(36, 30);
            this.p9.TabIndex = 17;
            this.p9.TabStop = false;
            this.p9.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p1.ForeColor = System.Drawing.Color.Gray;
            this.p1.Text = "1";
            this.p1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p1.Location = new System.Drawing.Point(82, 5);
            this.p1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(36, 30);
            this.p1.TabIndex = 16;
            this.p1.TabStop = false;
            this.p1.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // btnToPage
            // 
            this.btnToPage.BackColor = System.Drawing.Color.White;
            this.btnToPage.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnToPage.ForeColor = System.Drawing.Color.Gray;
            this.btnToPage.Text = "跳转";
            this.btnToPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToPage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnToPage.Location = new System.Drawing.Point(595, 5);
            this.btnToPage.Margin = new System.Windows.Forms.Padding(5);
            this.btnToPage.Name = "btnToPage";
            this.btnToPage.Size = new System.Drawing.Size(62, 30);
            this.btnToPage.TabIndex = 15;
            this.btnToPage.TabStop = false;
            this.btnToPage.Click += new System.EventHandler(this.btnToPage_BtnClick);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.White;
            this.btnEnd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnEnd.ForeColor = System.Drawing.Color.Gray;
            this.btnEnd.Text = ">>";
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnd.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnEnd.Location = new System.Drawing.Point(485, 5);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(5);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(30, 30);
            this.btnEnd.TabIndex = 13;
            this.btnEnd.TabStop = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_BtnClick);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.Gray;
            this.btnNext.Text = ">";
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnNext.Location = new System.Drawing.Point(445, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.TabIndex = 12;
            this.btnNext.TabStop = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_BtnClick);
            // 
            // p8
            // 
            this.p8.BackColor = System.Drawing.Color.White;
            this.p8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p8.ForeColor = System.Drawing.Color.Gray;
            this.p8.Text = "8";
            this.p8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            this.p8.Location = new System.Drawing.Point(362, 5);
            this.p8.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p8.Name = "p8";
            this.p8.Size = new System.Drawing.Size(36, 30);
            this.p8.TabIndex = 8;
            this.p8.TabStop = false;
            this.p8.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // p7
            // 
            this.p7.BackColor = System.Drawing.Color.White;
            this.p7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p7.ForeColor = System.Drawing.Color.Gray;
            this.p7.Text = "7";
            this.p7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p7.Location = new System.Drawing.Point(322, 5);
            this.p7.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(36, 30);
            this.p7.TabIndex = 7;
            this.p7.TabStop = false;
            this.p7.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // p6
            // 
            this.p6.BackColor = System.Drawing.Color.White;
            this.p6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p6.ForeColor = System.Drawing.Color.Gray;
            this.p6.Text = "6";
            this.p6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            this.p6.Location = new System.Drawing.Point(282, 5);
            this.p6.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(36, 30);
            this.p6.TabIndex = 6;
            this.p6.TabStop = false;
            this.p6.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.White;
            this.p5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p5.ForeColor = System.Drawing.Color.Gray;
            this.p5.Text = "5";
            this.p5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            this.p5.Location = new System.Drawing.Point(242, 5);
            this.p5.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p5.Name = "p5";

            this.p5.Size = new System.Drawing.Size(36, 30);
            this.p5.TabIndex = 5;
            this.p5.TabStop = false;
            this.p5.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.Color.White;
            this.p4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p4.ForeColor = System.Drawing.Color.Gray;
            this.p4.Text = "4";
            this.p4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p4.Location = new System.Drawing.Point(202, 5);
            this.p4.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(36, 30);
            this.p4.TabIndex = 4;
            this.p4.TabStop = false;
            this.p4.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.White;
            this.p3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p3.ForeColor = System.Drawing.Color.Gray;
            this.p3.Text = "3";
            this.p3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            this.p3.Location = new System.Drawing.Point(162, 5);
            this.p3.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p3.Name = "p3";

            this.p3.Size = new System.Drawing.Size(36, 30);
            this.p3.TabIndex = 3;
            this.p3.TabStop = false;
            this.p3.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.p2.ForeColor = System.Drawing.Color.Gray;
            this.p2.Text = "2";
            this.p2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p2.Location = new System.Drawing.Point(122, 5);
            this.p2.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(36, 30);
            this.p2.TabIndex = 2;
            this.p2.TabStop = false;
            this.p2.Click += new System.EventHandler(this.page_BtnClick);
            // 
            // txtPage
            // 
            //this.txtPage.BackColor = System.Drawing.Color.Transparent;
            this.txtPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPage.MaxLength = 2;
            this.txtPage.BackColor = System.Drawing.Color.Empty;
            this.txtPage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPage.ForeColor = System.Drawing.Color.Gray;
            this.txtPage.Text = "";
            this.txtPage.Focus();
            this.txtPage.Location = new System.Drawing.Point(524, 5);
            this.txtPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPage.Name = "txtPage";
            this.txtPage.Padding = new System.Windows.Forms.Padding(5);
            this.txtPage.BackColor = System.Drawing.Color.Silver;
            this.txtPage.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPage.Text = "页码";
            this.txtPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtPage.Width = 1;
            this.txtPage.Size = new System.Drawing.Size(62, 30);
            this.txtPage.TabIndex = 14;
            // 
            // UCPagerControl2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCPagerControl2";
            this.Size = new System.Drawing.Size(921, 41);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The BTN first
        /// </summary>
        private Button btnFirst;
        /// <summary>
        /// The BTN previous
        /// </summary>
        private Button btnPrevious;
        /// <summary>
        /// The table layout panel1
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        /// <summary>
        /// The BTN end
        /// </summary>
        private Button btnEnd;
        /// <summary>
        /// The BTN next
        /// </summary>
        private Button btnNext;
        /// <summary>
        /// The p8
        /// </summary>
        private Button p8;
        /// <summary>
        /// The p7
        /// </summary>
        private Button p7;
        /// <summary>
        /// The p6
        /// </summary>
        private Button p6;
        /// <summary>
        /// The p5
        /// </summary>
        private Button p5;
        /// <summary>
        /// The p4
        /// </summary>
        private Button p4;
        /// <summary>
        /// The p3
        /// </summary>
        private Button p3;
        /// <summary>
        /// The p2
        /// </summary>
        private Button p2;
        /// <summary>
        /// The BTN to page
        /// </summary>
        private Button btnToPage;
        /// <summary>
        /// The text page
        /// </summary>
        private TextBox txtPage;
        /// <summary>
        /// The p9
        /// </summary>
        private Button p9;
        /// <summary>
        /// The p1
        /// </summary>
        private Button p1;
    }
}
