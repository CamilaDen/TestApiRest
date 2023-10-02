using Microsoft.Extensions.Logging;
using TestApiRest.Domain.DTO_s;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Repository.Interfaces;
using TestApiRest.Services.Interfaces;
using Utils.CustomValidator;

namespace TestApiRest.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly ILogger<OrdersService> _logger;
        public OrdersService(IOrdersRepository orderRepository, ILogger<OrdersService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public List<OrderDTO> GetAllOrders()
        {
            _logger.LogWarning("Method GetAllOrders Invoked");
            return _orderRepository.GetAllOrders().Result;
        }

        public OrderDTO GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id).Result;        
        }

        public OrderDTO CreateOrder(OrderDTO pedidoCreateDTO)
        {
            CustomValidator<OrderDTO>.DTOValidator(pedidoCreateDTO);
            return _orderRepository.CreateOrder(pedidoCreateDTO).Result;
        }

        public OrderDTO DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id).Result;
        }

        public byte[] DownloadPDF(int orderId)
        {
            return _orderRepository.DownloadPDF(orderId).Result;  
        }
    }
}
