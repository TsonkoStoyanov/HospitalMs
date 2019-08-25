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
        private readonly IDepartmentService departmentService;
        private readonly IRoomTypeService roomTypeService;

        public RoomController(IRoomService roomService, IDepartmentService departmentService,
            IRoomTypeService roomTypeService)
        {
            this.roomService = roomService;
            this.departmentService = departmentService;
            this.roomTypeService = roomTypeService;
        }

        [HttpGet]
        [Route("/Administration/Room/All")]
        public async Task<IActionResult> All()
        {
            //TODO if time remains make it async
            var rooms = this.roomService.GetAllRooms()
                .To<RoomAllViewModel>().ToList();

            return this.View(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await this.GetAllRoomTypes();

            await this.GetAllDepartments();

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return this.Redirect("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            RoomEditInputModel roomEditInputModel = (await this.roomService.GetById(id)
               ).To<RoomEditInputModel>();

            if (roomEditInputModel == null)
            {
                return this.Redirect("/Administration/Room/All");
            }

            await this.GetAllRoomTypes();

            await this.GetAllDepartments();

            return this.View(roomEditInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, RoomEditInputModel roomEditInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                await this.GetAllRoomTypes();

                await this.GetAllDepartments();

                return this.View(roomEditInputModel);
            }

            RoomServiceModel roomServiceModel = AutoMapper.Mapper.Map<RoomServiceModel>(roomEditInputModel);

            await this.roomService.Edit(id, roomServiceModel);

            return this.Redirect("/Administration/Room/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            RoomDeleteViewModel roomDeleteViewModel = (await this.roomService.GetById(id)
              ).To<RoomDeleteViewModel>();

            if (roomDeleteViewModel == null)
            {
                return this.Redirect("/Administration/Room/All");
            }

            await this.GetAllRoomTypes();

            await this.GetAllDepartments();

            return this.View(roomDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/Room/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await this.roomService.Delete(id);

            return this.Redirect("/Administration/Room/All");
        }

        //TODO if time remains to make it better not ViewData
        private async Task GetAllRoomTypes()
        {
            var allRoomTypes = await this.roomTypeService.GetAllRoomTypes().ToListAsync();

            this.ViewData["roomTypes"] = allRoomTypes.Select(roomType => new RoomCreateRoomTypeViewModel
            {
                RoomTypeName = roomType.Name
            })
            .ToList();
        }

        //TODO if time remains to make it better not ViewData
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