using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotebookAPI.Models
{
    public class ContactType: BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}