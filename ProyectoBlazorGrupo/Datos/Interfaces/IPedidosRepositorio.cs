using Modelos;

namespace Datos.Interfaces;

public interface IPedidosRepositorio
{
    Task<bool> Nuevo(Pedido pedidos);
    Task<bool> Actualizar(Pedido pedidos);
    Task<bool> Eliminar(Pedido pedidos);
    Task<IEnumerable<Pedido>> GetLista();
    Task<Pedido> GetPorCodigo(int idpedido);
}
