namespace HospitalMS.Web.ViewModels.Department
{
    using HospitalMS.Services.Models;
    using HospitalMS.Services.Mapping;


    public class DepartamentAllViewModel : IMapFrom<DepartmentServiceModel>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string HospitalName { get; set; }

    }
}
