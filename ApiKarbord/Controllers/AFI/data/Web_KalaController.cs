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
using ApiKarbord.Controllers.Unit;
using ApiKarbord.Models;

namespace ApiKarbord.Controllers.AFI.data
{
    public class Web_KalaController : ApiController
    {
        public object Unitdatabase { get; private set; }


        // GET: api/Web_Kala
        [Route("api/Web_Kala/{ace}/{sal}/{group}")]
        public IQueryable<Web_Kala> GetWeb_Kala(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                return UnitDatabase.db.Web_Kala;
            }
            return null;
        }


        // PUT: api/Web_Kala/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWeb_Kala(string id, Web_Kala web_Kala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != web_Kala.Code)
            {
                return BadRequest();
            }

            UnitDatabase.db.Entry(web_Kala).State = EntityState.Modified;

            try
            {
                await UnitDatabase.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Web_KalaExists(id))
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

        // POST: api/Web_Kala
        [ResponseType(typeof(Web_Kala))]
        public async Task<IHttpActionResult> PostWeb_Kala(Web_Kala web_Kala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UnitDatabase.db.Web_Kala.Add(web_Kala);

            try
            {
                await UnitDatabase.db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Web_KalaExists(web_Kala.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = web_Kala.Code }, web_Kala);
        }

        // DELETE: api/Web_Kala/5
        [ResponseType(typeof(Web_Kala))]
        public async Task<IHttpActionResult> DeleteWeb_Kala(string id)
        {
            Web_Kala web_Kala = await UnitDatabase.db.Web_Kala.FindAsync(id);
            if (web_Kala == null)
            {
                return NotFound();
            }

            UnitDatabase.db.Web_Kala.Remove(web_Kala);
            await UnitDatabase.db.SaveChangesAsync();

            return Ok(web_Kala);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitDatabase.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Web_KalaExists(string id)
        {
            return UnitDatabase.db.Web_Kala.Count(e => e.Code == id) > 0;
        }
    }
}