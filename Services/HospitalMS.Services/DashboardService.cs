
namespace HospitalMS.Services
{
    using HospitalMS.Data;
    using System.Linq;
    using System.Threading.Tasks;



    public class DashboardService : IDashboardService
    {
        private readonly HospitalMSDbContext context;

        public DashboardService(HospitalMSDbContext context)
        {
            this.context = context;
        }

        public async Task<int> GetDepartmentsCount()
        {
            return context.Departments.ToList().Count;
        }

        public async Task<int> GetDoctorsCount()
        {
            return context.Doctors.ToList().Count;
        }

        public async Task<int> GetRoomsCount()
        {
            return context.Rooms.ToList().Count;
        }

        public async Task<int> GetRoomTypesCount()
        {
            return context.RoomTypes.ToList().Count;
        }
    }
}
