namespace HospitalMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Department;
    using Microsoft.AspNetCore.Mvc;
    

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
            List<DepartmentAllViewModel> departments = departmentService.GetAllActiveDepartments()
                .To<DepartmentAllViewModel>()
                .ToList();

            return View(departments);
        }
            
        public async Task<IActionResult> Details(string id)
        {
            DepartmentDetailsViewModel department = (await departmentService.GetById(id))
                .To<DepartmentDetailsViewModel>();

            return View(department);
        }

    }
}