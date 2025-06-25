using Properties;

namespace ClassCode1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 obj = new Class1();
            
            obj.Set(12);
            Console.WriteLine(obj.Get());
            Console.WriteLine("Hello, World!");
        }
        static void Main(string[] args)
        {
            Class2 obj = new Class2();

            obj.a = 1;
            obj.a = ++obj.a + obj.a++ - --obj.a - obj.a--;
            Console.WriteLine(obj.a);
            Console.WriteLine("Hello, World!");
        }
    }
}

namespace Properties
{
    public class Class1
    {
        private int a;

        public void Set(int a)
        {
            this.a = a;
        }
        public int Get()
        {
            return this.a;
        }
    }
    public class Class2
    {
        public int a;

    }
}
