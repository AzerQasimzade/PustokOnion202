using PustokOnion202.Application.DTOs.Book;
using PustokOnion202.Application.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookItemDto>> GetAllAsync(int page, int take);
    }
}
