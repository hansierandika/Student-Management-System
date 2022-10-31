using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using CsvHelper;
//using System.Web.Mvc;
using StudentManagementAPI.Models;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace StudentManagementAPI.Controllers
{
    public class StudentDetailsController : ApiController
    {
        private StudentManagementEntities db = new StudentManagementEntities();

        // GET: api/StudentDetails
        [HttpGet]
        [ActionName("getStudents")]
        public HttpResponseMessage GetStudentDetails()
        {
            var output = new List<StudentDetail>();
            output = db.StudentDetails.OrderBy(o => o.StudentId).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, output);
        }

        [ActionName("GetStudentDetail")]
        [HttpGet]
        public HttpResponseMessage GetStudentDetail(string id)
        {
            StudentDetail studentDetail = db.StudentDetails.FirstOrDefault(x => x.RegistrationNo.Equals(id));
            if (studentDetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, NotFound());
            }

            return Request.CreateResponse(HttpStatusCode.OK, studentDetail);
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
        [ActionName("addStudent")]
        [HttpPost]
        [ResponseType(typeof(StudentDetail))]
        public IHttpActionResult PostStudentDetail(StudentDetail studentDetail)
        {
            if (ModelState.IsValid)
            {
                var studentList = db.StudentDetails.ToList();
                int studentID = 0;
                string studentNo = "";
                if (studentList.Count() > 0)
                {
                    studentID = db.StudentDetails.OrderByDescending(order => order.StudentId).First().StudentId;
                    studentID =studentID + 1;
                }
                else
                {
                    studentID = 1;
                }

                int characterCount = studentID.ToString().Length;
                switch (characterCount)
                {
                    case 1:
                        studentNo = "000" + studentID;
                        break;
                    case 2:
                        studentNo = "00" + studentID;
                        break;
                    case 3:
                        studentNo = "0" + studentID;
                        break;
                    default:
                        studentNo = studentID.ToString();
                        break;
                }
                studentDetail.RegistrationNo = "SN" + studentNo;
                //studentDetail.StudentId = studentID;


                db.StudentDetails.Add(studentDetail);

                db.SaveChanges();

                return Ok(new { message = "Student " + studentNo + " added Successfully", response = "success" }); 
            }
            else {
                return BadRequest(ModelState);
            }
            //return CreatedAtRoute("DefaultApi", new { id = studentDetail.StudentId }, studentDetail);
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

        // POST: api/StudentDetails
        //[ResponseType(typeof(StudentDetail))]
        
        [ActionName("ConertToCSV")]
        [HttpPost]
        public IHttpActionResult ConertToCSV(StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personObjects = new List<StudentDetail>()
            {
                new StudentDetail { StudentId = studentDetail.StudentId, 
                    Age=studentDetail.Age, 
                    ContactNo=studentDetail.ContactNo,
                    FirstName=studentDetail.FirstName, 
                    LastName=studentDetail.LastName,
                    Marks=studentDetail.Marks,
                    RegistrationNo=studentDetail.RegistrationNo}
            };

            var downloadFolder= GetDownloadsPath();

            string file = downloadFolder +"/" + studentDetail.RegistrationNo +".csv";

            String separator = ",";
            StringBuilder output = new StringBuilder();

            File.WriteAllText(file, string.Empty);

            String[] headings = { "StudentID", "First Name", "Last Name", "Age" , "Contact No", "Registration No" };
            output.AppendLine(string.Join(separator, headings));

            foreach (StudentDetail student in personObjects)
            {
                String[] newLine = { student.StudentId.ToString(), student.FirstName, student.LastName, student.Age.ToString(),student.ContactNo,student.RegistrationNo };
                output.AppendLine(string.Join(separator, newLine));

            }
            var message = "";

            try
            {
                File.AppendAllText(file, output.ToString());
                message=studentDetail.RegistrationNo + ".csv Successfully downloaded to download folder";
                return Ok(new { message = message, response="success" });
            }

            catch (Exception ex)
            {
                message="Data could not be written to the CSV file.";
                return Ok(new { message = message, response = "fail" });
            }

            
        }

private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

    
    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);

    /// 4. Declare method that returns the Downloads Path as string
    /// <summary>
    /// Returns the absolute downloads directory specified on the system.
    /// </summary>
    /// <returns></returns>
    public static string GetDownloadsPath()
    {
        if (Environment.OSVersion.Version.Major < 6) throw new NotSupportedException();

        IntPtr pathPtr = IntPtr.Zero;

        try
        {
            SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
            return Marshal.PtrToStringUni(pathPtr);
        }
        finally
        {
            Marshal.FreeCoTaskMem(pathPtr);
        }
    }


   


    }
}