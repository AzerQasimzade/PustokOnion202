using ProniaOnion202.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.Interfaces.Services
{
    public interface ITagService
    {
        Task<ICollection<GetTagDto>> GetAllAsync(int page, int take);
        Task Create(CreateTagDto tag);
        Task Update(int id,UpdateTagDto updateTagDto);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
