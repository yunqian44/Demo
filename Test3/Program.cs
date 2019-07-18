using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1，简单工厂
            //Console.WriteLine("请输入第一个数");
            //double number1 = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("请输入一个操作符");
            //string caozuofu = Console.ReadLine();
            //Console.WriteLine("请输入第二个数");
            //double number2 = Convert.ToDouble(Console.ReadLine());
            //Calculator c = null;
            //switch (caozuofu)
            //{
            //    case "+":
            //        c = new JiafaDll(number1, number2);
            //        break;
            //    case "-":
            //        c = new JianfaDll(number1, number2);
            //        break;
            //}
            //double i = c.JiSuan();
            //Console.WriteLine(i);
            #endregion



            #region 简单工厂修改
            Calculator cal = OperationFactory.createOperate("+");
            cal.Number1 = 1;
            cal.Number2 = 3;
            var sum= cal.JiSuan();

            Console.WriteLine(sum);
            #endregion

            Console.ReadKey();
        }
    }

    #region 简单工厂
    public abstract class Calculator
    {
        public Calculator()
        {
            
        }

        public Calculator(double n1, double n2)
        {
            Number1 = n1;
            Number2 = n2;
        }

        public double Number1 { get;  set; }

        public double Number2 { get;  set; }


        public abstract double JiSuan();
    }

    /// <summary>
    /// 加法类
    /// </summary>
    public class JiafaDll : Calculator  //子类拥有父类除私有之外的所有属性字段和方法
    {
        public JiafaDll()
        {

        }
        
        public JiafaDll(double a, double b)
            : base(a, b)   //调用父类带两个参数的构造函数，来初始化Number1 和Number2  （注意：因为jianfaDll类继承了Calculator，所以jianfaDll类是有Number1，和Number2两个属性的）              
        { }

        public override double JiSuan()
        {
            return Number1 + Number2;
        }
    }

    /// <summary>
    /// 减法类
    /// </summary>
    public class JianfaDll : Calculator
    {
        public JianfaDll()
        { }
        public JianfaDll(double a, double b)
            : base(a, b)
        { }

        public override double JiSuan()
        {
            return Number1 - Number2;
        }
    }
    #endregion

    #region 简单工厂修改


    public class OperationFactory
    {
        public static Calculator createOperate(string operate)
        {

            Calculator oper = null;
            switch (operate)
            {
                case "+":
                    oper = new JiafaDll();
                    break;
                case "-":
                    oper = new JianfaDll();
                    break;
                case "*":
                    break;
                case "/":
                    break;
            }
            return oper;
        }
    }
    #endregion

}
