using System.Diagnostics;
using System.Threading.Tasks;
using HospitalMS.Common;
using HospitalMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace HospitalMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return Redirect("/Administration/Home/AdministratorDashboard");
            }
            else if (User.IsInRole(GlobalConstants.ReceptionistRoleName))
            {
                return Redirect("/Administration/Home/ReceptionistDashboard");
            }
            else if (User.IsInRole(GlobalConstants.PatientRoleName))
            {
                return View("Patient/Index");
            }

            return View("Doctor/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
