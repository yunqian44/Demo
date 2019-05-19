using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace WebApi.Models
{
    public class MyLoginCheckFilterAttribute: ActionFilterAttribute
    {
        private static List<Type> _types;

        public MyLoginCheckFilterAttribute()
        {
            if (_types == null)
            {
                _types = new List<Type>();
                var assembilies = Assemblies.GetAssemblies();
                foreach (var assembly in assembilies)
                {
                    _types.AddRange(assembly.GetTypes().Where(o => o.IsPublic));
                }
            }
        }

        public bool IsCheck { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsCheck)
            {
                var paramsDic = filterContext.ActionParameters;
                for (int i = 0; i < paramsDic.Count; i++)
                {
                    var paramsValues = paramsDic.Values;
                    foreach (var item in paramsValues)
                    {
                        var typeName = item.GetType().ToString();
                    }
                    GetType();
                }
            }
            base.OnActionExecuting(filterContext);
        }

        public static Type GetType(string typeName)
        {
            if (typeName.IndexOf(',') > 0)
            {
                typeName = typeName.Split(',')[0];
            }
            foreach (var type in _types)
            {
                if (type.FullName.Equals(typeName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return type;
                }
            }
            return null;
        }


    }

    public static class DictionaryExtension
    {
        public static object ToEntity(this IDictionary<string, object> source, Type type)
        {
            if (source.IsNullOrEmpty()) return null;
            //FastType fastType = FastType.Get(type);
            var instance = Activator.CreateInstance(type);
            //foreach (var p in fastType.Setters)
            //{
            //    if (p.Name.IsNullOrEmpty()) continue;
            //    if (source.Keys.Contains(p.Name))
            //    {
            //        p.SetValue(instance, source[p.Name].ConvertToType(p.Type));
            //    }
            //}
            return instance;
        }

        public static List<T> ToEntities<T>(this IList<IDictionary<string, object>> source) where T : class, new()
        {
            var list = new List<T>();
            //source.ForEach(o =>
            //{
            //    list.Add(o.ToEntity<T>());
            //});
            return list;
        }
    }

    public static class Assemblies
    {
        private static readonly ReadOnlyCollection<Assembly> _all = null;

        static Assemblies()
        {
            List<Assembly> all = new List<Assembly>();
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                //这里只加载了当前运行所需要的程序集，未必是全部。
                AddAssembly(all, a);
            }
            if (HttpContext.Current != null)
            {
                foreach (Assembly a in BuildManager.GetReferencedAssemblies())
                {
                    if (!all.Any(loaded =>
                        AssemblyName.ReferenceMatchesDefinition(loaded.GetName(), a.GetName())))
                    {
                        AddAssembly(all, a);
                    }
                }
                string binDir = HttpRuntime.BinDirectory;
                if (!string.IsNullOrEmpty(binDir))
                {
                    string[] files = Directory.GetFiles(binDir, "*.dll", SearchOption.TopDirectoryOnly);
                    foreach (string file in files)
                    {
                        if (file.StartsWith("WebApi", StringComparison.OrdinalIgnoreCase))
                        {
                            AssemblyName name = AssemblyName.GetAssemblyName(file);
                            Assembly a = Assembly.Load(name);
                            if (!all.Any(loaded =>
                                AssemblyName.ReferenceMatchesDefinition(loaded.GetName(), name)))
                            {
                                AddAssembly(all, a);
                            }
                        }
                    }
                }
            }
            else
            {
                //为了单元测试
                var dir = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(dir))
                {
                    var dirInfo = new DirectoryInfo(dir);
                    var files = dirInfo.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
                    foreach (var file in files)
                    {
                        if (file.Name.StartsWith("WebApi", StringComparison.OrdinalIgnoreCase))
                        {
                            AssemblyName name = AssemblyName.GetAssemblyName(file.Name);
                            Assembly a = Assembly.Load(name);
                            if (!all.Any(loaded =>
                                AssemblyName.ReferenceMatchesDefinition(loaded.GetName(), name)))
                            {
                                AddAssembly(all, a);
                            }
                        }
                    }
                }
            }
            _all = new ReadOnlyCollection<Assembly>(all);
        }

        private static void AddAssembly(List<Assembly> all, Assembly a)
        {
            if (a.FullName.StartsWith("WebApi", StringComparison.OrdinalIgnoreCase))
            {
                all.Add(a);
            }
        }

        public static IEnumerable<Assembly> GetAssemblies()
        {
            return _all;
        }
    }

    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count == 0;
        }
    }

    #region 表达树对象赋值
    public static class TransExpV2<TIn, TOut>
    {
        private static readonly Func<TIn, TOut> cache = GetFunc();
        private static Func<TIn, TOut> GetFunc()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "instance");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                if (!item.CanWrite)
                {
                    continue;
                }
                MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });
            return lambda.Compile();
        }

        public static TOut Trans(TIn tIn)
        {
            return cache(tIn);
        }
    }

    public class TransExpV2List<TIn, TOut> where TIn : class, new() where TOut : class, new()
    {
        public static IEnumerable<TOut> Trans(List<TIn> tIn)
        {
            foreach (var item in tIn)
            {
                yield return TransExpV2<TIn, TOut>.Trans(item);
            }
        }
    }
    #endregion

}