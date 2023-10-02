using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Repository.Interfaces;
using Utils.Exceptions;
using Utils.PDFFileHandler;

namespace TestApiRest.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrdersRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> GetAllOrders()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if(order == null)
            {
                throw new KeyNotFoundException("El pedido no fue encontrado.");
            }
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return orderDTO;
        }

        public async Task<OrderDTO> DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if(order != null) 
            {
                throw new KeyNotFoundException("No se encontró el pedido.");
            }
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<byte[]> DownloadPDF(int orderId)
        {
            try
            {
                var order = await _dbContext.Orders
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.IdOrder == orderId);

                if (order == null)
                {
                    throw new BadRequestException("No se encontro el pedido.");
                }

                var user = await _dbContext.Users.FindAsync(order.User.IdUser);
                var orderDetails = await _dbContext.OrderDetails.Where(x => x.IdOrder == order.IdOrder).ToListAsync();
                var bookIds = orderDetails.Select(x => x.IdBook);
                var books = await _dbContext.Books.Where(book => bookIds.Contains(book.IdBook)).ToListAsync();

                var orderDto = _mapper.Map<OrderDTO>(order);
                var userDto = _mapper.Map<UserDTO>(user);
                var orderDetailsDTO = _mapper.Map<List<OrderDetailDTO>>(orderDetails);
                var booksDTO = _mapper.Map<List<BookDTO>>(books);

                string pdfFilePath = CreateWithPDFSharpCore.GeneratePath("Download");
                var pdfBytes = CreateWithPDFSharpCore.CreatePDF(pdfFilePath,orderDto, userDto, orderDetailsDTO, booksDTO);

                return pdfBytes;
            }
            catch (Exception)
            {
                throw new ExceptionMessage("Hubo un error al crear el archivo.");
            }
        }
    }
}
