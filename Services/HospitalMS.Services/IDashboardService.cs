namespace HospitalMS.Services
{
    using System.Threading.Tasks;


    public interface IDashboardService
    {
        Task<int> GetDepartmentsCount();

        Task<int> GetRoomsCount();

        Task<int> GetRoomTypesCount();

        Task<int> GetDoctorsCount();
    }
}
