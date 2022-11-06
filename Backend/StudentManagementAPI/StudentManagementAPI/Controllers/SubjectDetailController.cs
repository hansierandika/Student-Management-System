using StudentManagementAPI.Models;
using StudentManagementAPI.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace StudentManagementAPI.Controllers
{
    public class SubjectDetailController : ApiController
    {
        private StudentManagementEntities db = new StudentManagementEntities();
        private Common _common = new Common();

        // GET: Subject
        [HttpGet]
        [ActionName("getSubjects")]
        public HttpResponseMessage getSubjects()
        {
            var output = new List<Subject>();
            output = db.Subjects.ToList();
            return Request.CreateResponse(output);
        }

        [HttpPost]
        [ActionName("saveSubject")]
        public HttpResponseMessage saveSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(new
                {
                    response = HttpStatusCode.NoContent.ToString()
                    ,  message = ModelState });
            }
            else
            {
                var subjectList = new List<Subject>();
                subjectList = db.Subjects.ToList();

                foreach (var item in subjectList)
                {
                    if (item.Subject1.Replace(" ", string.Empty).Equals(subject.Subject1))
                    {
                        return Request.CreateResponse(new
                        {
                            response = HttpStatusCode.MultipleChoices.ToString() , message = subject.Subject1 + " already exist." });
                    }
                }

                db.Subjects.Add(subject);

                db.SaveChanges();

                string subjectCode = "";
                subjectCode = "SUB"+ _common.createCode(subject.SubjectId);
                subject.SubjectCode = subjectCode;
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(new { response= HttpStatusCode.OK.ToString(), message = "Subject added successfully" });
            }

        }
    }
}