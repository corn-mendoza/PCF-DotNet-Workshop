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
using CloudFoundryWeb.Models;

namespace CloudFoundryWeb.Controllers
{
    public class AttendeesController : ApiController
    {
        private AttendeeContext db = new AttendeeContext();

        // GET: api/Attendees
        public IQueryable<AttendeeModel> GetAttendeeModels()
        {
            return db.AttendeeModels;
        }

        // GET: api/Attendees/5
        [ResponseType(typeof(AttendeeModel))]
        public IHttpActionResult GetAttendeeModel(int id)
        {
            AttendeeModel attendeeModel = db.AttendeeModels.Find(id);
            if (attendeeModel == null)
            {
                return NotFound();
            }

            return Ok(attendeeModel);
        }

        // PUT: api/Attendees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttendeeModel(int id, AttendeeModel attendeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendeeModel.Id)
            {
                return BadRequest();
            }

            db.Entry(attendeeModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeModelExists(id))
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

        // POST: api/Attendees
        [ResponseType(typeof(AttendeeModel))]
        public IHttpActionResult PostAttendeeModel(AttendeeModel attendeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AttendeeModels.Add(attendeeModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AttendeeModelExists(attendeeModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = attendeeModel.Id }, attendeeModel);
        }

        // DELETE: api/Attendees/5
        [ResponseType(typeof(AttendeeModel))]
        public IHttpActionResult DeleteAttendeeModel(int id)
        {
            AttendeeModel attendeeModel = db.AttendeeModels.Find(id);
            if (attendeeModel == null)
            {
                return NotFound();
            }

            db.AttendeeModels.Remove(attendeeModel);
            db.SaveChanges();

            return Ok(attendeeModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendeeModelExists(int id)
        {
            return db.AttendeeModels.Count(e => e.Id == id) > 0;
        }
    }
}