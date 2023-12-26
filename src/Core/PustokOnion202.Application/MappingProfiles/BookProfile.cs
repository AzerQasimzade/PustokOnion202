using AutoMapper;
using PustokOnion202.Application.DTOs.Book;
using PustokOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.MappingProfiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book,BookItemDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();



        }

    }
}
