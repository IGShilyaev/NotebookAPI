using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NotebookAPI.Models
{
    [Serializable]
    [KnownType(typeof(Contact))]
    [KnownType(typeof(ContactType))]
    [DataContract(IsReference = true)]

    public class BaseEntity
    {
        //public int Id { get; set; }

    }

    public class Contact : BaseEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int? PersonId { get; set; }
        public Person Person { get; set; }

        public int? ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }

    }

    public class ContactType : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Person : BaseEntity
    {
        public int Id { get; set; }
        public Person()
        {
            Contacts = new List<Contact>();
        }

        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public DateTime BirthDay { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }

    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }

}
