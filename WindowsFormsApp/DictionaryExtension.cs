using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WindowsFormsApp
{
    public static class DictionaryExtension
    {
        public static object ToEntity(this IDictionary<string, object> source, Type type)
        {
            var instance = Activator.CreateInstance(type);
            //取属性上的自定义特性
            foreach (PropertyInfo propInfo in type.GetProperties())
            {
                object[] objAttrs = propInfo.GetCustomAttributes(typeof(EnitityMappingAttribute), true);

                if (propInfo.CanWrite)
                {
                    if (objAttrs.Length > 0)
                    {
                        try
                        {
                            EnitityMappingAttribute attr = objAttrs[0] as EnitityMappingAttribute;
                            if (attr != null)
                            {
                                var val = (JObject)source[attr.PropertyName];
                                propInfo.SetValue(instance, Convert.ChangeType(val["words"], propInfo.PropertyType), null);
                                //listColumnName.Add(attr.PropertyName); //列名
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            return instance;
        }

        public static T ToEntity<T>(this IDictionary<string, object> source) where T : class, new()
        {
            return ToEntity(source, typeof(T)) as T;
        }
    }
}
