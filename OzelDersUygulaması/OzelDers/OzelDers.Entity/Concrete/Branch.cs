using OzelDers.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class Branch 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<TeacherAndBranch> TeacherAndBranchs { get; set; }


    }
}
