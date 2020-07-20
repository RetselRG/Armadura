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
    public class ClavesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Claves
        public IQueryable<Clave> GetClaves()
        {
            return db.Claves;
        }

        // GET: api/Claves/5
        [ResponseType(typeof(Clave))]
        public async Task<IHttpActionResult> GetClave(int id)
        {
            Clave clave = await db.Claves.FindAsync(id);
            if (clave == null)
            {
                return NotFound();
            }

            return Ok(clave);
        }

        // PUT: api/Claves/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClave(int id, Clave clave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clave.IdClave)
            {
                return BadRequest();
            }

            db.Entry(clave).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaveExists(id))
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

        // POST: api/Claves
        [ResponseType(typeof(Clave))]
        public async Task<IHttpActionResult> PostClave(Clave clave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Claves.Add(clave);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clave.IdClave }, clave);
        }

        // DELETE: api/Claves/5
        [ResponseType(typeof(Clave))]
        public async Task<IHttpActionResult> DeleteClave(int id)
        {
            Clave clave = await db.Claves.FindAsync(id);
            if (clave == null)
            {
                return NotFound();
            }

            db.Claves.Remove(clave);
            await db.SaveChangesAsync();

            return Ok(clave);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClaveExists(int id)
        {
            return db.Claves.Count(e => e.IdClave == id) > 0;
        }
    }
}