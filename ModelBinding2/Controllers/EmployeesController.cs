using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        //Employees/Index
        public ActionResult Index()
        {
            List<Employee> emps = Employee.GetAllEmployees();
            //List<Employee> emps = new List<Employee>();
            //emps.Add(new Employee { EmpNo = 1, Name = "Aditi", Basic = 5, DeptNo = 1 });
            //emps.Add(new Employee { EmpNo = 2, Name = "Tejas", Basic = 2, DeptNo = 1 });
            //emps.Add(new Employee { EmpNo = 3, Name = "Jayashri", Basic = 10000, DeptNo = 1 });
            return View(emps);
        }

        // GET: EmployeesController/Details/5

        //Employees/Details/1
        public ActionResult Details(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Vikram";
            //obj.Basic = 12345;
            //obj.DeptNo = 10;

            return View(obj);
        }

        // GET: EmployeesController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create

        //IFormCollection
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        string name = collection["Name"];
        //        int empno = Convert.ToInt32( collection["EmpNo"]);
        //        int deptno = Convert.ToInt32(collection["DeptNo"]);
        //        decimal basic = Convert.ToDecimal(collection["Basic"]);

        //        Employee.Insert(new Employee()
        //        {
        //            Basic=basic,
        //            EmpNo=empno,
        //            Name=name,
        //            DeptNo=deptno
        //        });

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //Binding
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(int EmpNo, string Name, decimal Basic, int DeptNo)
        //{
        //    try
        //    {
        //        Employee.Insert(new Employee()
        //        {
        //            Basic = Basic,
        //            EmpNo = EmpNo,
        //            Name = Name,
        //            DeptNo = DeptNo
        //        });

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //Model Binding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                Employee.Insert(emp);
                ViewBag.message = "Success";
                return RedirectToAction(nameof(Index));
                //return View();
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }


        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }


        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        string name = collection["Name"];
        //        int empno = Convert.ToInt32(collection["EmpNo"]);
        //        int deptno = Convert.ToInt32(collection["DeptNo"]);
        //        decimal basic = Convert.ToDecimal(collection["Basic"]);

        //        Employee.Update(new Employee()
        //        {
        //            Basic = basic,
        //            EmpNo = empno,
        //            Name = name,
        //            DeptNo = deptno
        //        });
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                
                Employee.Update(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = Employee.GetSingleEmployee(id);
            return View(emp);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee emp)//Employee emp is not geting value because there is no form in View
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
