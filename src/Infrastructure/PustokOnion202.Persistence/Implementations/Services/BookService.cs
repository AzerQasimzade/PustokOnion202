using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PustokOnion202.Application.DTOs.Book;
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
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IGenreRepository genreRepository, IMapper mapper)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookItemDto>> GetAllAsync(int page, int take)
        {
            return _mapper.Map<IEnumerable<BookItemDto>>(await _repository.GetAllWhere(skip: ((page - 1) * take), take: take).ToListAsync());
        }
        public async Task<GetBookDto> GetByIdAsync(int id)
        {
            Book book = await _repository.GetByIdAsync(id, includes: nameof(Book.Genre));
            if (book is null) throw new Exception("The book you are looking for is no longer available");
            return _mapper.Map<GetBookDto>(book);
        }
        public async Task CreateAsync(CreateBookDto dto)
        {
            if (await _repository.IsExistAsync(p => p.Name == dto.Name)) throw new Exception($"there is a product with the same {dto.Name}");
            if (!await _genreRepository.IsExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("The product you are looking for is no longer available");

            Book book = _mapper.Map<Book>(dto);
        }
    }
}
