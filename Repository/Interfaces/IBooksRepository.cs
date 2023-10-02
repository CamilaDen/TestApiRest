using TestApiRest.DTO_s;

namespace TestApiRest.Repository.Interfaces
{
    public interface IBooksRepository
    {
        Task<List<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookById(int id);
        Task<BookDTO> CreateBook(BookDTO bookDTO);
        Task<BookDTO> UpdateBook(BookDTO bookDTO);
        Task<BookDTO> DeleteBook(int id);
        Task<List<BookDTO>> SaveBooks(List<BookDTO> booksDto);
    }
}
