using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Validations;

namespace WebApi.Domain.Commands.UserCommand
{
    /// <summary>
    /// 注册一个添加 User 命令
    /// 基础抽象学生命令模型
    /// </summary>
    public class RegisterUserCommand :UserCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public RegisterUserCommand(string name, string email, DateTime birthDate, string phone, string province, string city, string county, string street)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            Province = province;
            City = city;
            County = county;
            Street = street;
        }

        // 重写基类中的 是否有效 方法
        // 主要是为了引入命令验证 RegisterUserCommandValidation。
        public override bool IsValid()
        {
            ValidationResult = new RegisterUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
