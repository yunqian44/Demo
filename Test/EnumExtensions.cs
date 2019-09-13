using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// 枚举的扩展方法
    /// </summary>
    public static class EnumExtensions
    {
        public static string Code(this Enum e)
        {
            return e.ToString();
        }

        public static string Ordinal(this Enum e)
        {
            int a = Convert.ToInt32(e);
            return a.ToString();
        }

        /// <summary>
        /// 获取枚举值的描述信息
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetDescription<TSource>(this TSource source)
            where TSource : struct
        {
            var field = source.GetType().GetField(source.ToString());
            if (field != null)
            {
                var descript = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descript != null && descript.Length > 0)
                {
                    return (descript[0] as DescriptionAttribute).Description;
                }
            }
            return source.ToString();
        }

        /// <summary>
        /// 获取枚举值的描述信息
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<SysCode> GetDescription<TSource>(Func<object, string> func)
            where TSource : struct
        {
            var fields = typeof(TSource).GetFields();
            foreach (var field in fields)
            {
                if (field != null)
                {
                    var descript = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (descript != null && descript.Length > 0)
                    {
                        var value = string.Empty;
                        if (func != null)
                        {
                            value = func(field.Name);
                        }
                        else
                        {
                            value=field.Name;
                        }
                        var name = (descript[0] as DescriptionAttribute).Description;
                        yield return new SysCode { CodeId = value, CodeName = name };
                    }
                }
            }
        }
    }
}
