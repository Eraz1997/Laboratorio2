using System;
using MyAttribute;

namespace MyLibrary
{
    public class Foo
    {
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine("M1");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2(int a)
        {
            Console.WriteLine("M2 a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3(string s1, string s2)
        {
            Console.WriteLine("M3 s1={0} s2={1}", s1, s2);
        }

        [ExecuteMe("hello", "42")]
        public void M4(string s1, int s2)
        {
            Console.WriteLine("M4 s1={0} s2={1}", s1, s2);
        }
    }

    public class Bar
    {
        private int n;
        public Bar(int nano)
        {
            n = nano;
        }

        [ExecuteMe("sanni")]
        public void M1(string m)
        {
            Console.WriteLine(m);
            Console.ReadLine();
        }
    }
}
