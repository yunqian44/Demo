using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    /// <summary>
    /// 学生对象
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }
    }

    /// <summary>
    /// 老师对象
    /// </summary>
    public class Teacher 
    {
        /// <summary>
        /// 老师姓名
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public UserInfo children { get; set; }
    }
}