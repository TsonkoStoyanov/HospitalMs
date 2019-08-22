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
            List<DepartmentAllViewModel> departments = await this.departmentService.GetAllActiveDepartments()
                .To<DepartmentAllViewModel>()
                .ToListAsync();

            return this.View(departments);
        }

    
        public async Task<IActionResult> Details(string id)
        {
            DepartmentViewModel department = (await this.departmentService.GetById(id))
                .To<DepartmentViewModel>();

            return this.View(department);
        }

    }
}