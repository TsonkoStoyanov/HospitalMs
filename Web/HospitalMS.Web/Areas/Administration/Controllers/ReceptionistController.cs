namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Common;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.InputModels.Receptionist;
    using HospitalMS.Web.ViewModels.Receptionist;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;


    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ReceptionistController : Controller
    {
        private readonly IReceptionistService receptionistService;
        private readonly IHospitalService hospitalService;

        public ReceptionistController(IReceptionistService receptionistService, IHospitalService hospitalService)
        {
            this.receptionistService = receptionistService;
            this.hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var receptionist = receptionistService.GetAllReceptionists()
               .To<ReceptionistAllViewModel>().ToList();

            return View(receptionist);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            await GetAllHospitals();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceptionistCreateInputModel receptionistCreateInputModel)
        {

            if (!ModelState.IsValid)
            {
                await GetAllHospitals();

                return View(receptionistCreateInputModel);
            }

            ReceptionistServiceModel receptionistServiceModel = AutoMapper.Mapper.Map<ReceptionistServiceModel>(receptionistCreateInputModel);

            await receptionistService.Create(receptionistCreateInputModel.Password, receptionistServiceModel);


            return Redirect("/Administration/Receptionist/All");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ReceptionistEditInputModel receptionistEditInputModel = (await receptionistService.GetById(id)
               ).To<ReceptionistEditInputModel>();

            if (receptionistEditInputModel == null)
            {
                return Redirect("/Administration/Receptionist/All");
            }

            await GetAllHospitals();

            return View(receptionistEditInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ReceptionistEditInputModel receptionistEditInputModel)
        {

            if (!ModelState.IsValid)
            {
                return View(receptionistEditInputModel);
            }

            ReceptionistServiceModel receptionistServiceModel = AutoMapper.Mapper.Map<ReceptionistServiceModel>(receptionistEditInputModel);

            await receptionistService.Edit(id, receptionistServiceModel);

            return Redirect("/Administration/Receptionist/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            ReceptionistDeleteViewModel receptionistDeleteViewModel = (await receptionistService.GetById(id)
              ).To<ReceptionistDeleteViewModel>();

            if (receptionistDeleteViewModel == null)
            {
                return Redirect("/Administration/Receptionist/All");
            }

            await GetAllHospitals();

            return View(receptionistDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/Receptionist/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await receptionistService.Delete(id);

            return Redirect("/Administration/Receptionist/All");
        }


        private async Task GetAllHospitals()
        {
            var allHospitals = await hospitalService.GetAllHospitals().ToListAsync();

            ViewData["hospitals"] = allHospitals.Select(hospital => new ReceptionistCreateHospitalViewModel
            {
                HospitalName = hospital.Name
            }).ToList();
        }
    }
}