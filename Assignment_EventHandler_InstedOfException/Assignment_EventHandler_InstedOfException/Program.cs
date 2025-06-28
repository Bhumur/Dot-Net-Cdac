using EmployeeClasses;
using System.Xml.Linq;

namespace Assignment_EventHandler_InstedOfException
{
    internal class Program
    {
        
            static void Main(string[] args)
            {
                Console.Write("Enter Size of Employee Array : ");
                int n = Convert.ToInt32(Console.ReadLine());
                Employee[] employees = new Employee[n];
                int op, size = 0;
                do
                {
                    Console.WriteLine("Options :-");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Print Whole Array");
                    Console.WriteLine("3. Search Employee with EmpNo");
                    Console.WriteLine("4. Search Employee with Insertion Order");
                    Console.WriteLine("5. Employee With Higest Salary");
                    Console.WriteLine("6. Array to List  And then List to Array");
                    Console.WriteLine("0. EXIT");
                    Console.Write("Enter Your Choice : ");
                    op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            {
                            Console.Write("Enter Name of Employee : ");
                            string name = Console.ReadLine()!;
                            Console.Write("Enter Department Number :");
                            short deptno = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Enter Basic Salary of Employee : ");
                            decimal basic = Convert.ToDecimal(Console.ReadLine());
                            employees[size] = new Employee();
                            employees[size].InvalidName += NameInvalid;
                            employees[size].InvalidDepartmentNumber += DepartmentNumberInvalid;
                            employees[size].InvalidBasic += BasicInvalid;
                            employees[size].Name = name;
                            employees[size].Basic = basic;
                            employees[size].DeptNo = deptno;
                            Console.WriteLine();
                            Console.WriteLine("Employee Added Sucessfully");
                            employees[size].Print();
                            size++;
                            break;
                        }
                        case 2:
                            {
                                for (int i = 0; i < size; i++)
                                {
                                    employees[i].Print();
                                }
                                break;
                            }
                        case 3:
                            {
                                Boolean flag = false;
                                Console.Write("Enter Employee Number : ");
                                int emp = Convert.ToInt32(Console.ReadLine());
                                for (int i = 0; i < size; i++)
                                {
                                    if (employees[i].EmpNo == emp)
                                    {
                                        flag = true;
                                        employees[i].Print();
                                        break;
                                    }
                                }
                                if (!flag)
                                    Console.WriteLine("No Employee with " + emp + " Employee Number");
                                break;
                            }
                        case 4:
                            {
                                Console.Write("Enter Number : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                employees[num - 1].Print();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine();
                                int index = -1;
                                decimal sal = 0;
                                for (int i = 0; i < size; i++)
                                {
                                    if (sal < employees[i].Basic)
                                    {
                                        sal = employees[i].Basic;
                                        index = i;
                                    }
                                }
                                if (index == -1)
                                {
                                    Console.WriteLine("NO Employee Present");
                                }
                                else
                                {
                                    Console.WriteLine("Employee with Higest Salaey ");
                                    employees[index].Print();
                                }
                                break;
                            }
                        case 6:
                            {
                                List<Employee> empList = new List<Employee>();
                                empList = employees.ToList();
                                employees = empList.ToArray();
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
            }

        private static void Program_InvalidBasic(string message)
        {
            throw new NotImplementedException();
        }

        static void NameInvalid(string message)
        {
            Console.WriteLine(message);
        }
        static void DepartmentNumberInvalid(string message)
        {
            Console.WriteLine(message);
        }
        static void BasicInvalid(string message)
        {
            Console.WriteLine(message);
        }
        static void DesignationInvalid(string message)
        {
            Console.WriteLine(message);
        }
    }
}
