namespace ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Class1 o = new Class1();
            o.Pro1 = "hello ";
            o.Pro2 = "secy"; 
            Console.WriteLine(o.Pro1+"kk"+o.Pro2);

            //ClassStatic obj = new ClassStatic();
        }
    }

    public static class ClassStatic
    {
        public static void hello()
        {
            Console.WriteLine("form static hello");
        }
    }
    public class Class1 //: ClassStatic
    {
        private string pro1;

        public string Pro2 { get; set; }
        public string Pro1
        {
            get
            {
                return pro1;
            }
            set
            {
                pro1 = value;
            }
        }
    }
}
