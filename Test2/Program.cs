using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;

namespace Test2
{
    public delegate int AddDelegate(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            #region 动态代理
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

            #region 发射赋值
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

            #region 类型转化
            //var i=  Edit(AppEnum.app);

            //var i = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            //var i = Math.Ceiling(2.24);

            //Console.WriteLine(i); 
            #endregion

            #region Linq
            //List<CityInfo> cityInfo = new List<CityInfo>();
            //cityInfo.Add(new CityInfo() { FromCityId = 1, ToCityId = 1, Count = 2 });
            //cityInfo.Add(new CityInfo() { FromCityId = 1, ToCityId = 1, Count = 4 });
            //cityInfo.Add(new CityInfo() { FromCityId = 1, ToCityId = 1, Count = 5 });
            //cityInfo.Add(new CityInfo() { FromCityId = 2, ToCityId = 2, Count = 6 });
            //cityInfo.Add(new CityInfo() { FromCityId = 2, ToCityId = 2, Count = 7 });
            //cityInfo.Add(new CityInfo() { FromCityId = 3, ToCityId = 3, Count = 8 });
            //cityInfo.Add(new CityInfo() { FromCityId = 3, ToCityId = 3, Count = 9 });

            //var ls = from ps in cityInfo
            //         group ps by new
            //         {
            //             ps.FromCityId,
            //             ps.ToCityId
            //         } into g
            //         select new { FromCityId = g.Key.FromCityId, ToCityId = g.Key.ToCityId, Type = 1, StatisticNumber = g.Sum(u => u.Count) };

            //var temp = ls.ToList();

            #endregion

            #region 特性类

            #endregion

            #region 动态反射

            #endregion

            #region 深度赋值

            #endregion

            #region 判断逻辑
            //var a = 1;
            //if (a == 1 && a == 2 && a == 3)
            //{
            //    Console.WriteLine("第一名");
            //}
            //else if (a == 4 && a == 5 && a == 6)
            //{
            //    Console.WriteLine("第二名");
            //} 
            #endregion

            #region 委托
            //AddDelegate model = new AddDelegate(Add);
            //var n = model(10, 20);
            //Console.WriteLine(n);
            #endregion

            #region 反射生成对象
            //List<CityInfo> city = new List<CityInfo>();
            //city.Add(new CityInfo() { FromCityId = 1, ToCityId = 2, Count = 3 });
            //city.Add(new CityInfo() { FromCityId = 3, ToCityId = 4, Count = 5 });



            //EntityDataSource entity = new EntityDataSource("Test2.Person");
            //IDictionary<string, object> obj = new Dictionary<string, object>();
            //obj.Add("Name", "张三");
            //obj.Add("Age", 23);
            //obj.Add("bool", false);
            //obj.Add("CityList", city);
            //obj.Add("City", new CityInfo() { FromCityId = 6, ToCityId = 7, Count = 8 });




            ////var service = typeof(Person);
            //entity.Insert(obj);
            //Console.WriteLine(JsonConvert.SerializeObject(obj));


            //Person p = new Person();
            //p.Age = 21;
            //p.Name = "张三";
            //p.Yeer = DateTime.Now.AddYears(-10).Date;
            //p.CityList = city;


            //Console.WriteLine(JsonConvert.SerializeObject(p));


            #endregion

            #region 表达树对象赋值
            List<Person> list = new List<Person>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new Person()
                {
                    Ads = i % 2 == 1 ? AppEnum.app : AppEnum.web,
                    Age = i,
                    Guid = Guid.NewGuid(),
                    Name = "张三" + i,
                    Remark = "测试" + i,
                    Yeer = DateTime.Now.AddDays(i),
                });
            }

            List<Children> model1;
            Console.WriteLine(DateTime.Now);
            CodeTimer.Time("AutoCopyList", 10000, () =>
            {
                var modelList = AutoCopyList<Person, Children>(list);
                model1 = modelList.ToList();
            });
            Console.WriteLine(DateTime.Now);
            List<Children> model2;
            Console.WriteLine(DateTime.Now);
            //model6 = list.TransList<Person, Children>().ToList();
            CodeTimer.Time("TransExpV2", 10000, () =>
            {
                //var modelList = list.TransList<Person, Children>().ToList();
                var modelList = TransExpV2List<Person, Children>.Trans(list);
                model2 = modelList.ToList();
            });
            Console.WriteLine(DateTime.Now);

            List<Children> model3;
            Console.WriteLine(DateTime.Now);
            //model6 = list.TransList<Person, Children>().ToList();
            CodeTimer.Time("扩展方法", 10000, () =>
            {
                var modelList = list.TransList<Person, Children>().ToList();
                //var modelList = TransExpV2List<Person, Children>.Trans(list);
                model3 = modelList.ToList();
            });
            Console.WriteLine(DateTime.Now);
            #endregion

            #region 表达树，反射，等等方法测试
            //// 调用的目标实例。
            //var instance = new StubClass("张三");



            //var ss = typeof(StubClass);

            //var tt = instance.GetType();
            //// 使用反射找到的方法。
            ////var method = typeof(StubClass).GetMethod(nameof(StubClass.Test), new[] { typeof(int) });
            //var method = typeof(StubClass).GetMethod("Test", new[] { typeof(int) });
            //// 将反射找到的方法创建一个委托。
            //var func = InstanceMethodBuilder<int, string>.CreateInstanceMethod(instance, method);

            //// 跟被测方法功能一样的纯委托。
            //Func<int, int> pureFunc = value => value;

            //// 测试次数。
            //var count = 10000000;

            //// 直接调用。
            //var watch = new Stopwatch();
            //watch.Start();
            //for (var i = 0; i < count; i++)
            //{
            //    var result = instance.Test(5);
            //}

            //watch.Stop();
            //Console.WriteLine($"{watch.Elapsed} - {count} 次 - 直接调用");

            //// 使用同样功能的 Func 调用。
            //watch.Restart();
            //for (var i = 0; i < count; i++)
            //{
            //    var result = pureFunc(5);
            //}

            //watch.Stop();
            //Console.WriteLine($"{watch.Elapsed} - {count} 次 - 使用同样功能的 Func 调用");

            //// 使用反射创建出来的委托调用。
            //watch.Restart();
            //for (var i = 0; i < count; i++)
            //{
            //    var result = func(i);
            //}

            //watch.Stop();
            //Console.WriteLine($"{watch.Elapsed} - {count} 次 - 使用反射创建出来的委托调用");

            //// 使用反射得到的方法缓存调用。
            //watch.Restart();
            //for (var i = 0; i < count; i++)
            //{
            //    var result = method.Invoke(instance, new object[] { 5 });
            //}

            //watch.Stop();
            //Console.WriteLine($"{watch.Elapsed} - {count} 次 - 使用反射得到的方法缓存调用");

            //// 直接使用反射调用。
            //watch.Restart();
            //for (var i = 0; i < count; i++)
            //{
            //    var result = typeof(StubClass).GetMethod(nameof(StubClass.Test), new[] { typeof(int) })
            //        ?.Invoke(instance, new object[] { 5 });
            //}

            //watch.Stop();
            //Console.WriteLine($"{watch.Elapsed} - {count} 次 - 直接使用反射调用");
            #endregion

            #region 抽奖随机
            //List<Prize> prizes = new List<Prize>();
            //prizes.Add(new Prize() { Key = "电脑", Poll = 1 });
            //prizes.Add(new Prize() { Key = "机柜", Poll = 2 });
            //prizes.Add(new Prize() { Key = "鼠标", Poll = 3 });
            //prizes.Add(new Prize() { Key = "谢谢惠顾", Poll = 5 });

            //string lp1 = Prize.LunkyBox(prizes, 10);
            //Console.WriteLine(lp1);
            #endregion

            //string lp2 = Prize.Roulette(prizes);
            //Console.WriteLine(lp2);

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.WriteLine(i.ToString("D4"));
            //    //Console.WriteLine("{0:D4}", i);  //00025
            //}

            Console.ReadKey();
        }


        #region 抽奖
        /// <summary>
        /// 抽奖
        /// </summary>
        public class Prize
        {
            /// <summary>
            /// 奖品关键字
            /// </summary>
            public string Key { get; set; }

            /// <summary>
            /// 权重/数量
            /// </summary>
            public int Poll { get; set; }

            /// <summary>
            /// 中奖区间
            /// </summary>
            class Area
            {
                /// <summary>
                /// 奖品关键字
                /// </summary>
                public string Key { get; set; }

                /// <summary>
                /// 开始索引位置
                /// </summary>
                public int Start { get; set; }

                /// <summary>
                /// 截止索引位置
                /// </summary>
                public int Over { get; set; }
            }

            /// <summary>
            /// 随机种子
            /// </summary>
            static Random Rand = new Random((int)DateTime.Now.Ticks);


            /// <summary>
            /// 轮盘抽奖，权重值(在轮盘中占的面积大小)为中奖几率
            /// </summary>
            /// <param name="prizeList">礼品列表（如果不是百分百中奖则轮空需要加入到列表里面）</param>
            /// <returns></returns>
            public static string Roulette(List<Prize> prizeList)
            {
                if (prizeList == null || prizeList.Count == 0) return string.Empty;
                if (prizeList.Any(x => x.Poll < 1)) throw new ArgumentOutOfRangeException("poll权重值不能小于1");
                if (prizeList.Count == 1) return prizeList[0].Key; //只有一种礼品

                Int32 total = prizeList.Sum(x => x.Poll); //权重和               
                if (total > 1000) throw new ArgumentOutOfRangeException("poll权重和不能大于1000"); //数组存储空间的限制。最多一千种奖品（及每种奖品的权重值都是1）

                List<int> speed = new List<int>(); //随机种子
                for (int i = 0; i < total; i++) speed.Add(i);

                int pos = 0;
                Dictionary<int, string> box = new Dictionary<int, string>();
                foreach (Prize p in prizeList)
                {
                    for (int c = 0; c < p.Poll; c++) //权重越大所占的面积份数就越多
                    {
                        pos = Prize.Rand.Next(speed.Count); //取随机种子坐标
                        box[speed[pos]] = p.Key; //乱序 礼品放入索引是speed[pos]的箱子里面
                        speed.RemoveAt(pos); //移除已抽取的箱子索引号
                    }
                }
                return box[Prize.Rand.Next(total)];
            }

            /// <summary>
            /// 奖盒抽奖，每个参与者对应一个奖盒，多少人参与就有多少奖盒
            /// </summary>
            /// <param name="prizeList">礼品列表</param>
            /// <param name="peopleCount">参与人数</param>
            /// <returns></returns>
            public static string LunkyBox(List<Prize> prizeList, int peopleCount)
            {
                if (prizeList == null || prizeList.Count == 0) return string.Empty;
                if (prizeList.Any(x => x.Poll < 1)) throw new ArgumentOutOfRangeException("poll礼品数量不能小于1个");
                if (peopleCount < 1) throw new ArgumentOutOfRangeException("参数人数不能小于1人");
                if (prizeList.Count == 1 && peopleCount <= prizeList[0].Poll) return prizeList[0].Key; //只有一种礼品且礼品数量大于等于参与人数

                int pos = 0;
                List<Area> box = new List<Area>();
                foreach (Prize p in prizeList)
                {
                    box.Add(new Area() { Key = p.Key, Start = pos, Over = pos + p.Poll }); //把礼品放入奖盒区间
                    pos = pos + p.Poll;
                }

                int total = prizeList.Sum(x => x.Poll); //礼品总数
                int speed = Math.Max(total, peopleCount); //取礼品总数和参数总人数中的最大值

                pos = Prize.Rand.Next(speed);
                Area a = box.FirstOrDefault(x => pos >= x.Start && pos < x.Over); //查找索引在奖盒中对应礼品的位置

                return a == null ? string.Empty : a.Key;
            }

        }
        #endregion

        #region 表达树，反射，等等方法测试
        public class StubClass
        {
            public StubClass(string name)
            {
                this.Name = name;
            }
            public string Name { get; set; }

            public string Test(int i)
            {
                return this.Name + i;
            }
        }

        public static class InstanceMethodBuilder<T, TReturnValue>
        {
            /// <summary>
            /// 调用时就像 var result = func(t)。
            /// </summary>
            [Pure]
            public static Func<T, TReturnValue> CreateInstanceMethod<TInstanceType>(TInstanceType instance, MethodInfo method)
            {
                if (instance == null) throw new ArgumentNullException(nameof(instance));
                if (method == null) throw new ArgumentNullException(nameof(method));

                return (Func<T, TReturnValue>)method.CreateDelegate(typeof(Func<T, TReturnValue>), instance);
            }

            /// <summary>
            /// 调用时就像 var result = func(this, t)。
            /// </summary>
            [Pure]
            public static Func<TInstanceType, T, TReturnValue> CreateMethod<TInstanceType>(MethodInfo method)
            {
                if (method == null)
                    throw new ArgumentNullException(nameof(method));

                return (Func<TInstanceType, T, TReturnValue>)method.CreateDelegate(typeof(Func<TInstanceType, T, TReturnValue>));
            }
        }
        #endregion

        #region 表达树对象赋值
        public static class TransExpV2<TIn, TOut>
        {
            private static readonly Func<TIn, TOut> cache = GetFunc();
            private static Func<TIn, TOut> GetFunc()
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
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

        #region 01，对象值的拷贝（将父类对象强转为子类对象，并且进行属性值的复制）+static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent, new()
        /// <summary>
        /// 对象值的拷贝（将父类对象强转为子类对象，并且进行属性值的复制）
        /// </summary>
        /// <typeparam name="TParent">父类类型</typeparam>
        /// <typeparam name="TChild">子类类型</typeparam>
        /// <param name="parent">父类对象</param>
        /// <returns></returns>
        static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent, new()
        {
            TChild child = new TChild();
            var ParentType = typeof(TParent);
            var Properties = ParentType.GetProperties();
            foreach (var Propertie in Properties)
            {
                if (Propertie.CanRead && Propertie.CanWrite)
                {
                    Propertie.SetValue(child, Propertie.GetValue(parent, null), null);
                }
            }
            return child;
        }
        #endregion
        
        #region 02，集合的转化(对象值的拷贝（将父类对象强转为子类对象，并且进行属性值的复制）)+static IEnumerable<TChild> AutoCopyList<TParent, TChild>(List<TParent> parent) where TChild : TParent, new()
        /// <summary>
        /// 集合的转化(对象值的拷贝（将父类对象强转为子类对象，并且进行属性值的复制）)
        /// </summary>
        /// <typeparam name="TParent">父类类型</typeparam>
        /// <typeparam name="TChild">子类类型</typeparam>
        /// <param name="parent">父类对象</param>
        /// <returns></returns>
        static IEnumerable<TChild> AutoCopyList<TParent, TChild>(List<TParent> parent) where TChild : TParent, new()
        {
            Func<TParent, TChild> action = (TParent x) => { return AutoCopy<TParent, TChild>(x); };
            foreach (var item in parent)
            {
                yield return action(item);
            }
        }
        #endregion

        #region 测试函数性能
        /// <summary>
        /// 提供对指定函数执行期间的执行时间、垃圾回收触发次数、占用CPU周期数的统计功能
        /// 在使用前调用 <see cref="CodeTimer.Initialize()"/> 进行初始化工作，设置当前进程、线程的优先级、IL代码预加载
        /// 之后再调用 <see cref="CodeTimer.Time(String, Int32, Action)"/> 对指定函数进行性能测试
        /// </summary>
        public static class CodeTimer
        {
            /// <summary>
            /// 调整当前进程、线程的优先级，并使JIT预编译<see cref="Time(String, Int32, Action)"/>函数减少测量误差
            /// </summary>
            public static void Initialize()
            {
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                Time("", 1, () => { });
            }

            /// <summary>
            /// 对指定方法进行性能测试
            /// </summary>
            /// <param name="name">测试名称</param>
            /// <param name="iteration">测试次数</param>
            /// <param name="action">被测试的方法</param>
            public static void Time(String name, Int32 iteration, Action action)
            {
                if (String.IsNullOrEmpty(name)) return;

                // 1.设置控制台颜色
                ConsoleColor currentForeColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(name);

                // 2.获取执行前的垃圾回收次数
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                Int32[] gcCounts = new Int32[GC.MaxGeneration + 1];
                for (Int32 i = 0; i <= GC.MaxGeneration; i++)
                {
                    gcCounts[i] = GC.CollectionCount(i);
                }


                Stopwatch watch = new Stopwatch();
                Int64 totalMem = GC.GetTotalMemory(true);
                watch.Start();
                // 3.计算线程使用的CPU周期数
                UInt64 cycleCount = GetCycleCount();

                for (int i = 0; i < iteration; i++) action();
                UInt64 cpuCycles = GetCycleCount() - cycleCount;
                watch.Stop();
                totalMem = GC.GetTotalMemory(false) - totalMem;
                // 4.
                Console.ForegroundColor = currentForeColor;
                Console.WriteLine($"\tTime Elapsed:\t{watch.ElapsedMilliseconds.ToString("N0")}ms");
                Console.WriteLine("\tCPU Cycles:\t" + cpuCycles.ToString("N0"));

                Console.WriteLine("\tToltal Memory:\t" + totalMem.ToString());

                // 5.获取代码执行过程中的垃圾各代回收垃圾的次数
                for (Int32 i = 0; i <= GC.MaxGeneration; i++)
                {
                    Int32 count = GC.CollectionCount(i) - gcCounts[i];
                    Console.WriteLine($"\tGen {i.ToString()}: \t\t" + count.ToString());
                }
                Console.WriteLine();
            }

            private static UInt64 GetCycleCount()
            {
                UInt64 cycleCount = 0;
                QueryThreadCycleTime(GetCurrentThread(), ref cycleCount);
                return cycleCount;
            }

            [DllImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern Boolean QueryThreadCycleTime(IntPtr threadHandle, ref UInt64 cycleTime);

            [DllImport("kernel32.dll")]
            static extern IntPtr GetCurrentThread();

        }
        #endregion

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

        static int Add(int a, int b)
        {
            return a + b;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public string Remark { get; set; }

        public DateTime Yeer { get; set; }

        public Guid Guid { get; set; }

        public int Age { get; set; }

        public AppEnum Ads { get; set; }

        public List<CityInfo> CityList { get; set; }

        public CityInfo City { get; set; }
    }

    public class Children : Person
    {
        public string ChildrenName { get { return "孩子得名字叫" + Name; } }

        //[PropertyAttribute(Alias ="Name",IsClass =true)]
        //public string Name1 { get; set; }
    }

    public class CityInfo
    {
        public int ToCityId { get; set; }

        public int FromCityId { get; set; }

        public int Count { get; set; }
    }

    public enum AppEnum
    {
        app = 1,
        web = 2
    }

    public enum StatusEnum
    {
        ok = 1,
        fail = 2
    }

    #region KissFirst
    public class EntityDataSource
    {
        public EntityDataSource()
        {

        }
        public EntityDataSource(string entityTypeFullName)
        {
            this.EntityTypeFullName = entityTypeFullName;
        }

        private string entityTypeFullName;

        private Type _entityType;

        public string EntityTypeFullName
        {
            get
            {
                return entityTypeFullName;
            }
            set
            {
                entityTypeFullName = value;
                EntityType = TypeHelper.GetType(value);
            }
        }

        public Type EntityType
        {
            get
            {
                return _entityType;
            }
            set
            {

                _entityType = value;
            }
        }

        public int Insert(IDictionary<string, object> data)
        {
            var item = data.ToEntity(EntityType);

            return 0;
        }
    }

    public static class TypeHelper
    {
        private static List<Type> _types;
        public static List<Type> Types
        {
            get
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
                return _types;
            }
        }

        /// <summary>
        /// 获取程序集中实现了某接口的所有类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<Type> GetAllImpl<T>() where T : class

        {
            return GetAllImpl(typeof(T));
        }

        /// <summary>
        /// 获取程序集中实现了某接口的所有类的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetAllImplInstance<T>() where T : class
        {
            var types = GetAllImpl<T>();
            var result = new List<T>();
            foreach (var type in types)
            {
                try
                {
                    result.Add(Activator.CreateInstance(type) as T);
                }
                catch
                {
                    throw new Exception("create instance error");
                }

            }
            return result;
        }

        /// <summary>
        /// 获取程序集中所有的枚举类
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetAllEnum()
        {
            var result = new List<Type>();
            foreach (var type in Types)
            {
                if (type.IsEnum)
                {
                    result.Add(type);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取指定类型集合中实现某接口的所有类（不包含抽象类）
        /// </summary>
        /// <param name="interfaceType">接口</param>
        /// <param name="types">指定类型集合，可为空，为空则为程序集中所有类型</param>
        /// <returns></returns>
        public static List<Type> GetAllImpl(Type interfaceType, List<Type> types = null)
        {
            var result = new List<Type>();
            if (types == null)
            {
                types = Types;
            }
            foreach (var type in types)
            {
                if (interfaceType.IsAssignableFrom(type) && !type.IsAbstract)
                {
                    result.Add(type);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取指定类型集合中某基类的所有继承类（不包含抽象类）
        /// </summary>
        /// <typeparam name="T">基类</typeparam>
        /// <param name="types">指定类型集合，可为空，为空则为程序集中所有类型</param>
        /// <returns></returns>
        public static List<Type> GetAllSubType<T>(List<Type> types = null)
        {
            return GetAllSubType(typeof(T), types);
        }

        /// <summary>
        /// 获取指定类型集合中某基类的所有继承类（不包含抽象类）
        /// </summary>
        /// <param name="baseType">基类</param>
        /// <param name="types">指定类型集合，可为空，为空则为程序集中所有类型</param>
        /// <returns></returns>
        public static List<Type> GetAllSubType(Type baseType, List<Type> types = null)
        {
            var result = new List<Type>();
            if (types == null)
            {
                types = Types;
            }
            foreach (var type in types)
            {
                if ((type.IsSubclassOf(baseType) || type == baseType) && !type.IsAbstract)
                {
                    result.Add(type);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取指定类型集合中某基类的所有继承类的实例（不包含抽象类）
        /// </summary>
        /// <param name="baseType"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static List<T> GetAllSubTypeInstance<T>(List<Type> types = null) where T : class
        {
            var allTypes = GetAllSubType(typeof(T), types);
            var result = new List<T>();
            foreach (var type in allTypes)
            {
                result.Add(Activator.CreateInstance(type) as T);
            }
            return result;
        }

        public static Type GetType(string typeName)
        {
            if (typeName.IndexOf(',') > 0)
            {
                typeName = typeName.Split(',')[0];
            }
            foreach (var type in Types)
            {
                if (type.FullName.Equals(typeName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return type;
                }
            }
            return null;
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
                        if (file.StartsWith("Test2", StringComparison.OrdinalIgnoreCase))
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
                        if (file.Name.StartsWith("Test2", StringComparison.OrdinalIgnoreCase))
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
            if (a.FullName.StartsWith("Test2", StringComparison.OrdinalIgnoreCase))
            {
                all.Add(a);
            }
        }

        public static IEnumerable<Assembly> GetAssemblies()
        {
            return _all;
        }
    }

    public static class DictionaryExtension
    {
        public static object ToEntity(this IDictionary<string, object> source, Type type)
        {
            if (source.IsNullOrEmpty()) return null;
            FastType fastType = FastType.Get(type);
            var instance = Activator.CreateInstance(type);
            foreach (var p in fastType.Setters)
            {
                if (p.Name.IsNullOrEmpty()) continue;
                if (source.Keys.Contains(p.Name))
                {
                    p.SetValue(instance, source[p.Name].ConvertToType(p.Type));
                }
            }

            return instance;
        }

        public static T ToEntity<T>(this IDictionary<string, object> source) where T : class, new()
        {
            return ToEntity(source, typeof(T)) as T;
        }

        public static void AddRange(this IDictionary<string, object> source, IDictionary<string, object> target)
        {
            if (source == null || target.IsNullOrEmpty()) return;
            foreach (var item in target)
            {
                if (!source.Keys.Contains(item.Key, StringComparer.OrdinalIgnoreCase))
                {
                    source.Add(item);
                }
            }
        }

        public static List<T> ToEntities<T>(this IList<IDictionary<string, object>> source) where T : class, new()
        {
            var list = new List<T>();
            source.ForEach(o =>
            {
                list.Add(o.ToEntity<T>());
            });
            return list;
        }

        public static T TryGetValue<T>(this IDictionary<string, T> source, string key) where T : class
        {
            T value;
            if (source.TryGetValue(key, out value))
            {
                return value;
            }
            return null;
        }
    }

    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count == 0;
        }
    }

    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (!enumerable.IsNullOrEmpty())
            {
                foreach (var item in enumerable)
                {
                    action(item);
                }
            }
        }

        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector)
        {
            if (!source.IsNullOrEmpty())
            {
                return source.Distinct(new CommonEqualityComparer<T, V>(keySelector));
            }
            return null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Count() == 0;
        }

        public static IList<IDictionary<string, object>> ToDictionary<T>(this IEnumerable<T> source)
        {
            if (!source.IsNullOrEmpty())
            {
                var result = new List<IDictionary<string, object>>();
                foreach (var item in source)
                {
                    result.Add(item.ToDictionary());
                }
                return result;
            }
            return null;
        }
    }

    public class CommonEqualityComparer<T, V> : IEqualityComparer<T>
    {
        private Func<T, V> keySelector;

        public CommonEqualityComparer(Func<T, V> keySelector)
        {
            this.keySelector = keySelector;
        }

        public bool Equals(T x, T y)
        {
            return EqualityComparer<V>.Default.Equals(keySelector(x), keySelector(y));
        }

        public int GetHashCode(T obj)
        {
            return EqualityComparer<V>.Default.GetHashCode(keySelector(obj));
        }
    }

    public static class ObjectExtension
    {
        public static T ConvertTo<T>(this object value)
        {
            return (T)value.ConvertToType(typeof(T));
        }

        public static object ConvertToType(this object value, Type type)
        {
            if (null == value || value is DBNull ||
                (typeof(string) != type && (value is string) && string.IsNullOrEmpty((string)value)))
            {
                return type.IsValueType ? Activator.CreateInstance(type) : null;
            }
            Type valueType = value.GetType();
            if (valueType == type || type.IsAssignableFrom(valueType))
            {
                return value;
            }
            if (type.IsPrimitive)
            {
                try
                {
                    return System.Convert.ChangeType(value, type);
                }
                catch { }
            }
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            if (null != converter)
            {
                if (converter.CanConvertFrom(valueType))
                {
                    return converter.ConvertFrom(value);
                }
                else if (type.IsValueType)
                {
                    return converter.ConvertFrom(value.ToString());
                }
            }
            converter = TypeDescriptor.GetConverter(valueType);
            if (null != converter && converter.CanConvertTo(type))
            {
                return converter.ConvertTo(value, type);
            }
            if (typeof(string).Equals(type))
            {
                return value.ToString();
            }
            throw new InvalidCastException(
                string.Format("Can Not Convert Type '{0}' To '{1}'",
                                value.GetType().FullName, type.FullName));
        }

        public static IDictionary<string, object> ToDictionary(this object value)
        {
            if (value == null) return null;
            IDictionary<string, object> dictionary = null;
            if (typeof(IDictionary<string, object>).IsAssignableFrom(value.GetType()))
            {
                dictionary = value as IDictionary<string, object>;
            }
            else if (value.GetType().IsSubclassOf(typeof(NameValueCollection)))
            {
                var data = value as NameValueCollection;
                dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                foreach (var key in data.AllKeys)
                {
                    dictionary.Add(key, data[key]);
                }
            }
            else
            {
                dictionary = new FoxOneDictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                if (value is IExtProperty)
                {
                    var prop = (value as IExtProperty).Properties;
                    if (!prop.IsNullOrEmpty())
                    {
                        dictionary.AddRange(prop);
                    }
                }
                FastType fastType = FastType.Get(value.GetType());
                fastType.Getters.ForEach(getter =>
                {
                    if (getter.Type.IsArray || getter.Type.IsValueType || getter.Type == typeof(string))
                    {
                        string name = getter.Name;
                        if (!name.IsNullOrEmpty())
                        {
                            object val = getter.GetValue(value);
                            dictionary.Add(name, val);
                        }
                    }
                    else if (getter.Type.IsClass)
                    {
                        string name = getter.GetType().FullName;
                        if (!name.IsNullOrEmpty())
                        {
                            object val = getter.GetValue(value);
                            dictionary.Add(name, val);
                        }
                    }
                    else if (getter.Type.IsGenericType)
                    {

                    }
                });
            }
            return dictionary;
        }
    }

    public interface IExtProperty
    {
        IDictionary<string, object> Properties { get; }

        void SetProperty();
    }

    public class FoxOneDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TValue : class
    {
        public FoxOneDictionary() :
            base()
        {

        }

        public FoxOneDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {

        }

        public FoxOneDictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        { }

        public FoxOneDictionary(int capacity)
            : base(capacity)
        { }

        public FoxOneDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer)
        { }

        public FoxOneDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        { }

        public new TValue this[TKey key]
        {
            get
            {
                if (!base.Keys.Contains(key))
                {
                    return string.Empty as TValue;
                }
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }


    public class FastType
    {
        private static readonly Dictionary<Type, FastType> _cache = new Dictionary<Type, FastType>();
        private static readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();

        public static FastType Get(Type type)
        {
            return Get(type, null);
        }

        protected static FastType Get(Type type, Func<Type, FastType> CreateFastType)
        {
            FastType value;

            _cacheLock.EnterUpgradeableReadLock();
            try
            {
                if (!_cache.TryGetValue(type, out value))
                {
                    _cacheLock.EnterWriteLock();
                    try
                    {
                        value = CreateFastType == null ? new FastType(type) : CreateFastType(type);
                        _cache[type] = value;
                    }
                    finally
                    {
                        _cacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                _cacheLock.ExitUpgradeableReadLock();
            }
            return value;
        }

        protected Type _type;
        protected FastProperty[] _setters;
        protected FastProperty[] _getters;

        public FastType(Type type)
        {
            this._type = type;
            this.Initialize();
        }

        public FastProperty GetGetter(string FastPropertyName)
        {
            return _getters.SingleOrDefault(p => p.Info.Name.Equals(FastPropertyName, StringComparison.OrdinalIgnoreCase));
        }

        public FastProperty GetSetter(string FastPropertyName)
        {
            return _setters.SingleOrDefault(p => p.Info.Name.Equals(FastPropertyName, StringComparison.OrdinalIgnoreCase));
        }

        public FastProperty[] Getters
        {
            get { return _getters; }
        }

        public FastProperty[] Setters
        {
            get { return _setters; }
        }

        private void Initialize()
        {
            this.InitializeProperties();
            this.InitializeMethods();
        }

        protected virtual void InitializeProperties()
        {
            List<FastProperty> setters = new List<FastProperty>();
            List<FastProperty> getters = new List<FastProperty>();

            foreach (PropertyInfo prop in GetProperties(_type))
            {
                String columnName = GetPropertyName(prop);
                FastProperty mapping = new FastProperty(columnName, prop);

                if (prop.CanRead)
                {
                    getters.Add(mapping);
                }

                if (prop.CanWrite)
                {
                    setters.Add(mapping);
                }
            }
            _setters = setters.ToArray();
            _getters = getters.ToArray();
        }

        protected virtual void InitializeMethods()
        {
            //do nothing
        }

        protected virtual IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        protected virtual String GetPropertyName(PropertyInfo p)
        {
            return p.Name;
        }
    }

    public class FastProperty
    {
        private string _name;
        private PropertyInfo _prop;
        private Type _type;
        private Func<object, object> _getter;
        private Action<object, object[]> _setter;

        public FastProperty(string name, PropertyInfo property)
        {
            this._name = name;
            this._prop = property;
            this._type = _prop.PropertyType;
            this.InitializeGetter(_prop);
            this.InitilizeSetter(_prop);
        }

        public String Name
        {
            get { return _name; }
        }

        public Type Type
        {
            get { return _type; }
        }

        public PropertyInfo Info
        {
            get { return _prop; }
        }

        public object GetValue(object instance)
        {
            return _getter(instance);
        }

        public void SetValue(object instance, object value)
        {
            _setter(instance, new object[] { value.ConvertToType(Type) });
        }

        private void InitializeGetter(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.CanRead) return;

            // Target: (object)(((TInstance)instance).Property)

            // preparing parameter, object type
            var instance = Expression.Parameter(typeof(object), "instance");

            // non-instance for static method, or ((TInstance)instance)
            var instanceCast = propertyInfo.GetGetMethod(true).IsStatic ?
                                null : Expression.Convert(instance, propertyInfo.ReflectedType);

            // ((TInstance)instance).Property
            var propertyAccess = Expression.Property(instanceCast, propertyInfo);

            // (object)(((TInstance)instance).Property)
            var castPropertyValue = Expression.Convert(propertyAccess, typeof(object));

            // Lambda expression
            var lambda = Expression.Lambda<Func<object, object>>(castPropertyValue, instance);

            this._getter = lambda.Compile();
        }

        private void InitilizeSetter(PropertyInfo prop)
        {
            if (!prop.CanWrite) return;

            MethodInfo methodInfo = prop.GetSetMethod(true);
            // Target: ((TInstance)instance).Method((T0)parameters[0], (T1)parameters[1], ...)

            // parameters to execute
            var instanceParameter = Expression.Parameter(typeof(object), "instance");
            var parametersParameter = Expression.Parameter(typeof(object[]), "parameters");

            // build parameter list
            var parameterExpressions = new List<Expression>();
            var paramInfos = methodInfo.GetParameters();
            for (int i = 0; i < paramInfos.Length; i++)
            {
                // (Ti)parameters[i]
                BinaryExpression valueObj = Expression.ArrayIndex(
                    parametersParameter, Expression.Constant(i));
                UnaryExpression valueCast = Expression.Convert(
                    valueObj, paramInfos[i].ParameterType);

                parameterExpressions.Add(valueCast);
            }

            // non-instance for static method, or ((TInstance)instance)
            var instanceCast = methodInfo.IsStatic ? null :
                                                              Expression.Convert(instanceParameter, methodInfo.ReflectedType);

            // static invoke or ((TInstance)instance).Method
            var methodCall = Expression.Call(instanceCast, methodInfo, parameterExpressions);

            // ((TInstance)instance).Method((T0)parameters[0], (T1)parameters[1], ...)
            var lambda = Expression.Lambda<Action<object, object[]>>(
                methodCall, instanceParameter, parametersParameter);
            _setter = lambda.Compile();
        }
    }

    public static class SysConfig
    {

        static SysConfig()
        {
            AppSettings = new AppSettingPropery();
            SystemTitle = AppSettings["SystemTitle"];
            CopyRightName = AppSettings["CopyRightName"];
            Assemblies = AppSettings["Assemblies"];
            SystemStatus = AppSettings["SystemStatus"];
            SuperAdminRoleName = AppSettings["SuperAdminRoleName"];
            DefaultUserRole = AppSettings["DefaultUserRole"];
            DomainName = AppSettings["DomainName"];
        }

        public static string ExtFieldName = "_ExtField_";

        public static AppSettingPropery AppSettings { get; private set; }

        public static string SystemTitle { get; private set; }

        public static string CopyRightName { get; private set; }

        public static string SystemVersion { get; private set; }

        /// <summary>
        /// 系统当前状态：Develop,Test,Run
        /// </summary>
        public static string SystemStatus { get; private set; }


        public static string Assemblies { get; private set; }

        public static string IconBasePath { get { return "/images/icons/"; } }

        public static string ControlImageBasePath { get { return "/images/Controls/"; } }

        public static string SuperAdminRoleName { get; private set; }

        public static string DefaultUserRole { get; private set; }

        public static string DomainName { get; private set; }
    }

    public class AppSettingPropery : Dictionary<string, string>
    {
        private AppSettingsReader _reader;
        private AppSettingsReader Reader
        {
            get
            {
                return _reader ?? (_reader = new AppSettingsReader());
            }
        }

        public new string this[string key]
        {
            get
            {
                if (!base.Keys.Contains(key))
                {
                    base[key] = Reader.GetValue(key, typeof(string)) as string;
                }
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }
    #endregion

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PropertyAttribute : Attribute
    {
        public PropertyAttribute()
        {
            IsClass = false;
            IsGenericCollections = false;
            Alias = string.Empty;
        }

        public bool IsClass
        {
            get;
            set;
        }

        public string Alias
        {
            get;
            set;
        }

        public bool IsGenericCollections
        {
            get;
            set;
        }
    }
}
