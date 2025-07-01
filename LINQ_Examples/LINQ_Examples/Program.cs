using System.Transactions;

namespace LINQ_Examples
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            List<Name.Employee> employees = Name.Data.GetEmployeeList();
            List<Name.Department> departments = Name.Data.GetDepartmentList();


            var emps = from emp in employees
                       join dept in departments
                       on emp.DeptNo equals dept.DeptNo
                       //where emp.DeptNo==2
                       select new
                       {
                           emp.EmpNo,
                           emp.Name,
                           dept.DeptNo,
                           dept.DeptName
                       };

            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("123456789");


            var emps1 = emps.OrderBy(emp=>emp.Name).ThenByDescending(emp=>emp.DeptName);
            foreach (var item in emps1)
            {
                Console.WriteLine(item);
            }

        }
        static void Main()
        {
            List<Name.Employee> employees = Name.Data.GetEmployeeList();
            List<Name.Department> departments = Name.Data.GetDepartmentList();

            var emps = from emp in employees
                       group emp by emp.DeptNo;
            foreach (var item in emps)
            {
                Console.WriteLine(item.Key);
                foreach (var e in item)
                {
                    Console.WriteLine(e.EmpNo);
                    Console.WriteLine(e.Name);
                }
            }
        }
    }
}
