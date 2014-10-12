﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TicketDesk.Domain;
using TicketDesk.Domain.Model;

namespace TicketDesk.Web.Client.Controllers
{
    public class TicketCenterController : Controller
    {
        private TicketDeskContext Context { get; set; }

        public TicketCenterController(TicketDeskContext context)
        {
            Context = context;
        }

        // GET: TicketCenter
        public async Task<ActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var model = await Context.Tickets.Where(t => t.TicketStatus != TicketStatus.Closed).OrderByDescending(t => t.LastUpdateDate).ToPagedListAsync(pageNumber,10);
            return View(model);
        }

        //// GET: TicketCenter/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ticket ticket = await db.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ticket);
        //}

        //// GET: TicketCenter/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TicketCenter/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "TicketId,TicketType,Category,Title,Details,IsHtml,TagList,CreatedBy,CreatedDate,Owner,AssignedTo,TicketStatus,CurrentStatusDate,CurrentStatusSetBy,LastUpdateBy,LastUpdateDate,Priority,AffectsCustomer,Version")] Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Tickets.Add(ticket);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(ticket);
        //}

        //// GET: TicketCenter/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ticket ticket = await db.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ticket);
        //}

        //// POST: TicketCenter/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "TicketId,TicketType,Category,Title,Details,IsHtml,TagList,CreatedBy,CreatedDate,Owner,AssignedTo,TicketStatus,CurrentStatusDate,CurrentStatusSetBy,LastUpdateBy,LastUpdateDate,Priority,AffectsCustomer,Version")] Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(ticket).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(ticket);
        //}

        //// GET: TicketCenter/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ticket ticket = await db.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ticket);
        //}

        //// POST: TicketCenter/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Ticket ticket = await db.Tickets.FindAsync(id);
        //    db.Tickets.Remove(ticket);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}