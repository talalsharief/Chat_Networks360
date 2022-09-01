using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat_Networks360.Models.User
{
    public class User
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string cPassword { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public int IsActive { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int IsDeleted { get; set; }
    }
}