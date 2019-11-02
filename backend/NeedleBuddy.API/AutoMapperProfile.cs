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
            CreateMap<Pickuprequest, PickupRequestViewModel>();
            CreateMap<PickupRequestViewModel, Pickuprequest>();

            CreateMap<Dropofflocation, DropOffLocationViewModel>();
            CreateMap<DropOffLocationViewModel, Dropofflocation>();

            CreateMap<Adminusers, UserViewModel>()
                .ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<UserViewModel, Adminusers>();
        }
    }
}
