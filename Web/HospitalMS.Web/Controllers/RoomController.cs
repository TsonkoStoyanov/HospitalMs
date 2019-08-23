namespace HospitalMS.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class RoomController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}