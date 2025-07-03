using Microsoft.Data.SqlClient;
namespace DataBases
{
    internal class Program
    {
        static void Main()
        {
            //Connect();

            //Insert();

            //Employee emp = new Employee();
            //emp.Name = "HelloBaabd";
            //emp.EmpNo = 10;
            //emp.Basic = 166563;
            //emp.DeptNo = 10;
            //Insert(emp);

            //Employee employee = new Employee() { EmpNo = 11, Name = "dDnsiniwd #o @ ojo", DeptNo = 20, Basic = 115 };
            //Insert(employee);


            //Employee emp = new Employee() { EmpNo = 12, Name = "Sagar", DeptNo = 10, Basic = 561 };
            //InsertWithParameter(emp);

            //Employee emp = new Employee() { EmpNo = 13, Name = "Hero", DeptNo = 10, Basic = 561 };
            //InsertWithStoreProcedure(emp);

            //Select();

            SelectSqlDATAREADER();


        }

        public class Employee
        {
            public int EmpNo { get; set; }  

            public string Name { get; set; }

            public decimal Basic { get; set; }

            public int DeptNo {  get; set; }    
        }
        static void Connect()
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

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
        static void Insert()
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Employees values(9,'UDAY',150000,20)";
                cmd.ExecuteNonQuery();

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
        static void Insert(Employee obj)
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";
                cmd.ExecuteNonQuery();

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
        static void InsertWithParameter(Employee obj)
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";

                cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.ExecuteNonQuery();

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

        static void UpdateWithParameter(Employee obj)
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;
                
                //cmd.CommandText = "update Employees set Name='@Name', Basic=@Basic, DeptNo=@DeptNo where EmpNo;
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.ExecuteNonQuery();

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

        static void InsertWithStoreProcedure(Employee obj)
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";
                cmd.CommandText = "InsertEmployees";
                //cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.ExecuteNonQuery();

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

        static void Select()
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;


                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "select Name from Employees where EmpNo=1";
                //object retval = cmd.ExecuteScalar();


                //Only 1st value came
                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "select * from Employees where EmpNo=1";
                //object retval = cmd.ExecuteScalar();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select count(*) from Employees";
                object retval = cmd.ExecuteScalar();

                Console.WriteLine(retval);

                cmd.ExecuteNonQuery();

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

        static void SelectSqlDATAREADER()
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;



                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees";
                //object retval = cmd.ExecuteScalar();


                
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) 
                {
                    Console.WriteLine();
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr[1]);
                    Console.WriteLine();
                }

                dr.Close();


                //Console.WriteLine(retval);

                cmd.ExecuteNonQuery();

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
