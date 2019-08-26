namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using HospitalMS.Web.InputModels.Department;
    using HospitalMS.Web.ViewModels.Department;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using HospitalMS.Services.Models;
    using System.Collections.Generic;


    public class DepartmentController : AdministratorController
    {
        private readonly IDepartmentService departmentService;
        private readonly IHospitalService hospitalService;

        public DepartmentController(IDepartmentService departmentService, IHospitalService hospitalService)
        {
            this.departmentService = departmentService;
            this.hospitalService = hospitalService;
        }

        [HttpGet("All")]
        [Route("/Administration/Department/All")]
        public async Task<IActionResult> All()
        {
            List<DepartmentAllViewModel> departments = departmentService.GetAllDepartments()
                .To<DepartmentAllViewModel>()
                .ToList();

            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetAllHospitals();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentCreateInputModel departmentAddInputModel)
        {
            if (!ModelState.IsValid)
            {
                await GetAllHospitals();

                return View(departmentAddInputModel);
            }

            DepartmentServiceModel departmentServiceModel = AutoMapper.Mapper.Map<DepartmentServiceModel>(departmentAddInputModel);

            await departmentService.Create(departmentServiceModel);

            return Redirect("/Administration/Department/All");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            DepartmentEditInputModel departmentEditInputModel = (await departmentService.GetById(id)
               ).To<DepartmentEditInputModel>();

            if (departmentEditInputModel == null)
            {
                return Redirect("/Administration/Department/All");
            }

            await GetAllHospitals();

            return View(departmentEditInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DepartmentEditInputModel departmentEditInputModel)
        {
            if (!ModelState.IsValid)
            {
                await GetAllHospitals();

                return View(departmentEditInputModel);
            }

            DepartmentServiceModel departmentServiceModel = AutoMapper.Mapper.Map<DepartmentServiceModel>(departmentEditInputModel);

            await departmentService.Edit(id, departmentServiceModel);

            return Redirect("/Administration/Department/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            DepartmentDeleteViewModel departmentDeleteViewModel = (await departmentService.GetById(id)
              ).To<DepartmentDeleteViewModel>();

            if (departmentDeleteViewModel == null)
            {
                return Redirect("/Administration/Department/All");
            }

            await GetAllHospitals();

            return View(departmentDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/Department/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await departmentService.Delete(id);

            return Redirect("/Administration/Department/All");
        }

        private async Task GetAllHospitals()
        {
            var allHospitals = await hospitalService.GetAllHospitals().ToListAsync();

            ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentCreateHospitalViewModel
            {
                HospitalName = hospital.Name
            }).ToList();
        }
    }
}