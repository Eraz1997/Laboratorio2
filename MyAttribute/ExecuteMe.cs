using System;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ExecuteMe : Attribute
    {
        public object [] Values { get; private set; }

        public ExecuteMe(params object [] valObjects)
        {
            Values = valObjects;
        }

    }
}
