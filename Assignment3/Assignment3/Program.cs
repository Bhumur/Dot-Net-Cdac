using EmployeeClasses;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number of Batches in CDAC : ");
            int numberOfBatch = Convert.ToInt32(Console.ReadLine());
            int[][] batches = new int[numberOfBatch][];
            for(int i=0;i<numberOfBatch; i++)
            {
                Console.Write("Number of Students in " + (i+1) +" th Batch : ");
                int sizeOfStudents = Convert.ToInt32(Console.ReadLine());
                batches[i] = new int[sizeOfStudents];
                for(int j=0;j< batches[i].Length; j++)
                {
                    Console.Write("Enter Marks of "+ (j+1) + "th Student of " + (i+1) + "th Batch : ");
                    batches[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for(int i=0; i<numberOfBatch; i++)
            {
                Console.WriteLine("Batch " + i+1 + " Marks : ");
                for(int j=0;j< batches[i].Length; j++)
                {
                    Console.WriteLine("Marks of " + (j+1) + "th Student of " + (i+1) + "th Batch is : " + batches[i][j]);
                }
                Console.WriteLine();
            }
        }

        static void Main1(string[] args)
        {
            Console.Write("Enter Size of Employee Array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Employee[] employees = new Employee[n];
            int op, size=0;
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
                            AddEmployee(employees, ref size);
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
                            employees[num-1].Print();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine();
                            int index = -1;
                            decimal sal = 0;
                            for(int i = 0; i < size; i++)
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
                            }else
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
                            //for (int i = 0; i < size; i++)
                            //{
                            //    empList.Add(employees[i]);
                            //}

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
        static void AddEmployee(Employee[] emp, ref int size)
        {
            Console.WriteLine("Types of Employees :-");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. General Manager");
            Console.WriteLine("3. CEO");
            Console.Write("Enter Type Of Employee Want to Add : ");
            int op = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter Name of Employee : ");
            string name= Console.ReadLine()!;
            Console.Write("Enter Department Number :");
            short deptno = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter Basic Salary of Employee : ");
            decimal basic = Convert.ToDecimal(Console.ReadLine());
            switch(op)
            {
                case 1:
                    {
                        Console.Write("Enter Designation : ");
                        string designation = Console.ReadLine()!;
                        emp[size] = new Manager(name,deptno,designation,basic);
                        Console.WriteLine();
                        Console.WriteLine("Employee Added Sucessfully");
                        emp[size].Print();
                        size++;
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter Designation : ");
                        string designation = Console.ReadLine()!;
                        Console.Write("Enter Perks : ");
                        string perks = Console.ReadLine()!;
                        emp[size] = new GeneralManager(name, deptno, designation, perks, basic);
                        Console.WriteLine();
                        Console.WriteLine("Employee Added Sucessfully");
                        emp[size].Print();
                        size++;
                        break;
                    }
                case 3:
                    {
                        emp[size] = new CEO(name, deptno, basic);
                        Console.WriteLine();
                        Console.WriteLine("Employee Added Sucessfully");
                        emp[size].Print();
                        size++;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("INVALID INPUT");
                        Console.WriteLine();
                        Console.WriteLine("No Employee Added");
                        break;
                    }
                    Console.WriteLine();
            }
        }
    }
}
