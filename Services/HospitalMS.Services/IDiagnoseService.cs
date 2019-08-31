namespace HospitalMS.Services
{
    using HospitalMS.Services.Models;
    using System.Threading.Tasks;



    public interface IDiagnoseService
    {
        Task<bool> CreateDiagnose(string patientId, string doctorId,DiagnoseServiceModel diagnoseServiceModel);
    }
}
