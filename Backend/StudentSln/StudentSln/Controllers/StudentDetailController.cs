using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSln.Models;

namespace StudentSln.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentDetailController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentDetail
        [HttpGet]
        public IEnumerable<StudentDetail> GetStudentDetails()
        {
            return _context.StudentDetails;
        }

        // GET: api/StudentDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDetail = await _context.StudentDetails.FindAsync(id);

            if (studentDetail == null)
            {
                return NotFound();
            }

            return Ok(studentDetail);
        }

        // PUT: api/StudentDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDetail([FromRoute] int id, [FromBody] StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDetail.SId)
            {
                return BadRequest();
            }

            _context.Entry(studentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/StudentDetail
        [HttpPost]
        public async Task<IActionResult> PostStudentDetail([FromBody] StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentDetails.Add(studentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDetail", new { id = studentDetail.SId }, studentDetail);
        }

        // DELETE: api/StudentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDetail = await _context.StudentDetails.FindAsync(id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            _context.StudentDetails.Remove(studentDetail);
            await _context.SaveChangesAsync();

            return Ok(studentDetail);
        }

        private bool StudentDetailExists(int id)
        {
            return _context.StudentDetails.Any(e => e.SId == id);
        }
    }
}