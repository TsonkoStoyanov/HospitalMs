namespace HospitalMS.Services
{
    using System;
    using System.Threading.Tasks;
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class ExaminationService : IDiagnoseService
    {
        private readonly HospitalMSDbContext context;

        public ExaminationService(HospitalMSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateDiagnose(string patientId, string doctorId, DiagnoseServiceModel diagnoseServiceModel)
        {
            Patient patientFromDb = await context.Patients.SingleOrDefaultAsync(patient => patient.Id == patientId);

            if (patientFromDb == null)
            {
                throw new ArgumentNullException(nameof(patientFromDb));
            }

            Doctor doctorFromDb = await context.Doctors.SingleOrDefaultAsync(doctor => doctor.HospitalMSUserId == doctorId);

            if (doctorFromDb == null)
            {
                throw new ArgumentNullException(nameof(doctorFromDb));
            }

            Diagnose diagnose = AutoMapper.Mapper.Map<Diagnose>(diagnoseServiceModel);

            diagnose.Date = DateTime.UtcNow;
            diagnose.Patient = patientFromDb;
            diagnose.Doctor = doctorFromDb;

            context.Diagnoses.Add(diagnose);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}
