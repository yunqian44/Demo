using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp
{
    #region 身份证类
    [EnitityMapping(ClassName = "words_result")]
    public class IdCardInfo
    {
        private string _address;
        [EnitityMapping(PropertyName = "住址")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _idCard;
        [EnitityMapping(PropertyName = "公民身份号码")]
        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }

        public string _name;
        [EnitityMapping(PropertyName = "姓名")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string _gender;
        [EnitityMapping(PropertyName = "性别")]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string _nation;
        [EnitityMapping(PropertyName = "民族")]
        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }


        private string _birthday;
        [EnitityMapping(PropertyName = "出生")]
        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }


    }
    #endregion
}
