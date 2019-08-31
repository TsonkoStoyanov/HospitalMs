namespace HospitalMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using HospitalMS.Common;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.InputModels.Patient;
    using HospitalMS.Web.ViewModels;
    using HospitalMS.Web.ViewModels.Diagnose;
    using HospitalMS.Web.ViewModels.User;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly IPatientService patientService;
        private readonly IDiagnoseService diagnoseService;

        public HomeController(IUserService userService, IPatientService patientService, IDiagnoseService diagnoseService)
        {
            this.userService = userService;
            this.patientService = patientService;
            this.diagnoseService = diagnoseService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return Redirect("/Administration/Home/AdministratorDashboard");
            }
            else if (User.IsInRole(GlobalConstants.ReceptionistRoleName))
            {
                return Redirect("/Administration/Home/ReceptionistDashboard");
            }
            else if (User.IsInRole(GlobalConstants.PatientRoleName))
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var hospitalMSUser = (await userService.GetById(userId)).To<HospitalMSUserViewModel>();

                if (hospitalMSUser.IsFirstLogin)
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    List<PatientDiagnoseViewModel> patientDiagnoseAll = await diagnoseService.GetPatientAllDiagnoses(userId)
                        .To<PatientDiagnoseViewModel>().ToListAsync();

                    return View("Patient/Index", patientDiagnoseAll);
                }
            }

            return View("Doctor/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Patient/Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientCreateFromFirstLoginInputModel patientCreateFromFirstLoginInputModel)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var hospitalMSUser = (await userService.GetById(userId)).To<HospitalMSUserViewModel>();

            if (!ModelState.IsValid)
            {
                return View(patientCreateFromFirstLoginInputModel);
            }

            PatientServiceModel patientServiceModel = AutoMapper.Mapper.Map<PatientServiceModel>(patientCreateFromFirstLoginInputModel);

            patientServiceModel.Email = hospitalMSUser.Email;
            patientServiceModel.HospitalMSUserId = hospitalMSUser.Id;

            await patientService.Create(patientServiceModel);

            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
