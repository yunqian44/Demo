namespace Controls
{
    partial class Form1
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
            this.gv = new Controls.DataGridView.UCDataGridView();
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
            this.gv.RowType = typeof(Controls.DataGridView.UCDataGridViewRow);
            this.gv.Size = new System.Drawing.Size(800, 450);
            this.gv.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DataGridView.UCDataGridView gv;
    }
}