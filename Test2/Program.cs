using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            //Regex rx = new Regex(@"1[0-9]{10}|([0-9]{3,4}|[0-9]{3,4}-)[0-9]{7,8}",

            //    RegexOptions.Compiled | RegexOptions.IgnoreCase);
            ////原字符串
            //string text = "Hello wold 13088973729 Good morning 1317878 The end";
            ////获得匹配项集合
            //MatchCollection matches = rx.Matches(text);
            //Console.WriteLine("{0} matches found.", matches.Count);
            //int count = 0;
            //foreach (Match match in matches)
            //{
            //    string word = match.Groups["word"].Value;

            //    //删除匹配项
            //    text = text.Remove(match.Index - count, match.Length);
            //    count += match.Length;
            //}
            //Console.WriteLine(text);
            //Console.ReadKey(); 
            #endregion

            #region MyRegion
            //int? i = null;
            //Console.WriteLine(i.GetValueOrDefault());



            //List<Person> list = new List<Person>();
            //list.Add(new Person { Name = "张三", Remark = "男人，程序员" });
            //list.Add(new Person { Name = "李四", Remark = "男人，程序员" });
            //list.Add(new Person { Name = "王武", Remark = "女人，农民" });


            //var ti = list.Where(u => u.Remark.Contains("程序员"));
            //foreach (var item in ti)
            //{
            //    Console.WriteLine(item.Name + "----" + item.Remark);
            //}


            //var props = typeof(Person).GetProperties();

            //foreach (var prop in props)
            //{
            //    Console.WriteLine(prop.PropertyType);
            //} 
            #endregion

            #region MyRegion
            //var i=  Edit(AppEnum.app);

            //var i = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            //var i = Math.Ceiling(2.24);

            //Console.WriteLine(i); 
            #endregion


            List<CityInfo> cityInfo = new List<CityInfo>();
            //cityInfo.Add(new CityInfo() { FromCityId = 1, ToCityId = 1 });
            //cityInfo.Add(new CityInfo() { FromCityId = 1, ToCityId = 1 });
            //cityInfo.Add(new CityInfo() { FromCityId = 1, ToCityId = 1 });
            //cityInfo.Add(new CityInfo() { FromCityId = 2, ToCityId = 2 });
            //cityInfo.Add(new CityInfo() { FromCityId = 2, ToCityId = 2 });
            //cityInfo.Add(new CityInfo() { FromCityId = 3, ToCityId = 3 });
            //cityInfo.Add(new CityInfo() { FromCityId = 3, ToCityId = 3 });

            var ls = from ps in cityInfo
                     group ps by new
                     {
                         ps.FromCityId,
                         ps.ToCityId
                     } into g
                     select new { FromCityId = g.Key.FromCityId, ToCityId = g.Key.ToCityId, Type = 1, StatisticNumber = g.Count() };

            var temp = ls.ToList();
            Console.ReadKey();

        }

        static int Edit(object status)
        {
            if (status is AppEnum)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }

        public string Remark { get; set; }

        public DateTime yeer { get; set; }

        public Guid guid { get; set; }

        public int age { get; set; }

        public AppEnum sds { get; set; }
    }

    public class CityInfo
    {
        public int ToCityId { get; set; }

        public int FromCityId { get; set;}
    }

    public enum AppEnum
    {
        app=1,
        web=2
    }

    public enum StatusEnum 
    {
        ok=1,
        fail=2
    }
}
