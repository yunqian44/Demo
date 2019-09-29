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
using UC.Controls.Controls.TextBox;
using UC.Controls.FormControls;
using WebApi.BLL;
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
            var name = txtUserName.InputText;
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
            RegisterUserCommand registerStudentCommand = new RegisterUserCommand(userViewModel.Name, userViewModel.Email, userViewModel.BirthDate, userViewModel.Phone, userViewModel.Province, userViewModel.City, userViewModel.County, userViewModel.Street);
            if (!registerStudentCommand.IsValid())
            {
                FrmAlert.Alert(this, registerStudentCommand.ValidationResult, sss);
            }
            UserService userService = new UserService();
            userService.Add(userViewModel);
            #region MyRegion
            ////添加命令验证

            ////如果命令无效，证明有错误
            //if (!registerStudentCommand.IsValid())
            //{
            //    List<string> errorInfo = new List<string>();

            //    //FrmAlert.Alert(this, registerStudentCommand.ValidationResult,(a)=> { this.ActiveControl = (UCTextBox)a; });
            //    //获取到错误，请思考这个Result从哪里来的
            //    foreach (var error in registerStudentCommand.ValidationResult.Errors)
            //    {
            //        //errorInfo.Add(error.ErrorMessage);
            //        //FrmAlert.Alert(this, error.ErrorMessage);
            //    }
            //    //对错误进行记录，还需要抛给前台
            //    var dsd = errorInfo;
            //} 
            #endregion
        }

        private void sss(object S)
        {
            this.ActiveControl = (UCTextBox)S;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }
    }
}
