using Class;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Employee e = new Employee("", 0, 155, 1);
            e.print();
            Console.WriteLine(e.GetNetSalary());
        }
    }
}

namespace Class
{
    public class Employee
    {
        private string name;
        private int empno;
        private decimal basic;
        private short deptno;
        public string Name 
        { 
            get
            {
                return name;
            }

            set
            {
                //if (value.Length == 0)
                //{
                //    name = "Default Name";
                //}
                //else
                //{
                    name = value;
                //}
            }
        }

        public int EmpNo
        {
            set
            {
                if (value > 0)
                {
                    empno = value;
                }
            }
            get
            {
                return empno;
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
                if(value > 100 && value < 1000)
                {
                    basic = value;  
                }
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
                if (value > 0)
                {
                    deptno = value;
                }
            }
        }

        public Employee(string name, int empNo, decimal basic, short deptNo )
        {
            Name = name;
            EmpNo = empNo;
            Basic = basic;
            DeptNo = deptNo;
        }

        public decimal GetNetSalary()
        {
            return Basic * 100;
        }

        public void print()
        {
            Console.WriteLine(Name);
            Console.WriteLine(EmpNo);
            Console.WriteLine(Basic);
            Console.WriteLine(DeptNo);
        }
    }
}
