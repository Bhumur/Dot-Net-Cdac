namespace Assignment2
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();

            o1.Print();
            o2.Print(); 
            o3.Print();
            o4.Print();

        }
        static void Main(string[] args)
        {
            Employee o1 = new Employee();
            Employee o2 = new Employee();
            Employee o3 = new Employee();
            Console.WriteLine(o1.EmpNo); 
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o3.EmpNo);

            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o1.EmpNo);

        }
    }

    public class Employee
    {
        private string name;
        private int empno;
        private decimal basic;
        private short deptno;

        private static int autopara = 101;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length == 0)
                {
                    name = "no name";
                }
                else
                {
                    name = value;
                }
            }
        }
        public int EmpNo
        {
            get { return empno; }
        }
        
        public decimal Basic
        {
            get { return basic; }
            set
            {
                if(value > 100 && value<=10000)
                {
                    basic=value;
                }
                else
                {
                    basic = 101;
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
                if(value > 0)
                {
                    deptno = value;
                }
                else
                {
                    deptno =1;
                }
            }
        }

        public Employee(string Nname="noName", decimal basic=1234, short deptno=1)
        {
            Name = Nname;
            this.empno = autopara++;
            Basic = basic;
            DeptNo = deptno;
        }

        public decimal GetNetSalary()
        {
            return Basic * 125;
        }

        public void Print()
        {
            Console.WriteLine(EmpNo);
            Console.WriteLine(Name);
            Console.WriteLine(Basic);
            Console.WriteLine(DeptNo);
            Console.WriteLine(GetNetSalary());
            Console.WriteLine();
        }
    }
}
