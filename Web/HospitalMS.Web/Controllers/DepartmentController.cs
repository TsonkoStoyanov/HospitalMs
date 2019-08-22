namespace HospitalMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Department;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet("All")]
        [Route("/Department/All")]
        public async Task<IActionResult> All()
        {
            List<DepartamentAllViewModel> departments = await this.departmentService.GetAllDepartments()
                .To<DepartamentAllViewModel>()
                .ToListAsync();

            return this.View(departments);
        }

        // GET: Departament/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

    }
}