namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using HospitalMS.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using HospitalMS.Web.ViewModels.Home;



    public class HomeController : AdministratorController
    {
        private readonly IDashboardService dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> Dashboard()
        {

            DashboardViewModel dashboardViewModel = new DashboardViewModel
            {
                DepartmentsCount = await dashboardService.GetDepartmentsCount(),
                RoomsCount = await dashboardService.GetRoomsCount(),
                RoomTypesCount = await dashboardService.GetRoomTypesCount(),
                DoctorsCount = await dashboardService.GetDoctorsCount()
            };

            return View(dashboardViewModel);


        }
    }
}