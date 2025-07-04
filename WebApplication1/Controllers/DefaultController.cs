using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index(int? id, int a=1, int b=1, int c=1)
        {
            Console.WriteLine(id);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            ViewBag.id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

                return View();
                       
        }

        public IActionResult Coustom(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"select * from Employees where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    ViewBag.EmpNo = dr["EmpNo"];
                    ViewBag.Name = dr["Name"];
                    ViewBag.Basic = dr["Basic"];
                    ViewBag.DeptNo = dr["DeptNo"];

                    Console.WriteLine("Employee Number      : " + dr["EmpNo"]);
                    Console.WriteLine("Employee Name        : " + dr["Name"]);
                    Console.WriteLine("Employee Basic       : " + dr["Basic"]);
                    Console.WriteLine("Employee Department  : " + dr["DeptNo"]);
                }
                else
                {
                    Console.WriteLine("No Employee Found With Employee Number : " + EmpNo);
                }
                //Console.WriteLine("Jai Shree Ram");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View();
        }
    }
}
