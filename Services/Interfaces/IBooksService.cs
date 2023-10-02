using Microsoft.AspNetCore.Http;
using TestApiRest.DTO_s;

namespace TestApiRest.Services.Interfaces
{
    public interface IBooksService
    {
        List<BookDTO> GetAllBooks();
        BookDTO GetBookById(int id);
        BookDTO CreateBook(BookDTO bookDTO);
        BookDTO UpdateBook(BookDTO bookDTO);
        BookDTO DeleteBook(int id);
        public List<BookDTO> ReadAndSaveBooksFromCsv(IFormFile file);
    }
}
