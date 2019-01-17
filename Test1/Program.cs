using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01，反射调用方式测试
            //var user0 = new User() { UserName = "老二" };
            //CodeTimer.Time("使用InvokeMember", 10000, () =>
            //{
            //    user0.GetType().InvokeMember("SayHello", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod, null, user0, new object[] { "你好" });
            //});
            //user0.Dispose();


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

            Console.Title = "Api Service";

            string baseAddress = "http://localhost:9100/";
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                //HttpClient client = new HttpClient();
                //var response = client.GetAsync(baseAddress + "api/values").Result;
                //Console.WriteLine(response);
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("API服务已开启！");
                Console.ReadKey();
            }
        }
    }


    public class HomeController : ApiController
    {
        [HttpGet]
        public object Get(string name)
        {
            return new { Hello = "hello" + name, Time = DateTime.Now };
        }
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

    [TableAttribute("User_Table")]
    public class User : IDisposable
    {
        public string UserName { get; set; }

        public string SayHello(string str)
        {
            return string.Format("{0}说{1}", UserName, str);
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
    #endregion

}
