using BlazorGrupo.Data;
using BlazorGrupo.Interfaces;
using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;

namespace BlazorGrupo.Servicios;

public class ProductoServicio : IProductoServicio
{

    private readonly MySQLConfiguration _configuration;
    private IProductoRepositorio productoRepositorio;

    public ProductoServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        productoRepositorio = new ProductoRepositorio(configuration.CadenaConexion);
    }

    public Task<bool> Actualizar(Producto producto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(Producto producto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Producto>> GetLista()
    {
        return await productoRepositorio.GetLista();
    }

    public Task<Producto> GetPorCodigo(string codigo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Nuevo(Producto producto)
    {
        throw new NotImplementedException();
    }
}
