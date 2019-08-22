﻿namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
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

        [HttpGet(Name = "Add")]
        public async Task<IActionResult> Add()
        {
            var allHospitals = await this.hospitalService.GetAllHospitals().ToListAsync();

            this.ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentAddHospitalViewModel
            {
                HospitalName = hospital.Name
            }).ToList();

            return this.View();

        }

        [HttpPost(Name = "Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DepartmentAddInputModel departmentAddInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allHospitals = await this.hospitalService.GetAllHospitals().ToListAsync();

                this.ViewData["hospitals"] = allHospitals.Select(hospital => new DepartmentAddHospitalViewModel
                {
                    HospitalName = hospital.Name
                }).ToList();

                return this.View();
            }

            DepartmentServiceModel departmentServiceModel = AutoMapper.Mapper.Map<DepartmentServiceModel>(departmentAddInputModel);


            await this.departmentService.Add(departmentServiceModel);

            return this.Redirect("/Administration/Department/All");

        }


        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DepartmentEditInputModel departmentEditInputModel)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }
    }
}