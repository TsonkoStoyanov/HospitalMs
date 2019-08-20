namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using HospitalMS.Web.InputModels.Hospital;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class HospitalController : Controller
    {
        private readonly IHospitalService hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit()
        {
            HospitalEditInputModel hospitalEditInputModel = (await this.hospitalService.Get()
                ).To<HospitalEditInputModel>();

            if (hospitalEditInputModel == null)
            {
                return this.Redirect("");
            }

            return this.View(hospitalEditInputModel);
        }
    }
}