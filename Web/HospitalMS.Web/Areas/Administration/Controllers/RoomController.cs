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
    using System.Collections.Generic;

    public class RoomController : AdministratorController
    {
        private readonly IRoomService roomService;
        private readonly IDepartmentService departmentService;

        public RoomController(IRoomService roomService, IDepartmentService departmentService)
        {
            this.roomService = roomService;
            this.departmentService = departmentService;
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

            return this.Redirect("/Administration/Room/Type/All");
        }

        [HttpGet("All")]
        [Route("/Administration/Room/Type/All")]
        public async Task<IActionResult> All()
        {
            List<RoomTypeAllViewModel> roomTypes = await this.roomService.GetAllRoomTypes()
                .To<RoomTypeAllViewModel>()
                .ToListAsync();

            return this.View("Type/All", roomTypes);
        }

        [HttpGet("All")]
        [Route("/Administration/Room/All")]
        public async Task<IActionResult> AllRooms()
        {
            //TODO async
            var rooms = this.roomService.GetAllRooms()
                .To<RoomAllViewModel>().ToList();

            return this.View(rooms);
        }

        [HttpGet("Create")]
        [Route("/Administration/Room/Create")]
        public async Task<IActionResult> CreateRoom()
        {
            await this.GetAllRoomTypes();

            await this.GetAllDepartments();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateInputModel roomCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                await this.GetAllRoomTypes();

                await this.GetAllDepartments();

                return this.View();
            }
            
            RoomServiceModel roomServiceModel = AutoMapper.Mapper.Map<RoomServiceModel>(roomCreateInputModel);

            await this.roomService.Create(roomServiceModel);

            return this.Redirect("/");
        }

        private async Task GetAllRoomTypes()
        {
            var allRoomTypes = await this.roomService.GetAllRoomTypes().ToListAsync();

            this.ViewData["roomTypes"] = allRoomTypes.Select(roomType => new RoomCreateRoomTypeViewModel
            {
                RoomTypeName = roomType.Name
            })
            .ToList();
        }

        private async Task GetAllDepartments()
        {
            var allDepartments = await this.departmentService.GetAllActiveDepartments().ToListAsync();

            this.ViewData["departments"] = allDepartments.Select(department => new RoomCreateDepartmentViewModel
            {
                DepartmentName = department.Name
            })
            .ToList();
        }
    }
}