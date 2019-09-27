using Controls.FormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            FrmToastr.ShowToastrError(this, "Error提示信息");
            FrmToastr.ShowToastrInfo(this, "Info提示信息");
            FrmToastr.ShowToastrSuccess(this, "Success提示信息");
            FrmToastr.ShowToastrWarning(this, "Warning提示信息");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.ShowDialog();
        }
    }
}
