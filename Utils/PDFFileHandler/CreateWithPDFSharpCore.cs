using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharpCore.Drawing;
using System.Threading.Tasks;
using PdfSharpCore.Pdf;
using TestApiRest.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.Domain.DTO_s;

namespace Utils.PDFFileHandler
{
    public class CreateWithPDFSharpCore
    {
        public static byte[] CreatePDF(string path, OrderDTO order, UserDTO user, List<OrderDetailDTO> orderDetails, List<BookDTO> books)
        {
            using var memoryStream = new MemoryStream();
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Arial", 18, XFontStyle.Bold);
            XFont normalFont = new XFont("Arial", 12);

            gfx.DrawString("Información del pedido", titleFont, XBrushes.Black, new XRect(10, 10, page.Width, 40), XStringFormats.TopLeft);
            gfx.DrawString($"Numero de pedido: {order.IdOrder}", normalFont, XBrushes.Black, 20, 50);
            gfx.DrawString($"Fecha del pedido: {order.DateOfOrder.ToShortDateString()}", normalFont, XBrushes.Black, 20, 120);
            
            if (user != null)
            {
                gfx.DrawString($"Nombre: {user.Name} {user.Surname}", normalFont, XBrushes.Black, 20, 80);
                gfx.DrawString($"Numero de documento: {user.DocumentNumber}", normalFont, XBrushes.Black, 20, 100);
            }
            
            gfx.DrawString("Detalles del pedido:", normalFont, XBrushes.Black, 20, 150);

            int yOffset = 170;

            foreach (var detail in orderDetails)
            {
                var book = books.FirstOrDefault(b => b.IdBook == detail.IdBook);
                if (book != null)
                {
                    gfx.DrawString($"Título del libro: {book.Tittle}", normalFont, XBrushes.Black, 40, yOffset + 20);
                    gfx.DrawString($"Autor del libro: {book.Publisher}", normalFont, XBrushes.Black, 40, yOffset + 40);
                }
                yOffset += 80;
            }

            document.Save(memoryStream);
            return memoryStream.ToArray();
        }

        public static string GeneratePath(string folder) 
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullpath = Path.Combine(baseDirectory, folder);
            return fullpath;
        }
    }
}
