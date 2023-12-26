
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Application.Dtos;
using PustokOnion202.Application.DTOs.Genre;
using PustokOnion202.Application.Interfaces.Repository;
using PustokOnion202.Application.Interfaces.Services;
using PustokOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Persistence.Implementations.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetGenreDto>> GetAllAsync(int page, int take)
        {
            ICollection<Genre> tags = await _repository.GetAllWhere(skip: (page - 1) * take, take: take).ToListAsync();
            ICollection<GetGenreDto> dto = _mapper.Map<ICollection<GetGenreDto>>(tags);
            return dto;
        }
        public async Task Create(CreateGenreDto dto)
        {
            await _repository.AddAsync(_mapper.Map<Genre>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Update(int id, UpdateGenreDto updateGenreDto)
        {
            Genre genre = await _repository.GetByIdAsync(id);
            if (genre == null) throw new Exception("Not found");
            genre = _mapper.Map(updateGenreDto, genre);
            _repository.Update(genre);
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Genre genre = await _repository.GetByIdAsync(id);
            if (genre == null) throw new Exception("Not found");
            _repository.Delete(genre);
            await _repository.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }


    }
}
