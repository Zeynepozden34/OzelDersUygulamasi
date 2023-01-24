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
        Task<List<Student>> GetStudentWithTeacher();
        Task<Student> GetStudentWithTeacher(int id);
        Task<Student> GetStudentDetailsByUrlAsync(string url);
        Task CreateStudentAsync(Student student, int[]? teacher);
        Task UpdateStudentAsync(Student student, int[]? selectedTeacherId);
      
    }
}
