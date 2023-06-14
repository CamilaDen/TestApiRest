using AutoMapper;
using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Repository.Interfaces;
using TestApiRest.Services.Interfaces;

namespace TestApiRest.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;
        private readonly IMapper _mapper;

        public PedidosService(IPedidosRepository pedidosRepository, IMapper mapper)
        {
            _pedidosRepository = pedidosRepository;
            _mapper = mapper;
        }

        public async Task<List<PedidoDTO>> GetAllPedidos()
        {
            var pedidos = await _pedidosRepository.GetAllPedidos();
            return _mapper.Map<List<PedidoDTO>>(pedidos);
        }

        public async Task<PedidoDTO> GetPedidoById(int id)
        {
            var pedido = await _pedidosRepository.GetPedidoById(id);
            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<int> CreatePedido(PedidoDTO pedidoCreateDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoCreateDTO);
            var nuevoPedido = await _pedidosRepository.CreatePedido(pedido);
            return nuevoPedido.IdPedido;
        }

        public async Task UpdatePedido(int id, PedidoDTO pedidoUpdateDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoUpdateDTO);
            pedido.IdPedido = id;
            await _pedidosRepository.UpdatePedido(pedido);
        }

        public async Task DeletePedido(int id)
        {
            await _pedidosRepository.DeletePedido(id);
        }

        public async Task AddDetailPedido(int idPedido, DetallePedidoDTO detallePedidoCreateDTO)
        {
            var detallePedido = _mapper.Map<DetallePedido>(detallePedidoCreateDTO);
            await _pedidosRepository.AddDetailPedido(idPedido, detallePedido);
        }
    }
}
