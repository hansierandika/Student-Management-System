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
using System.Web.Http.Results;
using System.Web.Mvc;
//using System.Web.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    public class StudentDetailsController : ApiController
    {
        private StudentManagement_DBEntities db = new StudentManagement_DBEntities();

        // GET: api/StudentDetails
        public HttpResponseMessage GetStudentDetails()
        {
            var output = new List<StudentDetail>();
            output = db.StudentDetails.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, output);
        }

        // GET: api/StudentDetails/5
        [ResponseType(typeof(StudentDetail))]
        public IHttpActionResult GetStudentDetail(int id)
        {
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            return Ok(studentDetail);
        }

        // PUT: api/StudentDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentDetail(int id, StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDetail.StudentId)
            {
                return BadRequest();
            }

            db.Entry(studentDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailExists(id))
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

        // POST: api/StudentDetails
        [ResponseType(typeof(StudentDetail))]
        public IHttpActionResult PostStudentDetail(StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentDetails.Add(studentDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentDetailExists(studentDetail.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = studentDetail.StudentId }, studentDetail);
        }

        // DELETE: api/StudentDetails/5
        [ResponseType(typeof(StudentDetail))]
        public IHttpActionResult DeleteStudentDetail(int id)
        {
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            db.StudentDetails.Remove(studentDetail);
            db.SaveChanges();

            return Ok(studentDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentDetailExists(int id)
        {
            return db.StudentDetails.Count(e => e.StudentId == id) > 0;
        }
    }
}