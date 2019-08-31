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
    using HospitalMS.Web.InputModels.Bed;

    public class RoomController : AdministrationController
    {
        private readonly IRoomService roomService;
        private readonly IDepartmentService departmentService;
        private readonly IRoomTypeService roomTypeService;
        private readonly IBedService bedService;

        public RoomController(IRoomService roomService, IDepartmentService departmentService,
            IRoomTypeService roomTypeService, IBedService bedService)
        {
            this.roomService = roomService;
            this.departmentService = departmentService;
            this.roomTypeService = roomTypeService;
            this.bedService = bedService;
        }

        [HttpGet]
        [Route("/Administration/Room/All")]
        public async Task<IActionResult> All()
        {
            //TODO if time remains make it async
            var rooms = roomService.GetAllRooms()
                .To<RoomAllViewModel>().ToList();

            return View(rooms);
        }

        [HttpGet]
        [Route("/Administration/Room/Bed/Add/{id}")]
        public async Task<IActionResult> Add(string id)
        {
            return View("Bed/Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/Room/Bed/Add/{id}")]
        public async Task<IActionResult> Add(string id, BedAddInputModel bedCreateInputModel)
        {
            if (!ModelState.IsValid)
            {

                return View(bedCreateInputModel);
            }

            BedServiceModel bedServiceModel = AutoMapper.Mapper.Map<BedServiceModel>(bedCreateInputModel);

            await bedService.Create(id, bedServiceModel);

            return Redirect("/Administration/Room/All");

        }

        [HttpGet]
        [Route("/Administration/Room/Bed/Remove/{id}")]
        public async Task<IActionResult> Remove()
        {
            return View("Bed/Remove");
        }

        [HttpPost]
        [Route("/Administration/Room/Bed/Remove/{id}")]
        public async Task<IActionResult> Remove(string id)
        {
           
            await bedService.Remove(id);

            return Redirect("/Administration/Room/All");

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetAllRoomTypes();

            await GetAllDepartments();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateInputModel roomCreateInputModel)
        {
            if (!ModelState.IsValid)
            {
                await GetAllRoomTypes();

                await GetAllDepartments();

                return View(roomCreateInputModel);
            }

            RoomServiceModel roomServiceModel = AutoMapper.Mapper.Map<RoomServiceModel>(roomCreateInputModel);

            await roomService.Create(roomServiceModel);

            return Redirect("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            RoomEditInputModel roomEditInputModel = (await roomService.GetById(id)
               ).To<RoomEditInputModel>();

            if (roomEditInputModel == null)
            {
                return Redirect("/Administration/Room/All");
            }

            await GetAllRoomTypes();

            await GetAllDepartments();

            return View(roomEditInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, RoomEditInputModel roomEditInputModel)
        {
            if (!ModelState.IsValid)
            {
                await GetAllRoomTypes();

                await GetAllDepartments();

                return View(roomEditInputModel);
            }

            RoomServiceModel roomServiceModel = AutoMapper.Mapper.Map<RoomServiceModel>(roomEditInputModel);

            await roomService.Edit(id, roomServiceModel);

            return Redirect("/Administration/Room/All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            RoomDeleteViewModel roomDeleteViewModel = (await roomService.GetById(id)
              ).To<RoomDeleteViewModel>();

            if (roomDeleteViewModel == null)
            {
                return Redirect("/Administration/Room/All");
            }

            await GetAllRoomTypes();

            await GetAllDepartments();

            return View(roomDeleteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Administration/Room/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await roomService.Delete(id);

            return Redirect("/Administration/Room/All");
        }

        //TODO if time remains to make it better not ViewData
        private async Task GetAllRoomTypes()
        {
            var allRoomTypes = await roomTypeService.GetAllRoomTypes().ToListAsync();

            ViewData["roomTypes"] = allRoomTypes.Select(roomType => new RoomCreateRoomTypeViewModel
            {
                RoomTypeName = roomType.Name
            })
            .ToList();
        }

        //TODO if time remains to make it better not ViewData
        private async Task GetAllDepartments()
        {
            var allDepartments = await departmentService.GetAllActiveDepartments().ToListAsync();

            ViewData["departments"] = allDepartments.Select(department => new RoomCreateDepartmentViewModel
            {
                DepartmentName = department.Name
            })
            .ToList();
        }
    }
}