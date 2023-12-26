using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Application.Dtos;
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
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetTagDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAllWhere(skip: (page - 1) * take, take: take).ToListAsync();
            ICollection<GetTagDto> dto = _mapper.Map<ICollection<GetTagDto>>(tags);
            return dto;
        }
        public async Task Create(CreateTagDto dto)
        {
            await _repository.AddAsync(_mapper.Map<Tag>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Update(int id, UpdateTagDto updateTagDto)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag == null) throw new Exception("Not found");
            tag = _mapper.Map(updateTagDto, tag);
            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag == null) throw new Exception("Not found");
            _repository.Delete(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }


    }
}
