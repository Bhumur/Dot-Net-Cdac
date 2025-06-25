namespace Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Class1 o = new Class1();
            o.Pro1 = 100;

            o.Pro1 = ++o.Pro1 + o.Pro1++ - --o.Pro1 - o.Pro1--;
            //o.Pro2 = 22;
            Console.WriteLine(o.Pro1);
            //Console.WriteLine(o.Pro2);
        }
    }

    public class Class1
    {
        private int pro1;

        public int Pro1
        {
            set
            {
                pro1 = value;
            }
            get
            {
                return pro1;
            }
        }

        public int Pro2
        {
            set
            {
                pro1= value;
            }
            get
            {
                return pro1;
            }
        }
    }
}
