using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Armadura.Domain;

namespace Armadura.API.Controllers
{
    public class EmpresasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Empresas
        public IQueryable<Empresas> GetEmpresas()
        {
            return db.Empresas;
        }

        // GET: api/Empresas/5
        [ResponseType(typeof(Empresas))]
        public async Task<IHttpActionResult> GetEmpresas(int id)
        {
            Empresas empresas = await db.Empresas.FindAsync(id);
            if (empresas == null)
            {
                return NotFound();
            }

            return Ok(empresas);
        }

        // PUT: api/Empresas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpresas(int id, Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresas.EmpresaId)
            {
                return BadRequest();
            }

            db.Entry(empresas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empresas
        [ResponseType(typeof(Empresas))]
        public async Task<IHttpActionResult> PostEmpresas(Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empresas.Add(empresas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empresas.EmpresaId }, empresas);
        }

        // DELETE: api/Empresas/5
        [ResponseType(typeof(Empresas))]
        public async Task<IHttpActionResult> DeleteEmpresas(int id)
        {
            Empresas empresas = await db.Empresas.FindAsync(id);
            if (empresas == null)
            {
                return NotFound();
            }

            db.Empresas.Remove(empresas);
            await db.SaveChangesAsync();

            return Ok(empresas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresasExists(int id)
        {
            return db.Empresas.Count(e => e.EmpresaId == id) > 0;
        }
    }
}