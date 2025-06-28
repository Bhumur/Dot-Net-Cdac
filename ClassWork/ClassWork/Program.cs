using System.Reflection;

namespace ClassWork
{
    internal class Program
    {

        public delegate void Del1(ref int a, ref int b);
        
        static void Main(string[] args)
        {
            Del1 obj = Swap;
            obj += Swap;

           

            int a = 1;
            int b = 2;
            //Swap(ref a, ref b);
            //Action<ref int a, ref int b> objAction = Swap;
            Action<int, int> objAdd = Add;
            objAdd(1, 5);
            Console.WriteLine(a + " " + b);
            obj(ref a, ref b);
            Console.WriteLine(a + " " + b);
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Add (int a, int b)
        {
            Console.WriteLine(a+b);
        }
    }
}

