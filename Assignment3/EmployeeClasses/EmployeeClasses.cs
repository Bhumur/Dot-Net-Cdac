using AllExceptions;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace EmployeeClasses
{
    public interface IDbFunctions
    {
        public void Print();
        public void Update();
        public void Delete();
    }
    public abstract class Employee : IDbFunctions
    {
        private string? name;
        private int empno;
        private short deptno;
        private decimal basic;
        private static int autoEmpNo = 101;
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
                    throw new InvalidNameException("Provide name");
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
                    throw new InvalidDepartmentNumberException("Department Number can't be 0 or negative");
                }
                deptno = value;
            }
        }

        public abstract decimal Basic { get; set; }

        public Employee(string name, short deptno)
        {
            this.Name =  name;
            this.empno = autoEmpNo++;
            this.DeptNo = deptno;
        }
        public abstract decimal CalcNetSalary();
        public abstract void Print();
        public abstract void Update();
        public abstract void Delete();
    }

    public class Manager : Employee, IDbFunctions
    {
        private string? designation;
        private decimal basic;

        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                if(value == "")
                {
                    throw new InvalidDesignationException("Provide Designation");
                }else
                {
                    designation = value;
                }
            }
        }
        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value < 100000)
                {
                    throw new InvalidBasicException("CEO Salary is Low");
                }
                else
                {
                    basic = value;
                }
            }

        }

        public Manager(string name, short deptno, string designation, decimal basic):base(name,deptno)
        {
            this.Designation = designation;
            this.Basic = basic;
        }


        public override decimal CalcNetSalary()
        {
            return Basic * 125;
        }

        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Employee is Manager");
            Console.WriteLine("Employee Number : "+ this.EmpNo);
            Console.WriteLine("Employee Name : " + this.Name);
            Console.WriteLine("Employee Department Number : " + this.DeptNo);
            Console.WriteLine("Employee Basic : " + this.Basic);
            Console.WriteLine("Employee Designation : " + this.Designation);
            Console.WriteLine();
        }

        public override void Update()
        {
            Console.WriteLine("Item Updated");
        }

        public override void Delete()
        {
            Console.WriteLine("Item Deleted");
        }
    }

    public class GeneralManager : Manager, IDbFunctions
    {
        private string? perks;
        private decimal basic;
        public string Perks 
        {
            get
            {
                return this.perks!;
            }
            set
            {
                this.perks = value;
            }
        }
        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value < 1000000)
                {
                    throw new InvalidBasicException("GM Salary is Low");
                }
                else
                {
                    basic = value;
                }
            }

        }

        public GeneralManager(string name, short deptno, string designation, string perks, decimal basic):base(name,deptno,designation,basic)
        {
            this.Perks = perks;
            this.Basic = basic;
        }

        public override decimal CalcNetSalary()
        {
            return Basic * 112;
        }

        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Employee is General Manager");
            Console.WriteLine("Employee Number : " + this.EmpNo);
            Console.WriteLine("Employee Name : " + this.Name);
            Console.WriteLine("Employee Department Number : " + this.DeptNo);
            Console.WriteLine("Employee Basic : " + this.Basic);
            Console.WriteLine("Employee Designation : " + this.Designation);
            Console.WriteLine("Employee Perks : " + this.Perks);
            Console.WriteLine();
        }

        public override void Update()
        {
            Console.WriteLine("Item Updated");
        }

        public override void Delete()
        {
            Console.WriteLine("Item Deleted");
        }
    }

    public class CEO : Employee, IDbFunctions
    {
        private decimal basic;
        public override decimal Basic
        {
            get
            {
                return basic;
            }

            set
            {
                if(value<10000000)
                {
                    throw new InvalidBasicException("CEO Salary is Low");
                }
                else
                {
                    basic = value;
                }
            }
        }

        public CEO(string name, short deptno, decimal basic) : base(name, deptno) 
        {
            this.Basic = basic;
        }
        public override sealed decimal CalcNetSalary()
        {
            return Basic * 200;
        }

        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Employee is CEO");
            Console.WriteLine("Employee Number : " + this.EmpNo);
            Console.WriteLine("Employee Name : " + this.Name);
            Console.WriteLine("Employee Department Number : " + this.DeptNo);
            Console.WriteLine("Employee Basic : " + this.Basic);
            Console.WriteLine();
        }

        public  override void Update()
        {
            Console.WriteLine("Item Updated");
        }

        public override void Delete()
        {
            Console.WriteLine("Item Deleted");
        }
    }
}

namespace AllExceptions
{
    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException(String message):base(message) { }
    }


    public class InvalidDepartmentNumberException : ApplicationException
    {
        public InvalidDepartmentNumberException(String message) : base(message) { }
    }

    public class InvalidBasicException : ApplicationException
    {
        public InvalidBasicException(String message) : base(message) { }
    }
    
    public class InvalidDesignationException : ApplicationException
    {
        public InvalidDesignationException(String message) : base(message) { }
    }
}

