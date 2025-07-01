namespace Day6
{
    public static class ExtendMethod
    {
        public static void Display(this Fun1 i)
        {
            Console.WriteLine("Tere ANaaama");
        }
    }
    internal class Program
    {
        static void Main()
        {
            //int i = 100;
            //var j = 100;

            //i.Display();

            //j = 200;
            //j = "aa";

            //var obj = new {a=1, b="aaa", c=true};

            //Console.WriteLine(obj);

            //var obj1 = new { a = 1,  b = "aaa" };


            //Console.WriteLine(obj1);
            //Console.WriteLine(obj.GetType());
            //Console.WriteLine(obj1.GetType());


            //var objFun1 = new Fun1();
            //objFun1.I = i;
            //objFun1.J = j;
            //Console.WriteLine(objFun1.I);
            //Console.WriteLine(objFun1.J);

            //objFun1.validate();
            //objFun1.Display();

            char l = 'k';
            float n = 19.0f;
            int b = Convert.ToInt32(l / n);
            int c = Convert.ToInt32(5.45);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

    }
    public partial class Fun1
    {
        private int i = 100;

        public int J
        {
            get => j;
            set => j = value;
        }

        public partial void validate();
    }

    public partial class Fun1
    {
        private int j = 200;

        public int I
        {
            get => i;
            set => i = value;
        }

        public partial void validate()
        {
            Console.WriteLine("Partial Method");
        }
    }
}
