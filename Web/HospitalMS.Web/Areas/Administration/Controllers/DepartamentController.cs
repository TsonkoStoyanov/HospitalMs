namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using HospitalMS.Web.InputModels.Department;
    using HospitalMS.Web.ViewModels.Department;
    using HospitalMS.Services;
    using Microsoft.EntityFrameworkCore;
    using HospitalMS.Services.Models;

    public class DepartmentController : AdministratorController
    {
        private readonly IDepartmentService departmentService;
        private readonly IHospitalService hospitalService;

        public DepartmentController(IDepartmentService departmentService, IHospitalService hospitalService)
        {
            this.departmentService = departmentService;
            this.hospitalService = hospitalService;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> All()
        {
            return View();
        }


        public async Task<IActionResult> Details(string id)
        {
            return View();
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

            return this.Redirect("/Department/All");

        }

        // GET: Departament/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: Departament/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
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

        // GET: Departament/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: Departament/Delete/5
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