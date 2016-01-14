﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RaspBerryWebAppPro.Models;

namespace RaspBerryWebAppPro.Controllers
{
    public class RelayEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RelayEvents
        public ActionResult Index()
        {
            var relayEvents = db.RelayEvents.Include(r => r.Relay);
            return View(relayEvents.ToList());
        }

        // GET: RelayEvents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            if (relayEvent == null)
            {
                return HttpNotFound();
            }
            return View(relayEvent);
        }

        // GET: RelayEvents/Create
        public ActionResult Create()
        {
            ViewBag.RelayId = new SelectList(db.Relays, "Id", "Name");
            return View();
        }

        // POST: RelayEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RelayId,StartTime,EndTime,DurationInMinutes")] RelayEvent relayEvent)
        {
            if (ModelState.IsValid)
            {
                relayEvent.Id = Guid.NewGuid();
                db.RelayEvents.Add(relayEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RelayId = new SelectList(db.Relays, "Id", "Name", relayEvent.RelayId);
            return View(relayEvent);
        }

        // GET: RelayEvents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            if (relayEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelayId = new SelectList(db.Relays, "Id", "Name", relayEvent.RelayId);
            return View(relayEvent);
        }

        // POST: RelayEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RelayId,StartTime,EndTime,DurationInMinutes")] RelayEvent relayEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relayEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RelayId = new SelectList(db.Relays, "Id", "Name", relayEvent.RelayId);
            return View(relayEvent);
        }

        // GET: RelayEvents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            if (relayEvent == null)
            {
                return HttpNotFound();
            }
            return View(relayEvent);
        }

        // POST: RelayEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            db.RelayEvents.Remove(relayEvent);
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
