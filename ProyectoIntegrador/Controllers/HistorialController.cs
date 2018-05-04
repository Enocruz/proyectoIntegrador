using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoIntegrador.Models;

namespace ProyectoIntegrador.Controllers
{
    public class HistorialController : Controller
    {
        private Modulo_IdentificacionEntities db = new Modulo_IdentificacionEntities();

        // GET: Historial
        public ActionResult Index()
        {
            var hISTORIAL = db.HISTORIAL.Include(h => h.MOVIMIENTO).Include(h => h.SUBCASO).Include(h => h.USUARIO);
            return View(hISTORIAL.ToList());
        }

        // GET: Historial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            if (hISTORIAL == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL);
        }

        // GET: Historial/Create
        public ActionResult Create()
        {
            ViewBag.idMovimiento = new SelectList(db.MOVIMIENTO, "idMovimiento", "Descripcion");
            ViewBag.idSubCaso = new SelectList(db.SUBCASO, "idSubcaso", "DESCRIPCION");
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "Apellido");
            return View();
        }

        // POST: Historial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHistorial,idUsuario,idSubCaso,idMovimiento,fecha")] HISTORIAL hISTORIAL)
        {
            if (ModelState.IsValid)
            {
                db.HISTORIAL.Add(hISTORIAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMovimiento = new SelectList(db.MOVIMIENTO, "idMovimiento", "Descripcion", hISTORIAL.idMovimiento);
            ViewBag.idSubCaso = new SelectList(db.SUBCASO, "idSubcaso", "DESCRIPCION", hISTORIAL.idSubCaso);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "Apellido", hISTORIAL.idUsuario);
            return View(hISTORIAL);
        }

        // GET: Historial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            if (hISTORIAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMovimiento = new SelectList(db.MOVIMIENTO, "idMovimiento", "Descripcion", hISTORIAL.idMovimiento);
            ViewBag.idSubCaso = new SelectList(db.SUBCASO, "idSubcaso", "DESCRIPCION", hISTORIAL.idSubCaso);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "Apellido", hISTORIAL.idUsuario);
            return View(hISTORIAL);
        }

        // POST: Historial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHistorial,idUsuario,idSubCaso,idMovimiento,fecha")] HISTORIAL hISTORIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORIAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMovimiento = new SelectList(db.MOVIMIENTO, "idMovimiento", "Descripcion", hISTORIAL.idMovimiento);
            ViewBag.idSubCaso = new SelectList(db.SUBCASO, "idSubcaso", "DESCRIPCION", hISTORIAL.idSubCaso);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "Apellido", hISTORIAL.idUsuario);
            return View(hISTORIAL);
        }

        // GET: Historial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            if (hISTORIAL == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL);
        }

        // POST: Historial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HISTORIAL hISTORIAL = db.HISTORIAL.Find(id);
            db.HISTORIAL.Remove(hISTORIAL);
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
