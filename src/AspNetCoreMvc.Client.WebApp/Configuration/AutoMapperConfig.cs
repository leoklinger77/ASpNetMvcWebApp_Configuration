using AspNetCoreMvc.Client.Domain.Models;
using AspNetCoreMvc.Client.WebApp.ViewModels;
using AutoMapper;

namespace AspNetCoreMvc.Client.WebApp.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClientViewModel, Domain.Models.Client>().ReverseMap();
            CreateMap<ClientPhisycalViewModel, ClientPhysical>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<PhoneViewModel, Phone>().ReverseMap();
        }
    }
}
