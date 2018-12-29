using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentaDePeliculas.Models;

namespace RentaDePeliculas.Controllers
{
    public class RentasController : Controller
    {
        private BDPeliculasEntities db = new BDPeliculasEntities();

        // GET: Rentas
        public ActionResult Index()
        {
            var rentas = db.Rentas.Include(r => r.Clientes).Include(r => r.Peliculas);
            return View(rentas.ToList());
        }

        // GET: Rentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentas rentas = db.Rentas.Find(id);
            if (rentas == null)
            {
                return HttpNotFound();
            }
            return View(rentas);
        }

        // GET: Rentas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre");
            ViewBag.IdPeliculas = new SelectList(db.Peliculas, "IdPeliculas", "Titulo");
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta");
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta");
            return View();
        }

        // POST: Rentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRenta,IdCliente,IdPeliculas,Fecha")] Rentas rentas)
        {
            if (ModelState.IsValid)
            {
                db.Rentas.Add(rentas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", rentas.IdCliente);
            ViewBag.IdPeliculas = new SelectList(db.Peliculas, "IdPeliculas", "Titulo", rentas.IdPeliculas);
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta", rentas.IdRenta);
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta", rentas.IdRenta);
            return View(rentas);
        }

        // GET: Rentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentas rentas = db.Rentas.Find(id);
            if (rentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", rentas.IdCliente);
            ViewBag.IdPeliculas = new SelectList(db.Peliculas, "IdPeliculas", "Titulo", rentas.IdPeliculas);
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta", rentas.IdRenta);
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta", rentas.IdRenta);
            return View(rentas);
        }

        // POST: Rentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRenta,IdCliente,IdPeliculas,Fecha")] Rentas rentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", rentas.IdCliente);
            ViewBag.IdPeliculas = new SelectList(db.Peliculas, "IdPeliculas", "Titulo", rentas.IdPeliculas);
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta", rentas.IdRenta);
            ViewBag.IdRenta = new SelectList(db.Rentas, "IdRenta", "IdRenta", rentas.IdRenta);
            return View(rentas);
        }

        // GET: Rentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentas rentas = db.Rentas.Find(id);
            if (rentas == null)
            {
                return HttpNotFound();
            }
            return View(rentas);
        }

        // POST: Rentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rentas rentas = db.Rentas.Find(id);
            db.Rentas.Remove(rentas);
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
