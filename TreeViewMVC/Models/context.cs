using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TreeViewMVC.Models;

namespace TreeViewMVC
{
    public class context : DbContext
    {
        public context()
            //Your connection string in Web.Config File
            : base("ConnectionString")
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}