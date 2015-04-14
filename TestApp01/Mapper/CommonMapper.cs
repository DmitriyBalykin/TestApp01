using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp01.Model;
using TestApp01.Model.ViewModels;

namespace TestApp01.Model
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<User, UserView>()
                .ForMember(dest => dest.BirthdayDay, opt => opt.MapFrom(src => src.Birthdate.Day))
                .ForMember(dest => dest.BirthdayMonth, opt => opt.MapFrom(src => src.Birthdate.Month))
                .ForMember(dest => dest.BirthdayYear, opt => opt.MapFrom(src => src.Birthdate.Year));
            Mapper.CreateMap<UserView, User>()
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => new DateTime(src.BirthdayYear, src.BirthdayMonth, src.BirthdayDay)));
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}