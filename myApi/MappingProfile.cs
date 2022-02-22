using AutoMapper;
using myApi.Models;
using myData.DTOs;

namespace myApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonModel, PersonDTO>().ReverseMap();
        }
    }
}
