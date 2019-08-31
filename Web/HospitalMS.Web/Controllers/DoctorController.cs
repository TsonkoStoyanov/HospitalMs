namespace HospitalMS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Doctor;
    using Microsoft.AspNetCore.Mvc;


    public class DoctorController : BaseController
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            DoctorDetailsViewModel doctor = (await doctorService.GetById(id))
                 .To<DoctorDetailsViewModel>();

            return View(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var doctor = doctorService.GetAllDoctors()
               .To<DoctorAllViewModel>().ToList();

            return View(doctor);
        }
    }
}