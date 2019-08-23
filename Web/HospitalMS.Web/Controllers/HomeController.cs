namespace HospitalMS.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using HospitalMS.Common;
    using HospitalMS.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.View("DashBoard");
            }
            else
            {
                return View("Privacy");
            }
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
