using PustokOnion202.Application.DTOs.Author;
using PustokOnion202.Application.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.DTOs.Book
{
    public record GetBookDto(int id, string name, decimal price,decimal Discount, string? Description, int CategoryId, IncludesGenreDto Genre,IncludesAuthorDto Author);   
}
