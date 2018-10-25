using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace Executer
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Assembly.LoadFrom("MyLibrary.dll");
            foreach(var type in a.GetTypes())
            {
                if (type.IsClass)
                {
                    Console.WriteLine(type.FullName);
                    Console.ReadLine();
                }
            }

            foreach (var type in a.GetTypes())
            {
                if (!type.IsClass)
                    continue;
                MethodInfo[] members = type.GetMethods();
                foreach (var member in members)
                {
                    object instance = Activator.CreateInstance(type);
                    ExecuteMe []attributes = (ExecuteMe[]) member.GetCustomAttributes(typeof(ExecuteMe), false);
                    foreach(var attribute in attributes)
                    {
                        member.Invoke(instance, attribute.Values);
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
