namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using HospitalMS.Services;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.InputModels.Bed;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BedController : AdministratorController
    {
        private readonly IBedService bedService;

        public BedController(IBedService bedService)
        {
            this.bedService = bedService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, BedCreateInputModel bedCreateInputModel)
        {
            
            if (!ModelState.IsValid)
            {
                
                return View(bedCreateInputModel);
            }

            BedServiceModel bedServiceModel = AutoMapper.Mapper.Map<BedServiceModel>(bedCreateInputModel);

            await bedService.Create(bedServiceModel);

            return Redirect("/Administration/Room/Details/{id}");

        }
    }
}