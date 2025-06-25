using one;
using System.Reflection.Metadata.Ecma335;

namespace ClassCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            one.Hello obj1 = new one.Hello();
            obj1.show();
            obj1.DoSomething();
            Console.WriteLine(obj1.Add(100,c:30));
        }
    }
}

namespace one
{
    public class  Hello
    {
        public void show()
        {
            Console.WriteLine("i am form one");
        }

        public int Add(int a = 0, int b = 0, int c = 0)
        {
           return a + b + c;
        }

        public void DoSomething()
        {
            
            int a = 0;
            void doSomething1()
            {
                Console.WriteLine("from local function" + a);
            }
            void doSomething1(int a = 0)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("before");
            doSomething1();
            Console.WriteLine("after");

        }
    }
}
