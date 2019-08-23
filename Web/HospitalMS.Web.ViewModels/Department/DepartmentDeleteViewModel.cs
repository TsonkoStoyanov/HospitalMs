﻿namespace HospitalMS.Web.ViewModels.Department
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;

    public class DepartmentDeleteViewModel : IMapFrom<DepartmentServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string HospitalName { get; set; }
    }
}