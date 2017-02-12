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
    public class ClientesController : Controller
    {
        private VentasContext db = new VentasContext();

        //
        // GET: /Clientes/
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        //
        // GET: /Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Clientes/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        //
        // POST: /Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }

        //
        // GET: /Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }
        //
        // GET: /Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clientes.Remove(cliente);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }
    }
}