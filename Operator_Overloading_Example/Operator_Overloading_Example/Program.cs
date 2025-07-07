namespace Operator_Overloading_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.EmpName = "Bhumur";
            employee.EmpNo = 1;
            Employee a =  employee + 11;
            Console.WriteLine(employee);
            Console.WriteLine(a);

            Employee father = new Employee();
            father.EmpName = "father";
            father.EmpNo = 1;
            Employee mother = new Employee();
            mother.EmpName = "mother";
            mother.EmpNo = 2;
            using (Employee child = new Employee())
            {
                Employee x = father * mother;
                child.EmpName = x.EmpName;
                child.EmpNo = x.EmpNo;
                Console.WriteLine(child);
            }
            
        }
    }

    public class Employee : IDisposable
    {
        private int empNo;
        private string? empName;

        public int EmpNo { get; set; }
        public string? EmpName { get; set; }

        public Employee() { }


        public override string ToString()
        {
            return "Employee Number : " + EmpNo + ", Employee Name : " + EmpName;
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed called for " + EmpName);
        }

        public static Employee operator+ (Employee a, int b)
        {
            a.EmpNo = a.EmpNo + b;
            return a;
        }

        public static Employee operator* (Employee a, Employee b)
        {
            Employee c = new Employee();
            c.EmpNo = a.EmpNo + b.EmpNo;
            c.EmpName = a.EmpName + b.EmpName;
            return c;
        }
    }
}
