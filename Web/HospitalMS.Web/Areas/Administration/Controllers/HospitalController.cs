﻿namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using Microsoft.AspNetCore.Mvc;
    using HospitalMS.Web.InputModels.Hospital;
    using HospitalMS.Services.Models;


    public class HospitalController : AdministratorController
    {
        private readonly IHospitalService hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            HospitalEditInputModel hospitalEditInputModel = (await this.hospitalService.GetById(id)
                ).To<HospitalEditInputModel>();

            if (hospitalEditInputModel == null)
            {
                return this.Redirect("");
            }

            return this.View(hospitalEditInputModel);
        }

        [HttpPost(Name = "Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, HospitalEditInputModel hospitalEditInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(hospitalEditInputModel);
            }

            HospitalServiceModel hospitalServiceModel = AutoMapper.Mapper.Map<HospitalServiceModel>(hospitalEditInputModel);

            await this.hospitalService.Edit(id, hospitalServiceModel);

            return this.Redirect("/Hospital/Details");
        }
    }
}