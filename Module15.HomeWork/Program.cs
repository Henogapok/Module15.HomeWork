using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module15.HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetMethodsByReflex();
            //SubstringByReflex();
            //GetListCtorsByReflex();
            GetPropbyReflex();
        }
        public static void GetMethodsByReflex()
        {
            Type myType = typeof(Console);
            Console.WriteLine("Methods: ");
            foreach(var method in myType.GetMethods())
            {
                Console.Write($"\t{method.ReturnType.Name} {method.Name}(");

                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i < parameters.Length - 1)
                        Console.Write(", ");
                }

                Console.Write(")\n");
            }
        }
        public static void SubstringByReflex()
        {
            string str = "asdasdasd qweqweqwe";
            var substring = typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            object[] parametrs = { 0, 5 };
            string res = (string)substring.Invoke(str, parametrs);
            Console.WriteLine("Start string: {0}", str);
            Console.WriteLine("Substring: {0}", res);
        }
        public static void GetListCtorsByReflex()
        {
            Type myType = typeof(List<>);
            foreach(var constrictors in myType.GetConstructors())
            {
                Console.WriteLine($"{constrictors} - {constrictors.Attributes}");
            }
        }
        public static void GetPropbyReflex()
        {
            People p = new People();
            var prop1 = typeof(People).GetProperty("Id");
            prop1.SetValue(p, 1);
            var prop2 = typeof(People).GetProperty("Name");
            prop2.SetValue(p, "Valeriy");
            Console.WriteLine($"{prop1.Name}: {prop1.GetValue(p)}\n{prop2.Name}: {prop2.GetValue(p)}");
        }
        class People
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public People() {}
        }
    }

    
}
