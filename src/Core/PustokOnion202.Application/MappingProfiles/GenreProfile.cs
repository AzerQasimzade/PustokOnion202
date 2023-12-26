using AutoMapper;
using ProniaOnion202.Application.Dtos;
using PustokOnion202.Application.DTOs.Genre;
using PustokOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.MappingProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GetGenreDto>().ReverseMap();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>().ReverseMap();
        }

    }
}
