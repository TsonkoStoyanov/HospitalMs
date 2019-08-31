namespace HospitalMS.Web.Controllers
{
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Room;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class RoomController : BaseController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet("All")]
        [Route("/Room/All")]
        public async Task<IActionResult> All()
        {
            List<RoomAllViewModel> rooms = roomService.GetAllRooms()
                .To<RoomAllViewModel>()
                .ToList();

            return this.View(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            RoomDetailsViewModel room = (await roomService.GetById(id))
                 .To<RoomDetailsViewModel>();

            return this.View(room);
        }
    }
}