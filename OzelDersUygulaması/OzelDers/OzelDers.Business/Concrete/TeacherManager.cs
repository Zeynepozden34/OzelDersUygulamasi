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

        public async Task<List<Teacher>> GetTeacherByBranchAsync(string branch)
        {
            return await _unitOfWork.Teachers.GetTeacherByBranchAsync(branch);
        }

        public async Task<List<Teacher>> GetTeacherWithAll()
        {
            return await _unitOfWork.Teachers.GetTeacherWithAll();
        }

        public void Update(Teacher teacher)
        {
           _unitOfWork.Teachers.Update(teacher);
            _unitOfWork.Save();
        }
    }
}
