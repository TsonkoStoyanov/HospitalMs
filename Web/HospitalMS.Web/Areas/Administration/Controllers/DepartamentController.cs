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
            List<DepartmentAllViewModel> departments = await this.departmentService.GetAllDepartments()
                .To<DepartmentAllViewModel>()
                .ToListAsync();

            return this.View(departments);
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var allHospitals = await this.hospitalService.GetAllHospitals().ToListAsync();

            this.ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentAddHospitalViewModel
            {
                HospitalName = hospital.Name
            }).ToList();

            return this.View();

        }

        [HttpPost(Name = "Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentAddInputModel departmentAddInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allHospitals = await this.hospitalService.GetAllHospitals().ToListAsync();

                this.ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentAddHospitalViewModel
                {
                    HospitalName = hospital.Name
                }).ToList();

                return this.View(departmentAddInputModel);
            }

            DepartmentServiceModel departmentServiceModel = AutoMapper.Mapper.Map<DepartmentServiceModel>(departmentAddInputModel);


            await this.departmentService.Add(departmentServiceModel);

            return this.Redirect("/Administration/Department/All");

        }


        public async Task<IActionResult> Edit(string id)
        {
            DepartmentEditInputModel departmentEditInputModel = (await this.departmentService.GetById(id)
               ).To<DepartmentEditInputModel>();

            if (departmentEditInputModel == null)
            {
                return this.Redirect("/Administration/Department/All");
            }
            var allHospitals = await this.hospitalService.GetAllHospitals().ToListAsync();
            this.ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentAddHospitalViewModel
            {
                HospitalName = hospital.Name
            }).ToList();

            return this.View(departmentEditInputModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DepartmentEditInputModel departmentEditInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allHospitals = await this.hospitalService.GetAllHospitals().ToListAsync();

                this.ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentAddHospitalViewModel
                {
                    HospitalName = hospital.Name
                }).ToList();

                return this.View(departmentEditInputModel);
            }


            DepartmentServiceModel departmentServiceModel = AutoMapper.Mapper.Map<DepartmentServiceModel>(departmentEditInputModel);

            await this.departmentService.Edit(id, departmentServiceModel);

            return this.Redirect("/Administration/Department/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            DepartmentDeleteViewModel DepartmentDeleteViewModel = (await this.departmentService.GetById(id)
              ).To<DepartmentDeleteViewModel>();

            if (DepartmentDeleteViewModel == null)
            {
                return this.Redirect("/Administration/Department/All");
            }
            var allHospitals = await this.hospitalService.GetAllHospitals().ToListAsync();
            this.ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentAddHospitalViewModel
            {
                HospitalName = hospital.Name
            }).ToList();

            return this.View(DepartmentDeleteViewModel);

        }

        [HttpPost]
        [Route("/Administration/Department/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await this.departmentService.Delete(id);

            return this.Redirect("/Administration/Department/All");
        }
    }
}