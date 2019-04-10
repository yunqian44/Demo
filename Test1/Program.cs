using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPinyin;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01，反射调用方式测试
            var user0 = new User() { UserName = "老二" };
            CodeTimer.Time("使用InvokeMember", 10000, () =>
            {
                var t = typeof(User);
                t.InvokeMember("SayHello", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { "你好" });
            });
            user0.Dispose();


            //var user = new User() { UserName = "张三" };
            //CodeTimer.Time("使用Invoke", 10000, () =>
            //{
            //    var fun = user.GetType().GetMethod(nameof(user.SayHello));

            //    fun.Invoke(user, new Object[] { "你好" });
            //});
            //user.Dispose();

            //dynamic user1 = new User() { UserName = "李四" };
            //CodeTimer.Time("使用InvokeMember", 10000, () =>
            //{
            //    user1.SayHello("你好");
            //});
            //user1.Dispose();

            //User user2 = new User() { UserName = "王五" };
            //CodeTimer.Time("使用原始", 10000, () =>
            //{

            //    user2.SayHello("你好");

            //    //fun.Invoke(user, new Object[] { "你好" });
            //});
            //user2.Dispose();

            //User user3 = new User() { UserName = "马六" };
            //CodeTimer.Time("使用var", 10000, () =>
            //{
            //    user3.SayHello("你好");
            //    //fun.Invoke(user, new Object[] { "你好" });
            //});
            //user3.Dispose();
            #endregion

            //Console.Title = "Api Service";

            #region 02，WebHost宿主
            //string baseAddress = "http://localhost:9100/";
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{
            //    //HttpClient client = new HttpClient();
            //    //var response = client.GetAsync(baseAddress + "api/values").Result;
            //    //Console.WriteLine(response);
            //    //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //    Console.WriteLine("API服务已开启！");
            //    Console.ReadKey();
            //}
            #endregion


            #region 03，百度AI识别
            //var obj2= IdCardValidateService.GetIdCardInfo(@"http://aip.bdstatic.com/portal/dist/1547780921660/ai_images/technology/ocr-cards/idcard/demo-card-1.png");

            //var request = HttpHelper.GetGetResponseEx("http://aip.bdstatic.com/portal/dist/1547780921660/ai_images/technology/ocr-cards/idcard/demo-card-1.png");

            //var buffer= HttpHelper.GetResponseStream(request);
            //var s= Convert.ToBase64String(buffer);

            //Console.WriteLine(s);


            //var imgByte = File.ReadAllBytes("http://aip.bdstatic.com/portal/dist/1547780921660/ai_images/technology/ocr-cards/idcard/demo-card-1.png");

            //string str = "{\"住址\":{\"words\":\"南京市江宁区弘景大道3889号\"},\"公民身份号码\":{\"words\":\"330881199904173914\"},\"出生\":{\"words\":\"19990417\"},\"姓名\":{\"words\":\"伍云龙\"},\"性别\":{\"words\":\"男\"},\"民族\":{\"words\":\"汉\"}}";

            //var dic = JsonConvert.DeserializeObject<IDictionary<string, object>>(str);
            //var obj = dic.ToEntity<IdCardInfo>(); 
            #endregion

            #region 04，汉字转拼音
            //      string[] maxims = new string[]{
            //                                      "事常与人违，事总在人为",
            //                                      "骏马是跑出来的，强兵是打出来的",
            //                                      "驾驭命运的舵是奋斗。不抱有一丝幻想，不放弃一点机会，不停止一日努力。 ",
            //                                      "如果惧怕前面跌宕的山岩，生命就永远只能是死水一潭",
            //                                      "懦弱的人只会裹足不前，莽撞的人只能引为烧身，只有真正勇敢的人才能所向披靡"
            //};

            //      string[] medicines = new string[] {
            //                                      "聚维酮碘溶液",
            //                                      "开塞露",
            //                                      "炉甘石洗剂",
            //                                      "苯扎氯铵贴",
            //                                      "鱼石脂软膏",
            //                                      "莫匹罗星软膏",
            //                                      "红霉素软膏",
            //                                      "氢化可的松软膏",
            //                                      "曲安奈德软膏",
            //                                      "丁苯羟酸乳膏",
            //                                      "双氯芬酸二乙胺乳膏",
            //                                      "冻疮膏",
            //                                      "克霉唑软膏",
            //                                      "特比奈芬软膏",
            //                                      "酞丁安软膏",
            //                                      "咪康唑软膏、栓剂",
            //                                      "甲硝唑栓",
            //                                      "复方莪术油栓"
            //};

            //      for (int i = 0; i < maxims.Length; i++)
            //      {
            //          Console.WriteLine("汉字:{0}.....拼音{1}", maxims[i], maxims[i].GetFirstSpell());
            //      } 
            #endregion



            //Console.WriteLine(DateTime.Now.AddDays(1-DateTime.Now.Day).Date);

            //Console.WriteLine(DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(1).Date);

            var user1 = new List<User>();
            user1.Add(new User() { UserName = "张三" });
            user1.Add(new User() { UserName = "李四" });

            Order order = new Order() { Id = 1, Name = "lee", User = new User() { UserName = "YUNQIAN" }, Count = 10, Price = 1.00, Desc = "订单测试", Users = user1, OrderStatus = OrderStatusEnum.Fail };


            var user2 = new List<User>();
            user2.Add(new User() { UserName = "李四" });
            //user2.Add(new User() { UserName = "王五" });
            //user2.Add(new User() { UserName = "马六" });
            Order order1 = new Order() { Id = 2, Name = "lee1", User = new User() { UserName = "沈亚方" }, Count = 104, Price = 1.004, Users = user2, OrderStatus = OrderStatusEnum.Success };

            string remark = BuildRemark<Order>(order, order1);


            Console.ReadKey();
        }


        public static string BuildRemark<T>(object parent, object child)
        {
            var remark = string.Empty;
            var type = typeof(T);
            var properties = type.GetProperties();
            var s = type.GetCustomAttribute<DescriptionAttribute>(true);
            foreach (var propertie in properties)
            {
                if (propertie.CanRead && propertie.CanWrite)
                {
                    var name = propertie.Name;
                    var attr = propertie.GetCustomAttribute<DescriptionAttribute>(true);
                    var columnProperty = propertie.GetCustomAttribute<PropertyAttribute>(true);
                    if (columnProperty != null)
                    {
                        if (!columnProperty.IsClass && !columnProperty.IsGenericCollections)
                        {
                            remark += GetObjectPropertyRemark(parent, child, propertie, attr);
                        }
                        else if (columnProperty.IsClass && !columnProperty.IsGenericCollections)
                        {
                            var oldValue = propertie.GetValue(parent, null);
                            var newValue = propertie.GetValue(child, null);

                            var oldModel = Convert.ChangeType(oldValue, propertie.PropertyType);
                            var newModel = Convert.ChangeType(newValue, propertie.PropertyType);
                            var Columtype = propertie.PropertyType;
                            if (oldModel != null && newModel != null)
                            {
                                var fun = typeof(Program).GetMethod(nameof(Program.BuildRemark));

                                var obj = fun.MakeGenericMethod(Columtype).Invoke(null, new Object[] { oldModel, newModel });
                                remark += obj.ToString();
                            }
                        }
                        else if (columnProperty.IsGenericCollections && !columnProperty.IsClass)
                        {
                            var oldValue = propertie.GetValue(parent, null);
                            var newValue = propertie.GetValue(child, null);

                            IEnumerable<object> IoldObjectList = oldValue == null ? new List<object>() : (IEnumerable<object>)oldValue;
                            IEnumerable<object> InewObjectList = newValue == null ? new List<object>() : (IEnumerable<object>)newValue;

                            #region MyRegion
                            //if (IoldObjectList.Count() > InewObjectList.Count())//删除了
                            //{
                            //    var oldObjectList = IoldObjectList.ToList();
                            //    var newObjectList = InewObjectList.ToList();
                            //    remark += GetCollectionPropertyRemark(propertie, oldObjectList, newObjectList);
                            //}
                            //else if (InewObjectList.Count() > IoldObjectList.Count())//新增了
                            //{
                            //    var oldObjectList = IoldObjectList.ToList();
                            //    var newObjectList = InewObjectList.ToList();
                            //    remark += GetCollectionPropertyRemark(propertie, oldObjectList, newObjectList);
                            //}
                            //else if (InewObjectList.Count() > 0 && IoldObjectList.Count() > 0 && InewObjectList.Count() == IoldObjectList.Count())//相等  但是要判断集合里面的对象是否修改了
                            //{
                            //    var oldObjectList = IoldObjectList.ToList();
                            //    var newObjectList = InewObjectList.ToList();
                            //    remark += GetCollectionPropertyRemark(propertie, oldObjectList, newObjectList);
                            //} 
                            #endregion

                            var oldObjectList = IoldObjectList.ToList();
                            var newObjectList = InewObjectList.ToList();
                            remark += GetCollectionPropertyRemark(propertie, oldObjectList, newObjectList);
                        }
                    }
                    else
                    {
                        remark += GetObjectPropertyRemark(parent, child, propertie, attr);
                    }

                }
            }
            return string.IsNullOrWhiteSpace(remark) ? string.Empty : remark.Substring(0, remark.Length - 1);
        }

        private static string GetCollectionPropertyRemark(PropertyInfo propertie, List<object> oldObjectList, List<object> newObjectList)
        {
            string remark = string.Empty;
            if (oldObjectList.Count < newObjectList.Count)//新增了
            {
                for (int i = 0; i < oldObjectList.Count(); i++)//相同数量的
                {
                    var PropertyType = propertie.PropertyType.GetGenericArguments();
                    if (PropertyType != null && PropertyType.Length > 0)
                    {
                        var oldModel = Convert.ChangeType(oldObjectList[i], PropertyType[0]);
                        var newModel = Convert.ChangeType(newObjectList[i], PropertyType[0]);
                        if (oldModel != null && newModel != null)
                        {
                            var fun = typeof(Program).GetMethod(nameof(Program.BuildRemark));

                            var obj = fun.MakeGenericMethod(PropertyType[0]).Invoke(null, new Object[] { oldModel, newModel });
                            remark += obj.ToString();
                        }
                    }
                }
                for (int i = oldObjectList.Count; i < newObjectList.Count; i++)//多余出来的
                {
                    var PropertyType = propertie.PropertyType.GetGenericArguments();
                    if (PropertyType != null && PropertyType.Length > 0)
                    {
                        var newModel = Convert.ChangeType(newObjectList[i], PropertyType[0]);
                        if (newModel != null)
                        {
                            var fun = typeof(Program).GetMethod(nameof(Program.BuildRemark));

                            var obj = fun.MakeGenericMethod(PropertyType[0]).Invoke(null, new Object[] { null, newModel });
                            remark += obj.ToString();
                        }
                    }
                }
            }
            else//删除了
            {
                for (int i = 0; i < newObjectList.Count(); i++)//相同数量的
                {
                    var PropertyType = propertie.PropertyType.GetGenericArguments();
                    if (PropertyType != null && PropertyType.Length > 0)
                    {
                        var oldModel = Convert.ChangeType(oldObjectList[i], PropertyType[0]);
                        var newModel = Convert.ChangeType(newObjectList[i], PropertyType[0]);
                        if (oldModel != null && newModel != null)
                        {
                            var fun = typeof(Program).GetMethod(nameof(Program.BuildRemark));

                            var obj = fun.MakeGenericMethod(PropertyType[0]).Invoke(null, new Object[] { oldModel, newModel });
                            remark += obj.ToString();
                        }
                    }
                }
                for (int i = newObjectList.Count; i < oldObjectList.Count; i++)//多余出来的
                {
                    var PropertyType = propertie.PropertyType.GetGenericArguments();
                    if (PropertyType != null && PropertyType.Length > 0)
                    {
                        var oldModel = Convert.ChangeType(oldObjectList[i], PropertyType[0]);
                        if (oldModel != null)
                        {
                            var fun = typeof(Program).GetMethod(nameof(Program.BuildRemark));

                            var obj = fun.MakeGenericMethod(PropertyType[0]).Invoke(null, new Object[] { oldModel, null });
                            remark += obj.ToString();
                        }
                    }
                }
            }
            return remark;
        }

        private static string GetObjectPropertyRemark(object parent, object child, PropertyInfo propertie, DescriptionAttribute attr)
        {
            string remark = string.Empty;
            if (parent != null && child != null)
            {
                var oldValue = propertie.GetValue(parent, null);
                var newValue = propertie.GetValue(child, null);
                if (attr != null && oldValue != newValue)
                {
                    if (oldValue != null)
                    {
                        if (!oldValue.Equals(newValue))
                        {
                            if (oldValue.GetType().IsEnum)
                            {
                                var fieldInfo = oldValue.GetType().GetField(oldValue.ToString());
                                var attribArray = fieldInfo.GetCustomAttributes(false);
                                if (attribArray.Length > 0)
                                {
                                    var da = attribArray[0] as DescriptionAttribute;
                                    if (da != null)
                                    {
                                        oldValue = da.Description;
                                    }
                                }
                            }
                            if (newValue.GetType().IsEnum)
                            {
                                var fieldInfo = newValue.GetType().GetField(newValue.ToString());
                                var attribArray = fieldInfo.GetCustomAttributes(false);
                                if (attribArray.Length > 0)
                                {
                                    var da = attribArray[0] as DescriptionAttribute;
                                    if (da != null)
                                    {
                                        newValue = da.Description;
                                    }
                                }
                            }
                            remark += string.Format("{0}:{1}改为{2},", attr.Description, oldValue, newValue);
                        }
                    }
                }
            }
            else if (parent != null)
            {
                var oldValue = propertie.GetValue(parent, null);
                if (attr != null)
                {
                    if (oldValue != null)
                    {
                        if (oldValue.GetType().IsEnum)
                        {
                            var fieldInfo = oldValue.GetType().GetField(oldValue.ToString());
                            var attribArray = fieldInfo.GetCustomAttributes(false);
                            if (attribArray.Length > 0)
                            {
                                var da = attribArray[0] as DescriptionAttribute;
                                if (da != null)
                                {
                                    oldValue = da.Description;
                                }
                            }
                        }
                        remark += string.Format("{0}:删除{1},", attr.Description, oldValue);
                    }
                }
            }
            else if (child != null)
            {
                var newValue = propertie.GetValue(child, null);
                if (attr != null)
                {
                    if (newValue != null)
                    {
                        if (newValue.GetType().IsEnum)
                        {
                            var fieldInfo = newValue.GetType().GetField(newValue.ToString());
                            var attribArray = fieldInfo.GetCustomAttributes(false);
                            if (attribArray.Length > 0)
                            {
                                var da = attribArray[0] as DescriptionAttribute;
                                if (da != null)
                                {
                                    newValue = da.Description;
                                }
                            }
                        }
                        remark += string.Format("{0}:新增{1},", attr.Description, newValue);
                    }
                }
            }
            return remark;
        }

        public class Compare<T> : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                var flag = false;
                var type = typeof(T);
                var properties = type.GetProperties();
                foreach (var propertie in properties)
                {
                    var name = propertie.Name;
                    var oldValue = propertie.GetValue(x, null);
                    var newValue = propertie.GetValue(y, null);
                    if (name == "Id")
                    {
                        return oldValue == newValue;
                    }
                }
                return flag;
            }

            public int GetHashCode(T obj)
            {
                var type = typeof(T);
                var properties = type.GetProperties();
                foreach (var propertie in properties)
                {
                    var name = propertie.Name;
                    var value = propertie.GetValue(obj, null);
                    if (name == "Id")
                    {
                        return value.GetHashCode();
                    }
                }
                return 0;
            }
        }

    }

    [Description("运单信息")]
    public class Order
    {
        [Description("主键Id")]
        public int Id { set; get; }

        [Description("用户信息")]
        [PropertyAttribute(IsClass = true)]
        public User User { get; set; }

        [Description("用户列表信息")]
        [PropertyAttribute(IsGenericCollections = true)]
        public List<User> Users { get; set; }

        [Description("运单名称")]
        public string Name { set; get; }

        [Description("数量")]
        public int Count { set; get; }

        [Description("价格")]
        public double Price { set; get; }

        [Description("描述")]
        public string Desc { set; get; }

        [Description("运单状态")]
        public OrderStatusEnum OrderStatus { get; set; }
    }

    public enum OrderStatusEnum
    {
        [Description("取消")]
        Fail = 1,
        [Description("成功")]
        Success = 2
    }

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

    #region User
    [TableAttribute("User_Table")]
    public class User : IDisposable
    {
        [Description("用户名")]
        public string UserName { get; set; }

        public string SayHello(string str)
        {
            return string.Format("{0}", str);
        }

        private IntPtr handle; // 句柄，属于非托管资源

        private Component comp; // 组件，托管资源

        private bool disposed = false;

        public void Dispose()
        {
            DisposeImpl(true);
            GC.SuppressFinalize(this);
        }

        private void DisposeImpl(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing && comp != null)
                {
                    //这里释放托管的资源
                    comp.Dispose();
                }
                //这里释放非托管的资源
                handle = IntPtr.Zero;
            }
            disposed = true;
        }

        ~User()
        {
            DisposeImpl(false);
        }

    }
    #endregion

    #region 特性类
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class TableAttribute : NameAttribute
    {
        public TableAttribute(string name) : base(name)
        {

        }
    }

    public class NameAttribute : Attribute
    {
        protected NameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PropertyAttribute : Attribute
    {
        public PropertyAttribute()
        {
            IsClass = false;
            IsGenericCollections = false;
        }

        public bool IsClass
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
    #endregion

    public static class StringHelper
    {
        public static string ToByteBase64(this byte[] buffer)
        {
            return Convert.ToBase64String(buffer);
        }

        private static Encoding gb2312 = Encoding.GetEncoding("GB2312");

        /// <summary>
        /// 汉字转全拼
        /// </summary>
        /// <param name="strChinese"></param>
        /// <returns></returns>
        public static string ConvertToAllSpell(this string strChinese)
        {
            try
            {
                if (strChinese.Length != 0)
                {
                    StringBuilder fullSpell = new StringBuilder();
                    for (int i = 0; i < strChinese.Length; i++)
                    {
                        var chr = strChinese[i];
                        fullSpell.Append(GetSpell(chr));
                    }

                    return fullSpell.ToString().ToUpper();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("全拼转化出错！" + e.Message);
            }

            return string.Empty;
        }

        /// <summary>
        /// 汉字转首字母
        /// </summary>
        /// <param name="strChinese"></param>
        /// <returns></returns>
        public static string GetFirstSpell(this string strChinese)
        {
            //NPinyin.Pinyin.GetInitials(strChinese)  有Bug  洺无法识别
            //return NPinyin.Pinyin.GetInitials(strChinese);

            try
            {
                if (strChinese.Length != 0)
                {
                    StringBuilder fullSpell = new StringBuilder();
                    for (int i = 0; i < strChinese.Length; i++)
                    {
                        var chr = strChinese[i];
                        fullSpell.Append(GetSpell(chr)[0]);
                    }

                    return fullSpell.ToString().ToUpper();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("首字母转化出错！" + e.Message);
            }

            return string.Empty;
        }

        private static string GetSpell(char chr)
        {
            var coverchr = Pinyin.GetPinyin(chr);
            return coverchr;
        }
    }

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

    #region 统一的数据返回
    public class HttpResult
    {
        /// <summary>
        /// 本构造函数 默认为 处理成功
        /// </summary>
        public HttpResult()
        {
            this.Status = 1;
        }
        /// <summary>
        /// 本构造函数 默认为 处理成功，且将返回数据传入
        /// </summary>
        /// <param name="d">返回数据</param>
        public HttpResult(dynamic d)
        {
            this.Status = 1;
            this.Data = d;
        }
        /// <summary>
        /// 默认作为出现错误时使用；
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="msg">错误信息</param>
        public HttpResult(int status, string msg)
        {
            this.Status = status;
            this.Message = msg;
        }

        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    /// <summary>
    /// Api返回数据格式
    /// </summary>
    public class HttpResult<T> : HttpResult where T : class
    {
        public HttpResult()
        {
            this.Status = 1;
        }
        public HttpResult(T d)
            : this()
        {
            this.data = d;
        }

        public HttpResult(int status, string msg)
        {
            this.Status = status;
            this.Message = msg;
        }

        public new T data { get; set; }
    }
    #endregion


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class EnitityMappingAttribute : Attribute
    {
        private string _className;
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        private string _propertyName;
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
    }


    public class IdCardValidateService
    {
        private const string host = "https://aip.baidubce.com/rest/2.0/ocr/v1";
        private const string oauthhost = "https://aip.baidubce.com/oauth/2.0/token";



        private const string idCardValidate = "/idcard";
        private const string infopath = "/business_license";
        private const string appId = "15441403";

        private const string grantType = "client_credentials";
        private const string apiKey = "aTNBKm19tAzTmQUf1G5lpYBk";
        private const string secretkey = "NxhANErndxGXWbsqWEYbRyv4DMG7LOAm";

        #region 01，获取身份证信息+Person GetIdCardInfo(string imagePath)
        /// <summary>
        /// 获取身份证信息
        /// </summary>
        /// <param name="imagePath">图书路径</param>
        /// <returns></returns>
        public static HttpResult GetIdCardInfo(string imagePath)
        {

            var getTokenResult = IdCardValidateService.GetBaidu_AccessToken();
            if (getTokenResult.Status == 0)
            {
                return new HttpResult(0, getTokenResult.Message);
            }

            string url = host + idCardValidate;


            var request = HttpHelper.GetGetResponseEx(imagePath);
            var base64 = HttpHelper.GetResponseStream(request);


            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("id_card_side", "front");
            param.Add("image", HttpUtility.UrlEncode(base64.ToByteBase64()));
            param.Add("access_token", getTokenResult.Data);

            var result = WebRequestHelper.WebPostRequest<JObject>(url, param, false);

            var obj = result["words_result"];
            var errorMsg = result["error"];

            if (obj != null)
            {
                var dic = JsonConvert.DeserializeObject<IDictionary<string, object>>(obj.ToString());
                return new HttpResult(dic.ToEntity<IdCardInfo>());
            }
            else
            {
                return new HttpResult(0, errorMsg.ToString());
            }
        }
        #endregion

        #region 01，获取百度token+string GetBaidu_AccessToken(string imagePath)
        /// <summary>
        /// 获取百度token
        /// </summary>
        /// <returns></returns>
        public static HttpResult GetBaidu_AccessToken()
        {
            string url = oauthhost;

            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("grant_type", grantType);
            param.Add("client_id", apiKey);
            param.Add("client_secret", secretkey);


            var result = WebRequestHelper.WebPostRequest<JObject>(url, param);
            var accessToken = result["access_token"];
            var errorMsg = result["error"];
            if (accessToken != null)
            {
                return new HttpResult(accessToken.ToString());
            }
            else
            {
                return new HttpResult(0, errorMsg.ToString());
            }
        }
        #endregion

    }

    public class WebRequestHelper
    {
        #region Get请求
        /// <summary>
        /// Get请求(https未做验证考虑)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="param">参数列表(如果在url中已经追加参数则此值可为null或空字符)</param>
        /// <returns></returns>
        public static TResult WebGetRequest<TResult>(string url, Dictionary<string, string> param, Dictionary<string, string> headers = null) where TResult : class
        {
            HttpWebRequest webRequest = null;
            if (param == null || param.Count == 0)
            {
                webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            }
            else
            {
                url += "?";
                string paramStr = string.Empty;
                for (int i = 0; i < param.Count; i++)
                {
                    paramStr += param.ElementAt(i).Key + "=" + param.ElementAt(i).Value + "&";
                }
                url += paramStr.Substring(0, paramStr.LastIndexOf("&"));
                webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            }
            webRequest.Method = "GET";
            webRequest.Timeout = 1000000;
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    webRequest.Headers.Add(item.Key, item.Value);
                }
            }
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)webRequest.GetResponse();
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string strResult = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<TResult>(strResult);
        }
        #endregion

        #region POST请求
        /// <summary>
        /// POST请求(https未做验证考虑)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="param">参数列表(如果在url中已经追加参数则此值可为null或空字符)</param>
        /// <returns></returns>
        public static TResult WebPostRequest<TResult>(string url, Dictionary<string, string> param, bool isJson = false, Dictionary<string, string> headers = null) where TResult : class
        {
            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            //webRequest.KeepAlive = true;
            //webRequest.AllowAutoRedirect = true;
            webRequest.Method = "POST";
            string paramStr = string.Empty;
            if (isJson)
            {
                webRequest.ContentType = "application/json";
                paramStr = param.ElementAt(0).Value;
            }
            else
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";
                for (int i = 0; i < param.Count; i++)
                {
                    paramStr += param.ElementAt(i).Key + "=" + param.ElementAt(i).Value + "&";
                }
                paramStr = paramStr.Substring(0, paramStr.LastIndexOf("&"));
            }
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    webRequest.Headers.Add(item.Key, item.Value);
                }
            }
            //将URL编码后的字符串转化为字节
            byte[] byteArray = Encoding.UTF8.GetBytes(paramStr);
            //设置请求的 ContentLength 
            webRequest.ContentLength = byteArray.Length;
            //获得请 求流
            System.IO.Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            // 关闭请求流
            dataStream.Close();
            // 获得响应流
            System.Net.WebResponse response = webRequest.GetResponse();
            dataStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
            //string cookie = response.Headers.Get("Set-Cookie");
            string str = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<TResult>(str);
        }
        #endregion

        #region PUT请求
        /// <summary>
        /// POST请求(https未做验证考虑)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="param">参数列表(如果在url中已经追加参数则此值可为null或空字符)</param>
        /// <returns></returns>
        public static TResult WebPutRequest<TResult>(string url, Dictionary<string, string> param, Dictionary<string, string> headers = null) where TResult : class
        {
            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            //webRequest.KeepAlive = true;
            //webRequest.AllowAutoRedirect = true;
            webRequest.Method = "PUT";
            //webRequest.Accept = "text/html, application/xhtml+xml, */*";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    webRequest.Headers.Add(item.Key, item.Value);
                }
            }
            string paramStr = string.Empty;
            for (int i = 0; i < param.Count; i++)
            {
                paramStr += param.ElementAt(i).Key + "=" + param.ElementAt(i).Value + "&";
            }
            //将URL编码后的字符串转化为字节
            byte[] byteArray = Encoding.UTF8.GetBytes(paramStr.Substring(0, paramStr.LastIndexOf("&")));
            //设置请求的 ContentLength 
            webRequest.ContentLength = byteArray.Length;
            //获得请 求流
            System.IO.Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            // 关闭请求流
            dataStream.Close();
            // 获得响应流
            System.Net.WebResponse response = webRequest.GetResponse();
            dataStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
            //string cookie = response.Headers.Get("Set-Cookie");
            string str = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<TResult>(str);
        }
        #endregion
    }


    public class HttpHelper
    {
        /// <summary>
        /// 获取URL响应对象
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WebResponse GetGetResponseEx(string url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.KeepAlive = true;
            WebResponse res = request.GetResponse();
            return res;
        }

        public static byte[] GetResponseStream(WebResponse response)
        {
            Stream smRes = response.GetResponseStream();
            byte[] resBuf = new byte[10240];
            int nReaded = 0;
            MemoryStream memSm = new MemoryStream();
            while ((nReaded = smRes.Read(resBuf, 0, 10240)) != 0)
            {
                memSm.Write(resBuf, 0, nReaded);
            }
            byte[] byResults = memSm.ToArray();
            memSm.Close();
            return byResults;
        }
    }

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

            //取类上的自定义特性
            //object[] objs = objType.GetCustomAttributes(typeof(EnitityMappingAttribute), true);
            //foreach (object obj in objs)
            //{
            //    EnitityMappingAttribute attr = obj as EnitityMappingAttribute;
            //    if (attr != null)
            //    {

            //        tableName = attr.ClassName;//表名只有获取一次
            //        break;
            //    }
            //}
            //if (string.IsNullOrEmpty(tableName))
            //{
            //    tableName = objType.Name;
            //}

            return instance;
        }

        public static T ToEntity<T>(this IDictionary<string, object> source) where T : class, new()
        {
            return ToEntity(source, typeof(T)) as T;
        }
    }

}
