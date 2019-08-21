namespace HospitalMS.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    public class DepartmentController : BaseController
    {
        // GET: Departament
        public async Task<IActionResult> All()
        {
            return this.View();
        }

        // GET: Departament/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

    }
}