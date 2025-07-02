using System.Threading.Tasks;

namespace TaskExample
{
    internal class Program
    {
        static void MainNormal(string[] args)
        {
            Task t1 = new Task(new Action(Fun1));
            Task t2 = new Task(Fun1);
            Task t3 = Task.Run(Fun1);  
            t1.Start();
            //t1.Wait();
            //Console.ReadLine();
        }

        public static void Fun1()
        {
            Console.WriteLine("Fun1 is called i : " );
        }

        static void MainFunctionWithParameter(string[] args)
        {
            Task t1 = new Task(new Action<Object>(Fun2), "legacy way");
            t1.Start();
            Task t2 = new Task(Fun2, "Without Action");
            t2.Start();

            Task t3 = Task.Factory.StartNew(Fun2, "Factory wala");
            string s = "Normal Run";
            Task t4 = Task.Run(() => Console.WriteLine(s));
            Console.Read();
        }

        static void Fun2(object o)
        {
            Console.WriteLine(o.ToString());
        }

        static void MainFunctionWithReturn()
        {
            Task<string> t1 = new Task<string>(Fun3, "Legacy");
            t1.Start();
            Thread.Sleep(1);
            //Console.WriteLine(t1.Result);


            Task<string> t2 = new Task<string>(Fun3, "Just After Legacy");
            t2.Start();
            Console.WriteLine(t1.Result);
            Console.WriteLine(t2.Result);
        }

        static string Fun3(object o)
        {
            Thread.Sleep(2500);
            return o.ToString().ToUpper();
        }

        static async Task Main()
        {
            Task<int> t1 = new Task<int>(Fun4);
            t1.Start();
            Console.WriteLine(t1.Result);

            int i = await Fun4Async();

            Console.WriteLine(i);
        }

        static int Fun4()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Function 4 is Called");
            return 10;
        }
        static async Task<int> Fun4Async()
        {
            Thread.Sleep(2000);
            Console.WriteLine("FunctionAsync 4 is Called");
            return await Task.Run(() => { 
                return 10; 
            });
        }
    }
}
