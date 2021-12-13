using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace StudentWebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser() { SId = model.SId, FirstName = model.FirstName, LastName = model.LastName, ContactNo = model.ContactNo, Age = model.Age, Grade = model.Grade };
            //if(model.SId == null)
            //{

            //}
            user.UserName = model.SId;
            user.Email = model.Email;
            user.SId = model.SId;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.ContactNo = model.ContactNo;
            user.Age = model.Age;
            user.Grade = model.Grade;
            model.Password = "123456";

            IdentityResult result = manager.Create(user, model.Password);

            return result;
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }

    }
}

