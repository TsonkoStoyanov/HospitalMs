﻿namespace HospitalMS.Web.ViewModels.RoomType
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class RoomTypeAllViewModel : IMapFrom<RoomTypeServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PriceForBed { get; set; }
    }
}
