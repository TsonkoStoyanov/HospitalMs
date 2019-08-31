namespace HospitalMS.Web.ViewModels.Bed
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;

    public class BedViewModel : IMapFrom<BedServiceModel>
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool IsOcupied { get; set; }

    }
}
