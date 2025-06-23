using one;

namespace ClassCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            one.Hello obj1 = new one.Hello();
            obj1.show();
            Console.WriteLine("Hello, World!");
        }
    }
}

namespace one
{
    public class  Hello()
    {
        public void show()
        {
            Console.WriteLine("i am form one");
        }
    }
}
