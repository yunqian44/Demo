using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    /// <summary>
    /// 学生对象
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required("参数必填")]
        [StringLength(2)]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 购买方式
        /// </summary>
        public BuyTypeEnum? BuyMode { get; set; }

        public DateTime Year { get; set; }

        public List<Image> Image { get; set; }
    }

    public enum BuyTypeEnum
    {
        /// <summary>
        /// 微信
        /// </summary>
        WeChat = 1,

        /// <summary>
        ///  余额
        /// </summary>
        Balance = 2,
    }

    public class Image
    {
        public int Type { get; set; }

        public string ImagePath { get; set; }

        public int Id { get; set; }
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
        /// 学生信息
        /// </summary>
        public UserInfo Student { get; set; }

    }
}