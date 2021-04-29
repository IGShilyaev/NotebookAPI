using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NotebookAPI.Models
{
    public class PersonContext:DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> contactTypes { get; set; }
    }
}