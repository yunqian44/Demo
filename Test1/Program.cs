using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            ToEntity<User>();

            Console.ReadKey();
        }

        static T ToEntity<T>() where T : class, new()
        {
            var name = typeof(T);
            var entity = new T();
            var fullName = entity.GetType().FullName;
            return null;
        }
    }

    public class User
    {

    }
}
