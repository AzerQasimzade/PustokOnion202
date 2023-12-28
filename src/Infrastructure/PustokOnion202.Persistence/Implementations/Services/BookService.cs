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
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IGenreRepository genreRepository, ITagRepository tagRepository, IMapper mapper)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _tagRepository = tagRepository;
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
            if (await _repository.IsExistAsync(b => b.Name == dto.Name)) throw new Exception($"there is a book with the same {dto.Name}");
            if (!await _genreRepository.IsExistAsync(g => g.Id == dto.GenreId)) throw new Exception("The book you are looking for is no longer available");

            Book book = _mapper.Map<Book>(dto);

            book.BookTags = new List<BookTag>();

            if (dto.TagIds is not null)
            {
                foreach (var tagId in dto.TagIds)
                {
                    if (!await _tagRepository.IsExistAsync(t => t.Id == tagId)) throw new Exception($"Could not find {tagId}");
                    book.BookTags.Add(new BookTag { TagId = tagId });
                }
            }
            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();
        }
    }
}
