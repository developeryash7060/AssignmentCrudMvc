using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentCrudMvc.Models;

namespace AssignmentCrudMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private CrudDBContext db = new CrudDBContext();

        
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Salary);
            var orderedlist = from e in employees
                              orderby e.Salary.Amount descending,e.Name
                              select e;
                              
            return View(orderedlist.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Departments, "Id", "DeptName");
            ViewBag.Id = new SelectList(db.Salaries, "EmpId", "EmpId");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DOJ,Mobile,Email,Address,DeptId,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Departments, "Id", "DeptName", employee.DeptId);
            ViewBag.Id = new SelectList(db.Salaries, "EmpId", "EmpId", employee.Id);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Departments, "Id", "DeptName", employee.DeptId);
            ViewBag.Id = new SelectList(db.Salaries, "EmpId", "EmpId", employee.Id);
            return View(employee);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DOJ,Mobile,Email,Address,DeptId,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Salary.Id = employee.Id;
                db.Entry(employee.Salary).State = EntityState.Modified;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Departments, "Id", "DeptName", employee.DeptId);
            ViewBag.Id = new SelectList(db.Salaries, "EmpId", "EmpId", employee.Id);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            Salary salary = db.Salaries.FirstOrDefault(o => o.Id == id);
            db.Salaries.Remove(salary);
            db.Employees.Remove(employee);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
