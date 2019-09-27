using Controls.FormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                City=city,
                Street=street,
                County=county,
                Email=email,
                Name=name,
                Phone=phone,
                Province=provence
            };

            //添加命令验证
            RegisterUserCommand registerStudentCommand = new RegisterUserCommand(userViewModel.Name, userViewModel.Email, userViewModel.BirthDate, userViewModel.Phone, userViewModel.Province,userViewModel.City,userViewModel.County,userViewModel.Street);

            //如果命令无效，证明有错误
            if (!registerStudentCommand.IsValid())
            {
                List<string> errorInfo = new List<string>();
                //获取到错误，请思考这个Result从哪里来的 
                foreach (var error in registerStudentCommand.ValidationResult.Errors)
                {
                    //errorInfo.Add(error.ErrorMessage);
                    FrmToastr.ShowToastrWarning(this,error.ErrorMessage);
                }
                //对错误进行记录，还需要抛给前台
                var dsd= errorInfo;
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }
    }
}
