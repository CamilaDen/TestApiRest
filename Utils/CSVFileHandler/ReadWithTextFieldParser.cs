using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using TestApiRest.DTO_s;

namespace Utils.CSVFileHandler
{
    public class ReadWithTextFieldParser
    {
        public static List<BookDTO> ReadCsv(string path)
        {
            var books = new List<BookDTO>();

            using (var parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length >= 3)
                    {
                        var book = new BookDTO
                        {
                            IdBook = int.TryParse(fields[0], out int id) ? id : 0,
                            Tittle = fields[1],
                            Publisher = fields[2]
                        };

                        books.Add(book);
                    }
                }
            }

            return books;
        }
        public static string SearchFileAddress(IFormFile file)
        {
            var tempPath = Path.GetTempFileName();
            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return tempPath;
        }
    }
}
