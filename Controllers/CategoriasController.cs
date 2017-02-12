using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppVentas.Context;
using WebAppVentas.Models;

namespace WebAppVentas.Controllers
{
    public class CategoriasController : Controller
    {
        private VentasContext db = new VentasContext();
        //
        // GET: /Categorias/
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        //
        // GET: /Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = db.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);

        }
        //
        // GET: /Categorias/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        //
        // POST: /Categorias/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categorias.Add(categoria);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        //
        // GET: /Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = db.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //
        // POST: /Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(categoria).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        //
        // GET: /Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = db.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        //
        // POST: /Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categorias.Remove(categoria);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }
    }
}

