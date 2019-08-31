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

        public async Task<int> GetAvailableBedsCount()
        {
            return context.Beds.Where(bed => bed.IsOcupied == false && bed.IsDeleted==false).ToList().Count;
        }

        public async Task<int> GetDepartmentsCount()
        {
            return context.Departments.ToList().Count;
        }

        public async Task<int> GetDoctorsCount()
        {
            return context.Doctors.ToList().Count;
        }

        public async Task<int> GetHospitalizedPatientsCount()
        {
            return context.Patients.Where(patient => patient.IsHospitalized == true).ToList().Count;
        }

        public async Task<int> GetPatientsCount()
        {
            return context.Patients.ToList().Count;
        }

        public async Task<int> GetReceptionistsCount()
        {
            return context.Receptionists.ToList().Count;
        }

        public async Task<int> GetRoomsCount()
        {
            return context.Rooms.ToList().Count;
        }

        public async Task<int> GetRoomTypesCount()
        {
            return context.RoomTypes.ToList().Count;
        }

        public async Task<int> GetАvailableRoomsCount()
        {
            return context.Rooms.Where(bed => bed.Beds.Any(x => x.IsOcupied == false)).ToList().Count;
        }
    }
}
