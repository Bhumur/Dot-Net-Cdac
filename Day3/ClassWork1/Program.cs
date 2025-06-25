using ClassIntefcae;

namespace ClassWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            I2 o = new Class1();
            Console.WriteLine(o.m1());
            Console.WriteLine(o.m2());
            Console.WriteLine(o.m3());
            Console.WriteLine(o.m4());
        }

        public class Class1 : I2
        {
            public int m1()
            {
                return 1;
            }

            public int m2()
            {
                return 2;
            }

            public int m3()
            {
                return 3;
            }

            public int m4()
            {
                return 4;
            }
        }
    }
}

namespace ClassIntefcae
{
    public interface I1
    {
        public int m1();

        public int m2();
    }

    public interface I2 : I1
    {
        public int m3();
        public int m4();

    }
}
