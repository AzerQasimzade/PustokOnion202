using PustokOnion202.Application.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<ICollection<GetAuthorDto>> GetAllAsync(int page, int take);
        Task Create(CreateAuthorDto genre);
        Task Update(int id, UpdateAuthorDto updateAuthorDto);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
