using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnrollmentApplication.Models;

namespace EnrollmentApplication.Controllers
{
    public class StudentsController : Controller
    {
        private EnrollmentDBContext EnrollmentDBContext = new EnrollmentDBContext();

        public ActionResult StudentOfTheMonth()
        {
            var student = GetStudent();
            return PartialView("_StudentOfTheMonth", student);

        }
    
        private Student GetStudent()
        {
            //Gets Random Student
            var student = EnrollmentDBContext.Students
                .OrderBy(a => System.Guid.NewGuid())
                .First();

            return student;
        }



        // GET: Students
        public ActionResult Index()
        {
            return View(EnrollmentDBContext.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = EnrollmentDBContext.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentLastName,StudentFirstName,Address1,Address2,City,Zipcode,State")] Student student)
        {
            if (ModelState.IsValid)
            {
                EnrollmentDBContext.Students.Add(student);
                EnrollmentDBContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = EnrollmentDBContext.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentLastName,StudentFirstName,Address1,Address2,City,Zipcode,State")] Student student)
        {
            if (ModelState.IsValid)
            {
                EnrollmentDBContext.Entry(student).State = EntityState.Modified;
                EnrollmentDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = EnrollmentDBContext.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = EnrollmentDBContext.Students.Find(id);
            EnrollmentDBContext.Students.Remove(student);
            EnrollmentDBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                EnrollmentDBContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
