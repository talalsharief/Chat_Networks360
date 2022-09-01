using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat_Networks360.Areas.HelpPage.Models
{
    public class Users
    {
        public int User_Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Role_Id { get; set; }
    }
}