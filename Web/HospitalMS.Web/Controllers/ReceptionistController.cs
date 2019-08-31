namespace HospitalMS.Web.Controllers
{
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Receptionist;
    using Microsoft.AspNetCore.Mvc;


    public class ReceptionistController : BaseController
    {
        private readonly IReceptionistService receptionistService;

        public ReceptionistController(IReceptionistService receptionistService)
        {
            this.receptionistService = receptionistService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ReceptionistDetailsViewModel receptionist = (await this.receptionistService.GetById(id))
                 .To<ReceptionistDetailsViewModel>();

            return this.View(receptionist);
        }
    }
}