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
using NotebookAPI.Models;

namespace NotebookAPI.Controllers
{
    public class ContactTypesController : ApiController
    {
        private PersonContext db = new PersonContext();

        // GET: api/ContactTypes
        public IQueryable<ContactType> GetcontactTypes()
        {
            return db.contactTypes;
        }

        // GET: api/ContactTypes/5
        [ResponseType(typeof(ContactType))]
        public IHttpActionResult GetContactType(int id)
        {
            ContactType contactType = db.contactTypes.Find(id);
            if (contactType == null)
            {
                return NotFound();
            }

            return Ok(contactType);
        }

        // PUT: api/ContactTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactType(int id, ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactType.Id)
            {
                return BadRequest();
            }

            db.Entry(contactType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactTypeExists(id))
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

        // POST: api/ContactTypes
        [ResponseType(typeof(ContactType))]
        public IHttpActionResult PostContactType(ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contactTypes.Add(contactType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactType.Id }, contactType);
        }

        // DELETE: api/ContactTypes/5
        [ResponseType(typeof(ContactType))]
        public IHttpActionResult DeleteContactType(int id)
        {
            ContactType contactType = db.contactTypes.Find(id);
            if (contactType == null)
            {
                return NotFound();
            }

            db.contactTypes.Remove(contactType);
            db.SaveChanges();

            return Ok(contactType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactTypeExists(int id)
        {
            return db.contactTypes.Count(e => e.Id == id) > 0;
        }
    }
}