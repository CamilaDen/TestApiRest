using Microsoft.AspNetCore.Mvc;
using TestApiRest.Domain.DTO_s;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Services.Interfaces;
using Utils.Exceptions;

namespace TestApiRest.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;  
        }

        // GET: api/Orders
        /// <summary>
        /// Obtiene todos los pedidos.
        /// </summary>
        /// <returns>Lista de OrderDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpGet]
        public List<OrderDTO> GetAllOrders()
        {
            return _ordersService.GetAllOrders();
        }

        // GET: api/Orders/{id}
        /// <summary>
        /// Obtiene un pedido
        /// </summary>
        /// <param name="id">Es el id del pedido.</param>
        /// <returns>OrderDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpGet("{id}")]
        public OrderDTO GetOrderById(int id)
        {
            return _ordersService.GetOrderById(id);
        }

        // POST: api/Orders
        /// <summary>
        /// Agrega un pedido.
        /// </summary>
        /// <param name="pedidoCreateDTO">Es el objeto que contiene los parametros.</param>
        /// <returns>OrderDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpPost]
        public OrderDTO CreateOrder(OrderDTO pedidoCreateDTO)
        {
            return _ordersService.CreateOrder(pedidoCreateDTO);  
        }

        // DELETE: api/Order/{id}
        /// <summary>
        /// Elimina un pedido.
        /// </summary>
        /// <param name="id">Es el id del pedido.</param>
        /// <returns>UserDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpDelete("{id}")]
        public ActionResult<OrderDTO> DeleteOrder(int id)
        {
            try
            {
                var order = _ordersService.DeleteOrder(id);
                return Ok(order);
            }
            catch (Exception)
            {
                throw new BadRequestException("El id ingresado no es válido.");
            }  
        }

        //POST: api/order/downloadpdf
        /// <summary>
        /// Crea y descarga un archivo pdf.
        /// </summary>
        /// <param name="orderId">Es el id del pedido</param>
        /// <returns>archivo pdf</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpPost("downloadpdf")]
        public ActionResult DownloadPDF(int orderId)
        {
            try
            {
                var fileBytes = _ordersService.DownloadPDF(orderId);
                return File(fileBytes, "application/pdf", "Order.pdf");
            }
            catch (Exception ex )
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
