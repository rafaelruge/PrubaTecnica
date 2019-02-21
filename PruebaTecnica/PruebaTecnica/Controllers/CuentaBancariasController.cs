﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class CuentaBancariasController : Controller
    {
        private PruebaEntities db = new PruebaEntities();

        // GET: CuentaBancarias
        public ActionResult Index()
        {
            var cuentaBancaria = db.CuentaBancaria.Include(c => c.Cliente);
            return View(cuentaBancaria.ToList());
        }

        // GET: CuentaBancarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancaria);
        }

        // GET: CuentaBancarias/Create
        public ActionResult Create()
        {
            ViewBag.Cedula = new SelectList(db.Cliente, "Cedula", "Nombre");
            return View();
        }

        // POST: CuentaBancarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero_cuenta,Cedula,Fecha_apertura,Monto")] CuentaBancaria cuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.CuentaBancaria.Add(cuentaBancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cedula = new SelectList(db.Cliente, "Cedula", "Nombre", cuentaBancaria.Cedula);
            return View(cuentaBancaria);
        }

        // GET: CuentaBancarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cedula = new SelectList(db.Cliente, "Cedula", "Nombre", cuentaBancaria.Cedula);
            return View(cuentaBancaria);
        }

        // POST: CuentaBancarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero_cuenta,Cedula,Fecha_apertura,Monto")] CuentaBancaria cuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentaBancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cedula = new SelectList(db.Cliente, "Cedula", "Nombre", cuentaBancaria.Cedula);
            return View(cuentaBancaria);
        }

        // GET: CuentaBancarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancaria);
        }

        // POST: CuentaBancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            db.CuentaBancaria.Remove(cuentaBancaria);
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
