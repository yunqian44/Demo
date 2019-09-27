﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Events;

namespace WebApi.Core
{
    /// <summary>
    /// 抽象命令基类
    /// </summary>
    public abstract class Command : Message
    {
        //时间戳
        public DateTime Timestamp { get; private set; }

        //验证结果，需要引用FluentValidation
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        //定义抽象方法，是否有效
        public abstract bool IsValid();
    }
}
