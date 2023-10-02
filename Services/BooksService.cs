using Microsoft.AspNetCore.Http;
using TestApiRest.DTO_s;
using TestApiRest.Repository.Interfaces;
using TestApiRest.Services.Interfaces;
using Utils.CSVFileHandler;
using Utils.CustomValidator;
using Utils.Exceptions;

namespace TestApiRest.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;

        public BooksService(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookDTO> GetAllBooks()
        {
            
            return _bookRepository.GetAllBooks().Result;
        }

        public BookDTO GetBookById(int id)
        {
            return _bookRepository.GetBookById(id).Result;
        }

        public BookDTO CreateBook(BookDTO bookDTO)
        {
            CustomValidator<BookDTO>.DTOValidator(bookDTO);
            return _bookRepository.CreateBook(bookDTO).Result;
        }

        public BookDTO UpdateBook(BookDTO bookDTO)
        {
            CustomValidator<BookDTO>.DTOValidator(bookDTO);
            return _bookRepository.UpdateBook(bookDTO).Result;
        }

        public BookDTO DeleteBook(int id)
        { 
            return _bookRepository.DeleteBook(id).Result;
        }

        public List<BookDTO> ReadAndSaveBooksFromCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new BadRequestException("El archivo no se ha proporcionado o está vacío.");
            }
            var filePath = ReadWithTextFieldParser.SearchFileAddress(file);
            var books = ReadWithTextFieldParser.ReadCsv(filePath);
            _bookRepository.SaveBooks(books);

            return books;
        }
    }
}
