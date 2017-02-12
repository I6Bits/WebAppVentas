using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppVentas.Models;
using WebAppVentas.Context;

namespace WebAppVentas.Controllers
{
    public class Venta_Detalle_TmpsController : Controller
    {
        private VentasContext db = new VentasContext();

        // GET: /Venta_Detalle_Tmps/
        public ActionResult Index()
        {
            var venta_detalle_tmp = db.Venta_Detalle_Tmp.Include(v => v.Cliente).Include(v => v.Libro);
            return View(venta_detalle_tmp.ToList());
        }

        // GET: /Venta_Detalle_Tmps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta_Detalle_Tmp venta_detalle_tmp = db.Venta_Detalle_Tmp.Find(id);
            if (venta_detalle_tmp == null)
            {
                return HttpNotFound();
            }
            return View(venta_detalle_tmp);
        }

        // GET: /Venta_Detalle_Tmps/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Username");
            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "Titulo");

            return View();
        }

        // POST: /Venta_Detalle_Tmps/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Venta_Detalle_Tmp_ID,Cantidad,ClienteID,LibroID")] Venta_Detalle_Tmp venta_detalle_tmp)
        {
            if (ModelState.IsValid)
            {
                db.Venta_Detalle_Tmp.Add(venta_detalle_tmp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Username", venta_detalle_tmp.ClienteID);
            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "Titulo", venta_detalle_tmp.LibroID);
            return View(venta_detalle_tmp);
        }

        // GET: /Venta_Detalle_Tmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta_Detalle_Tmp venta_detalle_tmp = db.Venta_Detalle_Tmp.Find(id);
            if (venta_detalle_tmp == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Username", venta_detalle_tmp.ClienteID);
            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "Titulo", venta_detalle_tmp.LibroID);
            return View(venta_detalle_tmp);
        }

        // POST: /Venta_Detalle_Tmps/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Venta_Detalle_Tmp_ID,Cantidad,ClienteID,LibroID")] Venta_Detalle_Tmp venta_detalle_tmp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta_detalle_tmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Username", venta_detalle_tmp.ClienteID);
            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "Titulo", venta_detalle_tmp.LibroID);
            return View(venta_detalle_tmp);
        }

        // GET: /Venta_Detalle_Tmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta_Detalle_Tmp venta_detalle_tmp = db.Venta_Detalle_Tmp.Find(id);
            if (venta_detalle_tmp == null)
            {
                return HttpNotFound();
            }
            return View(venta_detalle_tmp);
        }

        // POST: /Venta_Detalle_Tmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta_Detalle_Tmp venta_detalle_tmp = db.Venta_Detalle_Tmp.Find(id);
            db.Venta_Detalle_Tmp.Remove(venta_detalle_tmp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BusquedaFilter(String abc)
        {
            var libroes = from s in db.Venta_Detalle_Tmp select s;
            if (!String.IsNullOrEmpty(abc))
            {
                libroes = libroes.Where(j => j.Libro.Titulo.Contains(abc));
            }
            return View(libroes.ToList());
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
