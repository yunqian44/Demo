﻿namespace Test
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
            this.gv = new Controls.Controls.DataGridView.UCDataGridView();
            this.SuspendLayout();
            // 
            // gv
            // 
            this.gv.Columns = null;
            this.gv.DataSource = null;
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.IsCloseAutoHeight = false;
            this.gv.IsShowCheckBox = false;
            this.gv.Location = new System.Drawing.Point(0, 0);
            this.gv.Name = "gv";
            this.gv.RowHeight = 40;
            this.gv.RowType = typeof(Controls.Controls.DataGridView.UCDataGridViewRow);
            this.gv.Size = new System.Drawing.Size(803, 419);
            this.gv.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(803, 419);
            this.Controls.Add(this.gv);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Controls.DataGridView.UCDataGridView gv;
    }
}

