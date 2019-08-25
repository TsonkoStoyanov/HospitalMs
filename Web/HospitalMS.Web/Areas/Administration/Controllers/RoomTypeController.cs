namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HospitalMS.Services;
    using HospitalMS.Services.Models;
    using HospitalMS.Services.Mapping;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using HospitalMS.Web.InputModels.RoomType;
    using HospitalMS.Web.ViewModels.RoomType;

    public class RoomTypeController : AdministratorController
    {
        private readonly IRoomTypeService roomTypeService;

        public RoomTypeController(IRoomTypeService roomService)
        {
            this.roomTypeService = roomService;
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomTypeCreateInputModel roomTypeCreateInputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(roomTypeCreateInputModel);
            }

            RoomTypeServiceModel roomTypeServiceModel = new RoomTypeServiceModel
            {
                Name = roomTypeCreateInputModel.Name
            };

            await this.roomTypeService.CreateRoomType(roomTypeServiceModel);

            return this.Redirect("/Administration/RoomType/All");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<RoomTypeAllViewModel> roomTypes = await this.roomTypeService.GetAllRoomTypes()
                .To<RoomTypeAllViewModel>()
                .ToListAsync();

            return this.View(roomTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RoomTypeEditInputModel roomTypeInputModel = (await this.roomTypeService.GetById(id)
               ).To<RoomTypeEditInputModel>();

            if (roomTypeInputModel == null)
            {
                return this.Redirect("/Administration/RoomtType/All");
            }

            return this.View(roomTypeInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoomTypeEditInputModel roomTypeEditInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(roomTypeEditInputModel);
            }

            RoomTypeServiceModel roomTypeServiceModel = AutoMapper.Mapper.Map<RoomTypeServiceModel>(roomTypeEditInputModel);

            await this.roomTypeService.Edit(id, roomTypeServiceModel);

            return this.Redirect("/Administration/RoomType/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            RoomTypeDeleteViewModel roomTypeDeleteViewModel = (await this.roomTypeService.GetById(id)
               ).To<RoomTypeDeleteViewModel>();

            if (roomTypeDeleteViewModel == null)
            {
                return this.Redirect("/Administration/RoomType/All");
            }

            return this.View(roomTypeDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/RoomType/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await this.roomTypeService.Delete(id);

            return this.Redirect("/Administration/RoomType/All");
        }
    }
}
