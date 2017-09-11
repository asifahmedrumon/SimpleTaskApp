using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleTaskApp.Models;

namespace SimpleTaskApp.Controllers
{
    public class TaskModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskModels
        public ActionResult Index()
        {
            return View(db.TaskModels.ToList());
        }

        // GET: TaskModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskModels taskModels = db.TaskModels.Find(id);
            if (taskModels == null)
            {
                return HttpNotFound();
            }
            return View(taskModels);
        }

        // GET: TaskModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTask,TaskName,Description,CreatedAt,UpdatedAt")] TaskModels taskModels)
        {
            if (ModelState.IsValid)
            {
                taskModels.CreatedAt = Convert.ToString(DateTime.Now);
                db.TaskModels.Add(taskModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskModels);
        }

        // GET: TaskModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskModels taskModels = db.TaskModels.Find(id);
            if (taskModels == null)
            {
                return HttpNotFound();
            }
            return View(taskModels);
        }

        // POST: TaskModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTask,TaskName,Description,CreatedAt,UpdatedAt")] TaskModels taskModels)
        {
            if (ModelState.IsValid)
            {
                taskModels.UpdatedAt = Convert.ToString(DateTime.Now);
                db.Entry(taskModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskModels);
        }

        // GET: TaskModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskModels taskModels = db.TaskModels.Find(id);
            if (taskModels == null)
            {
                return HttpNotFound();
            }
            return View(taskModels);
        }

        // POST: TaskModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskModels taskModels = db.TaskModels.Find(id);
            db.TaskModels.Remove(taskModels);
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
