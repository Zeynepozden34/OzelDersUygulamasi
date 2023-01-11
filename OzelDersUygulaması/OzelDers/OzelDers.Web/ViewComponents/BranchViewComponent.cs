using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;

namespace OzelDers.Web.ViewComponents
{
    public class BranchViewComponent : ViewComponent
    {
        private readonly IBranchService _branchManager;

        public BranchViewComponent(IBranchService branchManager)
        {
            _branchManager = branchManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["branchurl"]!=null)
            {
                ViewBag.SelectedBranch = RouteData.Values["branchurl"];
            }
            var branchs = await _branchManager.GetAllAsync();
            return View(branchs);
        }
    }
}
