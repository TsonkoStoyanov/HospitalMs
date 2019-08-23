namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.InputModels.Room;
    using Microsoft.AspNetCore.Mvc;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services;
    using HospitalMS.Web.ViewModels.Room;
    using Microsoft.EntityFrameworkCore;

    public class RoomController : AdministratorController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }


        [HttpGet("/Administration/Room/Type/Create")]
        public async Task<IActionResult> TypeCreate()
        {
            return this.View("Type/Create");
        }

        [HttpPost("/Administration/Room/Type/Create")]
        public async Task<IActionResult> TypeCreate(RoomTypeCreateInputModel roomTypeCreateInputModel)
        {
            RoomTypeServiceModel roomTypeServiceModel = new RoomTypeServiceModel
            {
                Name = roomTypeCreateInputModel.Name
            };


            await this.roomService.CreateRoomType(roomTypeServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var allRoomTypes = await this.roomService.GetAllRoomTypes().ToListAsync();

            this.ViewData["types"] = allRoomTypes.Select(roomType => new RoomTypeCreateRoomViewModel
            {
                Name = roomType.Name
            })
                .ToList(); ;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateInputModel roomCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allRoomTypes = await this.roomService.GetAllRoomTypes().ToListAsync();

                this.ViewData["types"] = allRoomTypes.Select(roomType => new RoomTypeCreateRoomViewModel
                {
                    Name = roomType.Name
                })
                    .ToList(); ;

                return this.View();
            }


            RoomServiceModel roomServiceModel = AutoMapper.Mapper.Map<RoomServiceModel>(roomCreateInputModel);

            await this.roomService.Create(roomServiceModel);

            return this.Redirect("/");
        }
    }
}