using Microsoft.Data.SqlClient;
using System.Data;
namespace DataBases
{
    internal class Program
    {
        static void Main()
        {

            int op;
            do
            {
                Console.WriteLine();
                Console.WriteLine("OPTIONS :-");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Show Employee With EmpNo");
                Console.WriteLine("4. Delete Employee with EmpNo");
                Console.WriteLine("5. Show All Employees");
                Console.WriteLine("6. Show All Employees with Department Number");
                Console.WriteLine();
                Console.Write("Enter Your Choice :- ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            Console.WriteLine("-----Adding Employee------");
                            Console.Write("Enter Employee Number    : ");
                            int empno = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Employee Name      : ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Employee Basic     : ");
                            decimal basic = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter Department Number  : ");
                            int deptno = Convert.ToInt32(Console.ReadLine());
                            Employee emp = new Employee() { Name=name, EmpNo=empno, Basic=basic, DeptNo=deptno};
                            InsertWithStoreProcedure(emp);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("-----Update Employee------");
                            Console.Write("Enter Employee Number    : ");
                            int empno = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Employee Name      : ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Employee Basic     : ");
                            decimal basic = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter Department Number  : ");
                            int deptno = Convert.ToInt32(Console.ReadLine());
                            Employee emp = new Employee() { Name = name, EmpNo = empno, Basic = basic, DeptNo = deptno };
                            UpdateWithParameter(emp);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("-----Show Employee With EmpNo------");
                            Console.Write("Enter Employee Number    : ");
                            int empno = Convert.ToInt32(Console.ReadLine());
                            SelectEmployeeWithEmpno(empno);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("-----Delete Employee With EmpNo------");
                            Console.Write("Enter Employee Number    : ");
                            int empno = Convert.ToInt32(Console.ReadLine());
                            DeleteWithEmpNo(empno);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("-----Show All Employees------");
                            ShowAllEmployee();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("-----Show All Employees With Department Number------");
                            Console.Write("Enter Department Number    : ");
                            int deptno = Convert.ToInt32(Console.ReadLine());
                            ShowAllEmployeeWithDeptNo(deptno);
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("INVALID INPUT");
                            break;
                        }
                }
            } while (op != 0);

            //Connect();

            //Insert();

            //Employee emp = new Employee();
            //emp.Name = "HelloBaabd";
            //emp.EmpNo = 2;
            //emp.Basic = 166563;
            //emp.DeptNo = 10;
            //Insert(emp);

            //Employee employee = new Employee() { EmpNo = 3, Name = "AnyName", DeptNo = 20, Basic = 115 };
            //Insert(employee);


            //Employee emp = new Employee() { EmpNo = 12, Name = "Sagar", DeptNo = 10, Basic = 561 };
            //InsertWithParameter(emp);

            //Employee emp = new Employee() { EmpNo = 4e, Name = "Hero", DeptNo = 10, Basic = 561 };
            //InsertWithStoreProcedure(emp);

            //Select();

            //SelectSqlDATAREADER();

            //SelectMARS();
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
            conn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ActsJune25;Integrated Security=True;";

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
                cmd.CommandText = "insert into Employees values(1,'UDAY',150000,20)";
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
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Employee Updated Succesfully....");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Employee Not Updated....");
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

            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployees";
                //cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
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


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select Name from Employees";
                object retval = cmd.ExecuteScalar();


                //Only 1st value came
                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "select * from Employees where EmpNo=1";
                //object retval = cmd.ExecuteScalar();


                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "select count(*) from Employees";
                //object retval = cmd.ExecuteScalar();

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
                    Console.WriteLine("No Employee Found With Employee Number : "+EmpNo);
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

                if (cmd.ExecuteNonQuery()>0)
                {
                    Console.WriteLine("Employee Deleted With Employee Number : " + EmpNo);
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

        static void ShowAllEmployeeWithDeptNo(int DeptNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SelectWithDepartmentNumber";
                cmd.Parameters.AddWithValue("@DeptNo", DeptNo);

                SqlDataReader dr = cmd.ExecuteReader();
                List<Employee> list = new List<Employee>();
                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine("Employee Number      : " + dr["EmpNo"]);
                    Console.WriteLine("Employee Name        : " + dr["Name"]);
                    Console.WriteLine("Employee Basic       : " + dr["Basic"]);
                    Console.WriteLine("Employee Department  : " + dr["DeptNo"]);
                    Console.WriteLine();
                    list.Add(new Employee() {EmpNo= dr.GetInt32("EmpNo"), });
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
        static void SelectSqlDATAREADER()
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


        static void SelectMARS()
        {
            SqlConnection conn = new SqlConnection();

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;MultipleActiveResultSets=true;";


            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;



                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees;select * from Departments";



                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr[1]);
                    Console.WriteLine();
                }
                dr.NextResult();
                Console.WriteLine();
                Console.WriteLine("Departments");
                Console.WriteLine();
                while (dr.Read())
                {
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

        static void TransactionInsert()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;MultipleActiveResultSets=true;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;



                cmd.CommandType = CommandType.Text;
                



                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr[1]);
                    Console.WriteLine();
                }
                dr.NextResult();
                Console.WriteLine();
                Console.WriteLine("Departments");
                Console.WriteLine();
                while (dr.Read())
                {
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
