namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.InputModels.Patient;
    using HospitalMS.Web.ViewModels.Patient;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;


    public class PatientController : AdministrationController
    {
        private readonly IPatientService patientService;
        private readonly IDepartmentService departmentService;

        public PatientController(IPatientService patientService, IDepartmentService departmentService)
        {
            this.patientService = patientService;
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetAllDepartments();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientCreateInputModel patientCreateInputModel)
        {

            if (!ModelState.IsValid)
            {
                await GetAllDepartments();

                return View(patientCreateInputModel);
            }

            PatientServiceModel patientServiceModel = AutoMapper.Mapper.Map<PatientServiceModel>(patientCreateInputModel);

            await patientService.Create(patientCreateInputModel.Password, patientServiceModel);


            return Redirect("/Patient/All");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            PatientEditInputModel patientEditInputModel = (await patientService.GetById(id)
               ).To<PatientEditInputModel>();

            if (patientEditInputModel == null)
            {
                return Redirect("/Patient/All");
            }

            await GetAllDepartments();

            return View(patientEditInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, PatientEditInputModel patientEditInputModel)
        {

            if (!ModelState.IsValid)
            {
                return View(patientEditInputModel);
            }

            PatientServiceModel patientServiceModel = AutoMapper.Mapper.Map<PatientServiceModel>(patientEditInputModel);

            await patientService.Edit(id, patientServiceModel);

            return Redirect("/Patient/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            PatientDeleteViewModel patientDeleteViewModel = (await patientService.GetById(id)
              ).To<PatientDeleteViewModel>();

            if (patientDeleteViewModel == null)
            {
                return Redirect("/Patient/All");
            }

            await GetAllDepartments();

            return View(patientDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/Patient/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await patientService.Delete(id);

            return Redirect("/Patient/All");
        }

        private async Task GetAllDepartments()
        {
            var allDepartments = await departmentService.GetAllActiveDepartments().ToListAsync();

            ViewData["departments"] = allDepartments.Select(department => new PatientCreateDepartmentViewModel
            {
                DepartmentName = department.Name
            })
            .ToList();
        }
    }
}