using ProniaOnion202.Application.Dtos;
using PustokOnion202.Application.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.Interfaces.Services
{
    public interface IGenreService
    {
        Task<ICollection<GetGenreDto>> GetAllAsync(int page, int take);
        Task Create(CreateGenreDto genre);
        Task Update(int id, UpdateGenreDto updateGenreDto);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
