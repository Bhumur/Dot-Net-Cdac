namespace Task_Parallel_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1234);
                arr[i] = i * 321;
                Console.WriteLine("Single Thread : " + arr[i]);
            }


            Parallel.For(0, 4, (int i) =>
            {
                Thread.Sleep(1234);
                arr[i] = i * 123;
                Console.WriteLine("Parallel Threads : " + arr[i]);
            });
        }

        
        
        
        
        
        
    }
}
