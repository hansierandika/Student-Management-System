using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string SId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public string Password { get; set; }
    }
}