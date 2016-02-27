using System;
using System.Linq;
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
                .ForMember(dest => dest.Author, src => src.MapFrom(p => p.Author.Split(',').Select(x => x.Trim()).ToArray()))
                .ForMember(dest => dest.Minutes, src => src.MapFrom(p => Convert.ToInt32(p.Time.ConvertTimeToMinutes())))
                .ForMember(dest => dest.DateStarted, src => src.MapFrom(p => (DateTime.TryParse(p.DateStarted, out dummyTime) ? Convert.ToDateTime(p.DateStarted) : new DateTime(1900, 1, 1))))
                .ForMember(dest => dest.DateCompleted, src => src.MapFrom(p => (DateTime.TryParse(p.DateEnded, out dummyTime) ? Convert.ToDateTime(p.DateEnded) : new DateTime(1900, 1, 1))))
                .ForMember(dest => dest.ReleaseDate, src => src.MapFrom(p => (DateTime.TryParse(p.Year, out dummyTime) ? Convert.ToDateTime(p.Year) : new DateTime(1900, 1, 1))))
                .ForMember(dest => dest.Pages, src => src.MapFrom(p => (Int32.TryParse(p.Pages, out dummyInt) ? Convert.ToInt32(p.Pages) : 0)))
                .ForMember(dest => dest.CoverUrl, src => src.MapFrom(p => p.URL))
                .ForMember(dest => dest.CoverHash, src => src.Ignore())
                .ForMember(dest => dest.Series, src => src.MapFrom(p => !p.Series.Contains("-") ? "" : p.Series.Split('-').First()))
                .ForMember(dest => dest.SeriesOrder, src => src.MapFrom(p => Convert.ToDouble(!p.Series.Contains("-") ? "0.0" : p.Series.Split('-').Last())))
                .ForMember(dest => dest.Publisher, src => src.Ignore())
                .ForMember(dest => dest.Description, src => src.Ignore())
                .ForMember(dest => dest.Isbn10, src => src.Ignore())
                .ForMember(dest => dest.Isbn13, src => src.Ignore())
                .ForMember(dest => dest.GoogleBookLink, src => src.Ignore())
                .ForMember(dest => dest.Categories, src => src.Ignore())
                .ForMember(dest => dest.CrowdRating, src => src.Ignore())
                ;



            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
