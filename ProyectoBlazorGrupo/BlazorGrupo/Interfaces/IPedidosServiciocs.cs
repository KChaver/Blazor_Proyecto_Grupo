using Modelos;

namespace BlazorGrupo.Interfaces;

public interface IPedidosServiciocs
{
    Task<bool> Nuevo(Pedido pedidos);
    Task<bool> Actualizar(Pedido pedidos);
    Task<bool> Eliminar(Pedido pedidos);
    Task<IEnumerable<Pedido>> GetLista();
    Task<Pedido> GetPorCodigo(int idpedido);
}
