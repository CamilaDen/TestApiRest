using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Services.Interfaces;

namespace TestApiRest.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;
        private readonly IMapper _mapper;

        public PedidosController(IPedidosService pedidosService, IMapper mapper)
        {
            _pedidosService = pedidosService;
            _mapper = mapper;
        }

        //api/pedidos
        [HttpGet]
        public async Task<IActionResult> GetAllPedidos()
        {
            try
            {
                var pedidos = await _pedidosService.GetAllPedidos();
                var pedidosDTO = _mapper.Map<List<PedidoDTO>>(pedidos);
                return Ok(pedidosDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener los pedidos");
            }
        }

        //api/pedidos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            try
            {
                var pedido = await _pedidosService.GetPedidoById(id);
                if (pedido == null)
                    return NotFound();

                var pedidoDTO = _mapper.Map<PedidoDTO>(pedido);
                return Ok(pedidoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener el pedido");
            }
        }

        //api/pedidos
        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] PedidoDTO pedidoCreateDTO)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(pedidoCreateDTO);
                await _pedidosService.CreatePedido(pedidoCreateDTO);
                var pedidoDTO = _mapper.Map<PedidoDTO>(pedido);
                return CreatedAtAction(nameof(GetPedidoById), new { id = pedidoDTO.IdPedido }, pedidoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al crear el pedido");
            }
        }


        //api/pedidos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                var pedido = await _pedidosService.GetPedidoById(id);
                if (pedido == null)
                    return NotFound();

                await _pedidosService.DeletePedido(pedido.IdPedido);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar el pedido");
            }
        }

        //api/pedidos/{idPedido}/detalles
        [HttpPost("{idPedido}/detalles")]
        public async Task<IActionResult> AddDetailPedido(int idPedido, [FromBody] DetallePedidoDTO detallePedidoCreateDTO)
        {
            try
            {
                var detallePedido = _mapper.Map<DetallePedido>(detallePedidoCreateDTO);
          
                if (detallePedidoCreateDTO.idPedido == idPedido) //existe un pedido con el mismo id ingresado en el detalle ?
                {
                    await _pedidosService.AddDetailPedido(idPedido, detallePedidoCreateDTO);
                    return Ok("Detalle de pedido agregado!");
                }
                else
                {
                    return BadRequest("El ID del pedido en el objeto DetallePedidoDTO no coincide con el parámetro idPedido.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al agregar el detalle de pedido");
            }
        }
    }
}
