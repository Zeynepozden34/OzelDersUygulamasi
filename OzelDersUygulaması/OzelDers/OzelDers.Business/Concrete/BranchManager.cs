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
    public class BranchManager : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Branch branch)
        {
            await _unitOfWork.Branchs.CreateAsync(branch);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(Branch branch)
        {
            _unitOfWork.Branchs.Delete(branch);
            _unitOfWork.Save();
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            return await _unitOfWork.Branchs.GetAllAsync();
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _unitOfWork.Branchs.GetByIdAsync(id);
        }


        public void Update(Branch branch)
        {
            _unitOfWork.Branchs.Update(branch);
            _unitOfWork.Save();
        }
    }
}
