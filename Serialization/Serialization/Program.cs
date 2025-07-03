namespace SerializationExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o = new Class1();
        }

        [Serializable]
        public class Class1
        {
            public int i;

            private int p1;
        }
    }
}
