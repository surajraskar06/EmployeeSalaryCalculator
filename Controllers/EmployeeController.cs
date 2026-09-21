using EmployeeSalaryCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSalaryCalculator.Controllers
{
    public class EmployeeController : Controller
    {
        DailyTaskContext db;
        public EmployeeController()
        {
            db = new DailyTaskContext();
        }
        public IActionResult Index()
        {
            ViewData["employee"] = db.TblEmployeeSalaries.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(TblEmployeeSalary es)
        {
            es.HouseRentAllowance = es.BasicSalary * 20 / 100;
            es.DearnessAllowance = es.BasicSalary * 10 / 100;
            es.ProvidentFund = es.BasicSalary * 12 / 100;

            es.GrossSalary = es.BasicSalary + es.DearnessAllowance + es.HouseRentAllowance;
            es.NetSalary = es.GrossSalary - es.ProvidentFund;

            db.TblEmployeeSalaries.Add(es);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.mes = "Employee Details Saved Successfully ..!";
            ViewData["employee"] = db.TblEmployeeSalaries.ToList();
            return View();
        }

        public IActionResult Edit(int id)
        {
            TblEmployeeSalary es = db.TblEmployeeSalaries.Find(id);
            return View(es);
        }
        [HttpPost]
        public IActionResult Edit(TblEmployeeSalary st)
        {
            st.HouseRentAllowance = st.BasicSalary * 20 / 100;
            st.DearnessAllowance = st.BasicSalary * 10 / 100;
            st.ProvidentFund = st.BasicSalary * 12 / 100;

            st.GrossSalary = st.BasicSalary + st.DearnessAllowance + st.HouseRentAllowance;
            st.NetSalary = st.GrossSalary - st.ProvidentFund;


            db.TblEmployeeSalaries.Update(st);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            TblEmployeeSalary ts = db.TblEmployeeSalaries.Find(id);
            db.TblEmployeeSalaries.Remove(ts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SalarySlip(int id)
        {
            TblEmployeeSalary tes = db.TblEmployeeSalaries.Find(id);
            if (tes == null)
            {
                return RedirectToAction("Index");
            }
            return View(tes);
        }
        
    }
}
