using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Business.Abstract
{
    public interface ITeacherService
    {
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        Task CreateAsync(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        Task<List<Teacher>> GetHomePageTeachersAsync();
        Task<List<Teacher>> GetTeacherByBranchAsync(string branch);
        Task<List<Teacher>> GetTeacherWithAll(); // Teacherları branş ve öğrencisiyle getirecek.
        Task<List<Teacher>> GetTeacherDetailsByUrlAsync(string teacherUrl); // Öğretmen Detayları getirilecek




    }
}
