namespace HospitalMS.Web.Controllers
{
    using HospitalMS.Services;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Room;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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
            List<RoomAllViewModel> rooms = await this.roomService.GetAllRooms()
                .To<RoomAllViewModel>()
                .ToListAsync();

            return this.View(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            RoomDetailsViewModel room = (await this.roomService.GetById(id))
                 .To<RoomDetailsViewModel>();

            return this.View(room);
        }
    }
}