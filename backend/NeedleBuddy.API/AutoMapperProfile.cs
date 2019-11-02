using AutoMapper;
using NeedleBuddy.DB;
using NeedleBuddy.DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedleBuddy.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pickuprequest, PickupRequestViewModel>()
                .ForMember(x => x.Location_Lat, opt => opt.MapFrom(y => y.LocationLat))
                .ForMember(x => x.Location_Long, opt => opt.MapFrom(y => y.LocationLong))
                .ForMember(x => x.Phone_Number, opt => opt.MapFrom(y => y.PhoneNumber));
            CreateMap<PickupRequestViewModel, Pickuprequest>()
                .ForMember(x => x.LocationLat, opt => opt.MapFrom(y => y.Location_Lat))
                .ForMember(x => x.LocationLong, opt => opt.MapFrom(y => y.Location_Long))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.Phone_Number));

            CreateMap<Dropofflocation, DropOffLocationViewModel>();
            CreateMap<DropOffLocationViewModel, Dropofflocation>();

            CreateMap<Adminusers, UserViewModel>()
                .ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<UserViewModel, Adminusers>();
        }
    }
}
