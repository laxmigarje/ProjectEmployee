using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectEmployee.DAL;
using ProjectEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeedal;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeedal = new EmployeeDAL(configuration);
        }

        public ActionResult List()
        {
            var model = employeedal.GetAllEmployee();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int eid)
        {
            var employee = employeedal.GetEmployeeById(eid);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int res = employeedal.AddEmployee(emp);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET:EmployeeController/Edit/5
        public ActionResult Edit(int eid)
        {
            var employee = employeedal.GetEmployeeById(eid);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int res = employeedal.UpdateEmployee(emp);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int eid)
        {
            var employee = employeedal.GetEmployeeById(eid);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int eid)
        {
            try
            {
                int res = employeedal.DeleteEmployee(eid);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
    

