using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Chat_Networks360.Areas.HelpPage.Models
{
    public class MesagingContext : DbContext
    {
        public MesagingContext():base("DB")
        {

        }

        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}