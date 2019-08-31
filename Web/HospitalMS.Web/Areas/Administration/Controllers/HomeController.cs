namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using HospitalMS.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using HospitalMS.Web.ViewModels.Home;



    public class HomeController : AdministrationController
    {
        private readonly IDashboardService dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> AdministratorDashboard()
        {

            DashboardAdministratorViewModel dashboardAdministratorViewModel = new DashboardAdministratorViewModel
            {
                DepartmentsCount = await dashboardService.GetDepartmentsCount(),
                RoomsCount = await dashboardService.GetRoomsCount(),
                RoomTypesCount = await dashboardService.GetRoomTypesCount(),
                DoctorsCount = await dashboardService.GetDoctorsCount(),
                PatientsCount = await dashboardService.GetPatientsCount(),
                ReceptionistsCount = await dashboardService.GetReceptionistsCount()
            };

            return View(dashboardAdministratorViewModel);
        }
        public async Task<IActionResult> ReceptionistDashboard()
        {

            DashboardReceptionistViewModel dashboardReceptionistViewModel = new DashboardReceptionistViewModel
            {
                DepartmentsCount = await dashboardService.GetDepartmentsCount(),
                АvailableRoomsCount = await dashboardService.GetАvailableRoomsCount(),
                АvailableBedsCount = await dashboardService.GetAvailableBedsCount(),
                DoctorsCount = await dashboardService.GetDoctorsCount(),
                HospitalizedPatientsCount = await dashboardService.GetHospitalizedPatientsCount(),
                RoomTypesCount = await dashboardService.GetRoomTypesCount(),
            };

            return View(dashboardReceptionistViewModel);
        }
    }
}