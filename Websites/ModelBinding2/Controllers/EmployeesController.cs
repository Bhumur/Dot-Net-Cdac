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
            //if (obj == null)
            //    return NotFound();
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
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Model Binding - property names should be same Html control Names 
        public ActionResult Create(Employee obj)
        {
            try
            {
                Employee.Insert(obj);
                ViewBag.message = "success";

                return View();
                //return RedirectToAction("Index");
                //return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }


        ////Binding - parameter names should be same Html control Names 
        //public ActionResult Create(int EmpNo, string Name, decimal Basic, int DeptNo)
        //{
        //    try
        //    {
        //        return RedirectToAction("Index");
        //        //return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        string EmpNo = collection["EmpNo"];
        //        string Name = collection["Name"];
        //        string Basic = collection["Basic"];
        //        string DeptNo = collection["DeptNo"];

        //        return RedirectToAction("Index");
        //        //return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.Update(obj);
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
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee obj)
        {
            try
            {
                Employee.Delete(id);
                //Employee.Delete2(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
