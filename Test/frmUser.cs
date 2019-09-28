using Controls.FormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UC.Controls.FormControls;
using WebApi.BLL.ViewModel;
using WebApi.Domain.Commands.UserCommand;

namespace Test
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtUserName.Text;
            var email = txtEmail.Text;
            var phone = txtPhone.Text;
            var birthDay = dtBirthday.Value;
            var provence = txtProvince.Text;
            var city = txtCity.Text;
            var county = txtCounty.Text;
            var street = txtStreet.Text;

            var userViewModel = new UserViewModel()
            {
                BirthDate = birthDay,
                City = city,
                Street = street,
                County = county,
                Email = email,
                Name = name,
                Phone = phone,
                Province = provence
            };

            //添加命令验证
            RegisterUserCommand registerStudentCommand = new RegisterUserCommand(userViewModel.Name, userViewModel.Email, userViewModel.BirthDate, userViewModel.Phone, userViewModel.Province, userViewModel.City, userViewModel.County, userViewModel.Street);

            //如果命令无效，证明有错误
            if (!registerStudentCommand.IsValid())
            {
                List<string> errorInfo = new List<string>();
                //获取到错误，请思考这个Result从哪里来的 
                foreach (var error in registerStudentCommand.ValidationResult.Errors)
                {
                    //errorInfo.Add(error.ErrorMessage);
                    FrmAlert.Alert(this, error.ErrorMessage);
                }
                //对错误进行记录，还需要抛给前台
                var dsd = errorInfo;
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Rectangle clientRectangle = base.ClientRectangle;
            graphicsPath.AddArc(0, 0, 24, 24, 180f, 90f);
            graphicsPath.AddArc(clientRectangle.Width - 24 - 1, 0, 24, 24, 270f, 90f);
            graphicsPath.AddArc(clientRectangle.Width - 24 - 1, clientRectangle.Height - 24 - 1, 24, 24, 0f, 90f);
            graphicsPath.AddArc(0, clientRectangle.Height - 24 - 1, 24, 24, 90f, 90f);
            graphicsPath.CloseFigure();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            Color rectColor = Color.Red;
            Pen pen = new Pen(rectColor, 2.00f);
            e.Graphics.DrawPath(pen, graphicsPath);

            base.OnPaint(e);

        }

    }
}
