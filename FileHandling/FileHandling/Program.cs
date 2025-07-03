using System.Text;

namespace FileHandling
{
    internal class Program
    {
        static void MainSystemIO(string[] args)
        {
            /// Drive
            DriveInfo drive = new DriveInfo("D");
            //drive.
            //if(drive.DriveType==DriveType)



            Directory.CreateDirectory("D:\\new");

            DirectoryInfo dr = new DirectoryInfo("D:\\aaa");
            //dr.

            File.Create("D:\\aaa\\a.txt");
            //File.
        }

        static void Main(string[] args)
        {
            string s = "Hello World\n Line 2";
            byte[] arr = Encoding.Default.GetBytes(s);

            Directory.CreateDirectory("E://aaaa");
            //File.Create("E://aaaa//a.txt");
            FileStream stream = File.Open("E:\\aaaa\\a.txt", FileMode.Create);

            stream.Write(arr, 0, arr.Length);
            //stream.Read();

            stream.Close();
        }
    }
}
