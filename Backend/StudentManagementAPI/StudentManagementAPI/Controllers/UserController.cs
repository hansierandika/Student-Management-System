using StudentManagementAPI.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace StudentManagementAPI.Controllers
{
    public class UserController : ApiController
    {
        private StudentManagementEntities db = new StudentManagementEntities();


        [HttpPost]
        [ActionName("saveUser")]
        public HttpResponseMessage saveUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(new
                {
                    response = HttpStatusCode.NoContent.ToString()
                    ,
                    message = ModelState
                });
            }
            else
            {
                return Request.CreateResponse(new { response = HttpStatusCode.OK.ToString(), message = "User added successfully" });

            }
        }
    }
}