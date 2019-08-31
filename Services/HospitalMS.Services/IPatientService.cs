namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IPatientService
    {
        IQueryable<PatientServiceModel> GetAllPatients();

        Task<bool> Create(string password, PatientServiceModel patientServiceModel);

        Task<PatientServiceModel> GetById(string id);

        Task<bool> Edit(string id, PatientServiceModel patientServiceModel);

        Task<bool> Delete(string id);
    }
}
