using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAuthorDto>> GetAllAsync(int page, int take)
        {
            ICollection<Author> authors = await _repository.GetAllWhere(skip: (page - 1) * take, take: take).ToListAsync();
            ICollection<GetAuthorDto> dto = _mapper.Map<ICollection<GetAuthorDto>>(authors);
            return dto;
        }
        public async Task Create(CreateAuthorDto dto)
        {
            await _repository.AddAsync(_mapper.Map<Author>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Update(int id, UpdateAuthorDto updateAuthorDto)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author == null) throw new Exception("Not found");
            author = _mapper.Map(updateAuthorDto, author);
            _repository.Update(author);
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author == null) throw new Exception("Not found");
            _repository.Delete(author);
            await _repository.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }


    }
}
