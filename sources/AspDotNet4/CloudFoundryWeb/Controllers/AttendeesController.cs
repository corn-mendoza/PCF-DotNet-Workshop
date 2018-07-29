using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudFoundryWeb.Models;

namespace CloudFoundryWeb.Controllers
{
    public class AttendeesController : Controller
    {
        private AttendeeContext db = new AttendeeContext();

        // GET: Attendees
        public ActionResult Index()
        {
            return View(db.AttendeeModels.ToList());
        }

        // GET: Attendees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendeeModel attendeeModel = db.AttendeeModels.Find(id);
            if (attendeeModel == null)
            {
                return HttpNotFound();
            }
            return View(attendeeModel);
        }

        // GET: Attendees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Title,Department")] AttendeeModel attendeeModel)
        {
            if (ModelState.IsValid)
            {
                db.AttendeeModels.Add(attendeeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendeeModel);
        }

        // GET: Attendees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendeeModel attendeeModel = db.AttendeeModels.Find(id);
            if (attendeeModel == null)
            {
                return HttpNotFound();
            }
            return View(attendeeModel);
        }

        // POST: Attendees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Title,Department")] AttendeeModel attendeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendeeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendeeModel);
        }

        // GET: Attendees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendeeModel attendeeModel = db.AttendeeModels.Find(id);
            if (attendeeModel == null)
            {
                return HttpNotFound();
            }
            return View(attendeeModel);
        }

        // POST: Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendeeModel attendeeModel = db.AttendeeModels.Find(id);
            db.AttendeeModels.Remove(attendeeModel);
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
