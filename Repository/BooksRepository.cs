using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Repository.Interfaces;
using Z.EntityFramework.Extensions;
using Utils.Exceptions;

namespace TestApiRest.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BooksRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext= dbContext;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _dbContext.Books.ToListAsync();
            return _mapper.Map<List<BookDTO>>(books);                  
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            var book = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(x => x.IdBook == id);
            if(book == null)
            {
                throw new KeyNotFoundException("El libro no fue encontrado");
            }
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> CreateBook(BookDTO book)
        {
            var newBook = _mapper.Map<Book>(book);
            _dbContext.Books.Add(newBook);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<BookDTO>(newBook);
        }

        public async Task<BookDTO> UpdateBook(BookDTO bookDTO)
        {
            var book = GetBookById(bookDTO.IdBook); 
            if (book is null)
                throw new ExceptionMessage("No se encontró el libro.");

            var updatedBook = _mapper.Map<Book>(bookDTO);
            _dbContext.Update(updatedBook);
            await _dbContext.SaveChangesAsync();
            return await GetBookById(updatedBook.IdBook);
        }

        public async Task<BookDTO> DeleteBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book is null)
            {
                throw new KeyNotFoundException("No se encontró el libro.");
            }
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<List<BookDTO>> SaveBooks(List<BookDTO> booksDto)
        {
            var books = _mapper.Map<List<Book>>(booksDto);
            await _dbContext.Books.AddRangeAsync(books);
            _dbContext.SaveChanges();
            return _mapper.Map<List<BookDTO>>(books);
        }
    }
}
