namespace HospitalMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Patient;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class PatientController : BaseController
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            PatientDetailsViewModel patient = (await this.patientService.GetById(id))
                 .To<PatientDetailsViewModel>();

            return this.View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<PatientAllViewModel> patients = await this.patientService.GetAllPatients()
                .To<PatientAllViewModel>()
                .ToListAsync();

            return this.View(patients);
        }
    }
}