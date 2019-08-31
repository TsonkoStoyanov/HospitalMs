namespace HospitalMS.Web.Controllers
{
    using HospitalMS.Services;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.InputModels.Diagnose;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ExaminationController : BaseController
    {
        private readonly IDiagnoseService diagnoseService;

        public ExaminationController(IDiagnoseService examinationService)
        {
            this.diagnoseService = examinationService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, DiagnoseCreateInputModel diagnoseCreateInputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(diagnoseCreateInputModel);
            }

            DiagnoseServiceModel diagnoseServiceModel = AutoMapper.Mapper.Map<DiagnoseServiceModel>(diagnoseCreateInputModel);
            
            var doctorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await diagnoseService.CreateDiagnose(id, doctorId, diagnoseServiceModel);


            return Redirect("/Patient/All");
        }
    }
}