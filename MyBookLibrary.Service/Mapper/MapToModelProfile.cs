using System;
using AutoMapper;
using MyBookLibrary.Data.Dtos;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.Mapper
{
    public class MapToModelProfile : Profile
    {
        protected override void Configure()
        {
            DateTime dummyTime;
            int dummyInt;

            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Book))
                .ForMember(dest => dest.Author, src => src.MapFrom(p => p.Author))
                .ForMember(dest => dest.Minutes, src => src.MapFrom(p => Convert.ToInt32(p.Time.ConvertTimeToMinutes())))
                .ForMember(dest => dest.DateStarted, src => src.MapFrom(p => (DateTime.TryParse(p.DateStarted, out dummyTime) ? Convert.ToDateTime(p.DateStarted) : new DateTime(1900, 1, 1))))
                .ForMember(dest => dest.DateCompleted, src => src.MapFrom(p => (DateTime.TryParse(p.DateEnded, out dummyTime) ? Convert.ToDateTime(p.DateEnded) : new DateTime(1900, 1, 1))))
                .ForMember(dest => dest.ReleaseDate, src => src.MapFrom(p => (DateTime.TryParse(p.Year, out dummyTime) ? Convert.ToDateTime(p.Year) : new DateTime(1900, 1, 1))))
                .ForMember(dest => dest.Pages, src => src.MapFrom(p => (Int32.TryParse(p.Pages, out dummyInt) ? Convert.ToInt32(p.Pages) : 0)))
                .ForMember(dest => dest.CoverUrl, src => src.MapFrom(p => p.URL))
                .ForMember(dest => dest.CoverHash, src => src.MapFrom(p => p.URL.ToBase64()))
                ;



            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
