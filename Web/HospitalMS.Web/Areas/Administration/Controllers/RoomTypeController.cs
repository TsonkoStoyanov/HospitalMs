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
            roomTypeService = roomService;
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomTypeCreateInputModel roomTypeCreateInputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(roomTypeCreateInputModel);
            }

            RoomTypeServiceModel roomTypeServiceModel = new RoomTypeServiceModel
            {
                Name = roomTypeCreateInputModel.Name
            };

            await roomTypeService.CreateRoomType(roomTypeServiceModel);

            return Redirect("/Administration/RoomType/All");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<RoomTypeAllViewModel> roomTypes = await roomTypeService.GetAllRoomTypes()
                .To<RoomTypeAllViewModel>()
                .ToListAsync();

            return View(roomTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RoomTypeEditInputModel roomTypeInputModel = (await roomTypeService.GetById(id)
               ).To<RoomTypeEditInputModel>();

            if (roomTypeInputModel == null)
            {
                return Redirect("/Administration/RoomtType/All");
            }

            return View(roomTypeInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoomTypeEditInputModel roomTypeEditInputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(roomTypeEditInputModel);
            }

            RoomTypeServiceModel roomTypeServiceModel = AutoMapper.Mapper.Map<RoomTypeServiceModel>(roomTypeEditInputModel);

            await roomTypeService.Edit(id, roomTypeServiceModel);

            return Redirect("/Administration/RoomType/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            RoomTypeDeleteViewModel roomTypeDeleteViewModel = (await roomTypeService.GetById(id)
               ).To<RoomTypeDeleteViewModel>();

            if (roomTypeDeleteViewModel == null)
            {
                return Redirect("/Administration/RoomType/All");
            }

            return View(roomTypeDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/RoomType/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await roomTypeService.Delete(id);

            return Redirect("/Administration/RoomType/All");
        }
    }
}
