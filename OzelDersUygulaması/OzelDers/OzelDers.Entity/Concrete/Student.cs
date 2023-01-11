using OzelDers.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class Student : IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsDeleted { get; set; }
        public List<Teacher> Teachers { get; set; }


    }
}
