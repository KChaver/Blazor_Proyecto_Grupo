using BlazorGrupo.Data;
using BlazorGrupo.Interfaces;
using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;

namespace BlazorGrupo.Servicios;

public class PedidosServicio : IPedidosServiciocs
{

    private readonly MySQLConfiguration _configuration;
    private IPedidosRepositorio pedidosRepositorio;

    public PedidosServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        pedidosRepositorio = new PedidosRepositorio(configuration.CadenaConexion);
    }


    public Task<bool> Actualizar(Pedido pedidos)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(Pedido pedidos)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Pedido>> GetLista()
    {
        return await pedidosRepositorio.GetLista();
    }

    public Task<Pedido> GetPorCodigo(int idpedido)
    {
        throw new NotImplementedException(); //aqui
    }

    public async Task<bool> Nuevo(Pedido pedidos)
    {
        return await pedidosRepositorio.Nuevo(pedidos);
    }
}
