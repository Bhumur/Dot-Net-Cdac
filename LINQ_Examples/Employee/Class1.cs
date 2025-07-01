namespace Name
{

    
  public class Employee
    {
        private int empno;
        private string name;
        private decimal basic;
        private int deptno;
        private string gender;
        private static int autoEmpno = 1;

        public int EmpNo
        {
            get => empno;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public decimal Basic
        {
            get => basic;
            set => basic = value;
        }
        public int DeptNo
        {
            get => deptno;
            set => deptno = value;
        }
        public string Gender
        {
            get => gender;
            set => gender = value;
        }

        public Employee() { }
        public Employee(string name, decimal basic, int deptno, string gender)
        {
            this.empno = autoEmpno++;
            Name = name;
            Basic = basic;
            DeptNo = deptno;
            Gender = gender;
        }

        public override string ToString()
        {
            return "EmpNo : " + EmpNo + ", Name : " + Name + ", Gender : " + Gender + ", DeptNo : " + DeptNo + ", Basic : " + Basic;
        }
    }
    public static class Data
    {
        public static List<Employee> GetEmployeeList()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee("Bhumur", 15548,1 ,"Male"));
            list.Add(new Employee("Devdat", 12345, 2, "Male"));
            list.Add(new Employee("Anuj", 54278, 1, "TransGinger"));
            list.Add(new Employee("Bhumur", 15548, 1, "Male"));
            list.Add(new Employee("Devdat", 12345, 2, "Male"));
            list.Add(new Employee("Anuj", 54278, 1, "TransGinger"));
            list.Add(new Employee("Bhumur", 15548, 1, "Male"));
            list.Add(new Employee("Devdat", 12345, 3, "Male"));
            list.Add(new Employee("Anuj", 54278, 1, "TransGinger"));
            list.Add(new Employee("Bhumur", 15548, 1, "Male"));
            list.Add(new Employee("Devdat", 12345, 2, "Male"));
            list.Add(new Employee("Bhumur", 15548, 3, "Male"));
            list.Add(new Employee("Devdat", 12345, 2, "Male"));
            list.Add(new Employee("Anuj", 54278, 3, "TransGinger"));
            list.Add(new Employee("Anuj", 54278, 1, "TransGinger"));

            return list;
        }

        public static List<Department> GetDepartmentList()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department(1, "Manager")); 
            list.Add(new Department(2, "Sales"));
            list.Add(new Department(3, "Operation"));
            return list;
        }

    }

    public class Department
    {
        private int deptno;
        private string deptname;
        
        public int DeptNo
        {
            get => deptno;
            set => deptno = value;
        }

        public string DeptName
        {
            get => deptname;
            set => deptname = value;
        }

        public Department()
        {

        }

        public Department(int deptno, string deptname)
        {
            DeptNo = deptno;
            DeptName = deptname;
        }
        public override string ToString()
        {
            return "Department Number : " + DeptNo + ", Department Number : " + DeptName;
        }

    }


}
    

