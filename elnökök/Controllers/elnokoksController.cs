using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using elnökök;

namespace elnökök.Controllers
{
    public class elnokoksController : ApiController
    {
        private presidentsEntities db = new presidentsEntities();

        // GET: api/elnokoks
        public IQueryable<elnokok> Getelnokok()
        {
            return db.elnokok;
        }

        // GET: api/elnokoks/5
    
        public IEnumerable<elnokok> Get(int id)
        {
            var result = from x in db.elnokok
                         where x.RowNumber == id
                        select x;

            return result;
        }

        // PUT: api/elnokoks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putelnokok(int id, elnokok elnokok)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elnokok.RowNumber)
            {
                return BadRequest();
            }

            db.Entry(elnokok).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!elnokokExists(id))
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

        // POST: api/elnokoks
        //[ResponseType(typeof(elnokok))]
        //public IHttpActionResult Postelnokok(elnokok elnokok)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.elnokok.Add(elnokok);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = elnokok.RowNumber }, elnokok);
        //}

        // DELETE: api/elnokoks/5
        [ResponseType(typeof(elnokok))]
        public IHttpActionResult Deleteelnokok(int id)
        {
            elnokok elnokok = db.elnokok.Find(id);
            if (elnokok == null)
            {
                return NotFound();
            }

            db.elnokok.Remove(elnokok);
            db.SaveChanges();

            return Ok(elnokok);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool elnokokExists(int id)
        {
            return db.elnokok.Count(e => e.RowNumber == id) > 0;
        }
    }
}