using System.Threading.Tasks;
using HospitalMS.Services;
using HospitalMS.Services.Mapping;
using HospitalMS.Web.ViewModels.Hospital;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Web.Controllers
{
    public class HospitalController : BaseController
    {
        private readonly IHospitalService hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details()
        {
            HospitalDetailsViewModel hospitalDetailsViewModel = (await hospitalService.Get())
                .To<HospitalDetailsViewModel>();

            return View(hospitalDetailsViewModel);
        }
    }
}