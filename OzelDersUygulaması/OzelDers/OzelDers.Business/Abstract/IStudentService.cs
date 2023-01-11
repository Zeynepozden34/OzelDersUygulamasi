using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Business.Abstract
{
    public interface IStudentService
    {
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        Task CreateAsync(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
