namespace HospitalMS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Patient;
    using Microsoft.AspNetCore.Mvc;


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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
           var patient = (await patientService.GetById(id))
                 .To<PatientDetailsViewModel>();

            return View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var patients = patientService.GetAllPatients()
                .To<PatientAllViewModel>()
                .ToList();

            return View(patients);
        }
    }
}