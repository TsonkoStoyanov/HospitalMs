namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Web.InputModels.Doctor;
    using Microsoft.AspNetCore.Mvc;
    using HospitalMS.Services.Models;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using HospitalMS.Web.ViewModels.Doctor;



    public class DoctorController : AdministratorController
    {
        private readonly IDoctorService doctorService;
        private readonly IDepartmentService departmentService;

        public DoctorController(IDoctorService doctorService, IDepartmentService departmentService)
        {
            this.doctorService = doctorService;
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var doctor = doctorService.GetAllDoctors()
               .To<DoctorAllViewModel>().ToList();

            return View(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetAllDepartments();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorCreateInputModel doctorCreateInputModel)
        {

            if (!ModelState.IsValid)
            {
                await GetAllDepartments();

                return View(doctorCreateInputModel);
            }

            DoctorServiceModel doctorServiceModel = AutoMapper.Mapper.Map<DoctorServiceModel>(doctorCreateInputModel);

            await doctorService.Create(doctorCreateInputModel.Password, doctorServiceModel);


            return Redirect("/Administration/Doctor/All");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DoctorEditInputModel doctorEditInputModel)
        {

            if (!ModelState.IsValid)
            {
                return View(doctorEditInputModel);
            }

            DoctorServiceModel doctorServiceModel = AutoMapper.Mapper.Map<DoctorServiceModel>(doctorEditInputModel);

            await doctorService.Edit(id, doctorServiceModel);


            return Redirect("/Administration/Doctor/All");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            DoctorDeleteViewModel doctorDeleteViewModel = (await doctorService.GetById(id)
              ).To<DoctorDeleteViewModel>();

            if (doctorDeleteViewModel == null)
            {
                return Redirect("/Administration/Doctor/All");
            }

            await GetAllDepartments();

            return View(doctorDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/Doctor/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await doctorService.Delete(id);

            return Redirect("/Administration/Doctor/All");
        }

        private async Task GetAllDepartments()
        {
            var allDepartments = await departmentService.GetAllActiveDepartments().ToListAsync();

            ViewData["departments"] = allDepartments.Select(department => new DoctorCreateDepartmentViewModel
            {
                DepartmentName = department.Name
            })
            .ToList();
        }
    }
}