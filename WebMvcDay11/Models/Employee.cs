using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebMvcDay11.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Please Enter Employee Number")]
        [Display(Name = "Employee Number")]
        public int EmpNo { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Basic Salary")]
        [Display(Name = "Employee Basic Salary")]
        [Range(10000, 1000000, ErrorMessage = "Salary Should be in 10k to 10L")]
        public decimal Basic { get; set; }

        [Required(ErrorMessage = "Please Enter Department Number")]
        [Display(Name = "Employee Department Number")]
        [AllowedValues(10, 20, 30, ErrorMessage = "Values Should be In 10,20,30")]
        public int DeptNo { get; set; }

        static void InsertWithStoreProcedure(Employee obj)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployees";
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Employee Added Successfully....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        static void SelectEmployeeWithEmpno(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SelectEmployeeWithEmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    Console.WriteLine("Employee Number      : " + dr["EmpNo"]);
                    Console.WriteLine("Employee Name        : " + dr["Name"]);
                    Console.WriteLine("Employee Basic       : " + dr["Basic"]);
                    Console.WriteLine("Employee Department  : " + dr["DeptNo"]);
                }
                else
                {
                    Console.WriteLine("No Employee Found With Employee Number : " + EmpNo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        static void DeleteWithEmpNo(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployeeWithEmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Employee Deleted With Employee Number : " + EmpNo);
                }
                else
                {
                    Console.WriteLine("No Employee Found With Employee Number : " + EmpNo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        static void ShowAllEmployee()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine("Employee Number      : " + dr["EmpNo"]);
                    Console.WriteLine("Employee Name        : " + dr["Name"]);
                    Console.WriteLine("Employee Basic       : " + dr["Basic"]);
                    Console.WriteLine("Employee Department  : " + dr["DeptNo"]);
                    Console.WriteLine();
                }

                dr.Close();

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
        }
        static void AllEmployee()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            List<Employee> empList = new List<Employee>();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    empList.Add(new Employee()
                    {
                        EmpNo = 
                    });
                    Console.WriteLine();
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr[1]);
                    Console.WriteLine();
                }

                dr.Close();

                Console.WriteLine("Jai Shree Ram");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
