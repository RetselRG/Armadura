using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Armadura.Backend.Models;
using Armadura.Domain;

namespace Armadura.Backend.Controllers
{
    public class ClavesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Claves
        public async Task<ActionResult> Index()
        {
            var claves = db.Claves.Include(c => c.Empresa);
            return View(await claves.ToListAsync());
        }

        // GET: Claves/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clave clave = await db.Claves.FindAsync(id);
            if (clave == null)
            {
                return HttpNotFound();
            }
            return View(clave);
        }

        // GET: Claves/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre");
            return View();
        }

        // POST: Claves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdClave,EmpresaId,Contrasena,FechaExpira")] Clave clave)
        {
            if (ModelState.IsValid)
            {
                db.Claves.Add(clave);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", clave.EmpresaId);
            return View(clave);
        }

        // GET: Claves/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clave clave = await db.Claves.FindAsync(id);
            if (clave == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", clave.EmpresaId);
            return View(clave);
        }

        // POST: Claves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdClave,EmpresaId,Contrasena,FechaExpira")] Clave clave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clave).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", clave.EmpresaId);
            return View(clave);
        }

        // GET: Claves/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clave clave = await db.Claves.FindAsync(id);
            if (clave == null)
            {
                return HttpNotFound();
            }
            return View(clave);
        }

        // POST: Claves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Clave clave = await db.Claves.FindAsync(id);
            db.Claves.Remove(clave);
            await db.SaveChangesAsync();
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
