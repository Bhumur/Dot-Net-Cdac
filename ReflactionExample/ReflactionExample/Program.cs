using System.Reflection;

namespace ReflactionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFile("E:\\CDAC\\.Net\\Dot-Net-Cdac\\Assignment3\\EmployeeClasses\\bin\\Debug\\net9.0\\EmployeeClasses.dll");
            //Console.WriteLine(asm.FullName);
            Console.WriteLine(asm.GetName().Name) ;
            Type[]arrType = asm.GetTypes();
            foreach (Type t in arrType)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(t.FullName);
                Console.WriteLine(t.IsValueType);
                Console.WriteLine(t.Assembly);
                //Console.WriteLine(t.AssemblyQualifiedName);
                //Console.WriteLine(t.Attributes);
                //Console.WriteLine(t.FindInterfaces);
                //Console.WriteLine(t.FindMembers);
                MethodInfo[]arm = t.GetMethods();
                foreach (MethodInfo m in arm)
                {
                    Console.WriteLine(m.Name);
                    Console.WriteLine(m.ReturnType);
                }
                //break;
            }
        }
    }
}
