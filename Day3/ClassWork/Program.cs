namespace ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Shape s = new ChessBoard();
            s.Area();
        }

        public class Shape
        {
            public virtual void Area()
            {
                Console.WriteLine("shape area");
            }
        }

        public class Quadrilateral : Shape
        {
            public override void Area()
            {
                Console.WriteLine("shape area");
            }
        }

        public class Square : Quadrilateral
        {
            public override sealed void Area()
            {
                Console.WriteLine("shape sqare");
            }
        }

        public class ChessBoard : Square
        {
            public  void Area()
            {
                Console.WriteLine("shape chess");
            }
        }

        public sealed class ClassSealed
        {
            public void show()
            {
                Console.WriteLine("hello form sealed");
            }
        }

        //public class notSealed : ClassSealed
        //{

        //}
    }
}
