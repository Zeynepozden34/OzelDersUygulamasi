using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _unitOfWork.Teachers.CreateAsync(teacher);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(Teacher teacher)
        {
            _unitOfWork.Teachers.Delete(teacher);
            _unitOfWork.Save();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _unitOfWork.Teachers.GetByIdAsync(id);

        }

        public async Task<List<Teacher>> GetHomePageTeachersAsync()
        {
            return await _unitOfWork.Teachers.GetHomePageTeachersAsync();
        }

        public Task<List<Teacher>> GetTeacherByIdBranchAsync(string Branch)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher teacher)
        {
           _unitOfWork.Teachers.Update(teacher);
            _unitOfWork.Save();
        }
    }
}
