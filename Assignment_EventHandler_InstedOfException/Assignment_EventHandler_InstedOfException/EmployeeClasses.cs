using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace EmployeeClasses
{
    public delegate void InvalidNameEventHandler(String message);
    public delegate void InvalidDepartmentNumberEventHandler(String message);
    public delegate void InvalidBasicEventHandler(String message);

    public interface IDbFunctions
    {
        public void Print();
        public void Update();
        public void Delete();
    }
    public class Employee : IDbFunctions
    {
        private string? name;
        private int empno;
        private short deptno;
        private decimal basic;
        private static int autoEmpNo = 101;

        public event InvalidNameEventHandler InvalidName;
        public event InvalidDepartmentNumberEventHandler InvalidDepartmentNumber;
        public virtual event InvalidBasicEventHandler InvalidBasic;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "")
                {
                    InvalidName("Enter Valid Name");
                }else
                {
                    name= value;
                }
            }
        }

        public int EmpNo
        {
            get
            {
                return empno;
            }
        }

        public short DeptNo
        {
            get
            { 
                return deptno;
            }
            set
            {
                if(value < 1)
                {
                    InvalidDepartmentNumber("Department Number can't be 0 or negative");
                }
                deptno = value;
            }
        }

        public decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value < 100000)
                {
                    InvalidBasic("Employee Salary is Low");
                }
                else
                {
                    basic = value;
                }
            }

        }

        public Employee() 
        {
            this.empno = autoEmpNo++;
        }
        public Employee(string name, short deptno)
        {
            this.Name =  name;
            this.empno = autoEmpNo++;
            this.DeptNo = deptno;
        }
        public  decimal CalcNetSalary()
        {
            return Basic * 125;
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Employee is Manager");
            Console.WriteLine("Employee Number : " + this.EmpNo);
            Console.WriteLine("Employee Name : " + this.Name);
            Console.WriteLine("Employee Department Number : " + this.DeptNo);
            Console.WriteLine("Employee Basic : " + this.Basic);
            Console.WriteLine();
        }

        public void Update()
        {
            Console.WriteLine("Item Updated");
        }

        public void Delete()
        {
            Console.WriteLine("Item Deleted");
        }
    }
}


