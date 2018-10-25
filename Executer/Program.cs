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
            var a = Assembly.LoadFrom("../../../MyLibrary/bin/Debug/netstandard2.0/MyLibrary.dll");
            foreach (var type in a.GetTypes())
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
                if (type.GetConstructor(Type.EmptyTypes) == null)
                {
                    Console.WriteLine("Costruttore di default notte founde");
                    Console.ReadLine();
                    continue;
                }

                MethodInfo[] members = type.GetMethods();
                foreach (var member in members)
                {
                    object instance = Activator.CreateInstance(type);
                    ExecuteMe[] attributes = (ExecuteMe[]) member.GetCustomAttributes(typeof(ExecuteMe), false);
                    foreach (var attribute in attributes)
                    {
                        //Check validità attributi
                        var pars = member.GetParameters();
                        if (pars.Length == attribute.Values.Length)
                        {
                            bool check = true;
                            for (int i = 0; i < pars.Length; i++)
                            {
                                if (pars[i].ParameterType != attribute.Values[i].GetType())
                                    check = false;
                            }

                            if (check)
                            {
                                member.Invoke(instance, attribute.Values);
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Parametri non validi");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Parametri non validi");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
