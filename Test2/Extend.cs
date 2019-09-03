using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public static class TransExpV2
    {
        private static Func<TIn, TOut> GetFunc<TIn, TOut>()
        {
            string name = string.Empty;
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                if (!item.CanWrite)
                {
                    continue;
                }

                var columnProperty = item.GetCustomAttribute<PropertyAttribute>(true);
                if (columnProperty != null && columnProperty.IsClass)
                    name = columnProperty.Alias;
                else
                    name = item.Name;
                MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });
            return lambda.Compile();
        }

        public static TOut Trans<TIn, TOut>(this TIn tIn)
        {
            return GetFunc<TIn, TOut>()(tIn);
        }
        public static IEnumerable<TOut> TransList<TIn, TOut>(this List<TIn> tIn)
        {
            foreach (var item in tIn)
            {
                yield return item.Trans<TIn, TOut>();
            }

        }

    }

    public static class TransExpV2List
    {
        public static IEnumerable<TOut> Trans<TIn, TOut>(this List<TIn> tIn)
        {
            foreach (var item in tIn)
            {
                yield return item.Trans<TIn, TOut>();
            }
        }
    }
}
