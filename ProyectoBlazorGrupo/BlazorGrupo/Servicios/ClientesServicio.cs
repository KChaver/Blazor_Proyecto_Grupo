using BlazorGrupo.Data;
using BlazorGrupo.Interfaces;
using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;

namespace BlazorGrupo.Servicios;

public class ClientesServicio : IClientesServicio
{
    private readonly MySQLConfiguration _configuration;
    private IClienteRepositorio clienteRepositorio;

    public ClientesServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        clienteRepositorio = new ClienteRepositorio(configuration.CadenaConexion);
    }


    public Task<bool> Actualizar(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cliente>> GetLista()
    {
        return await clienteRepositorio.GetLista();
    }

    public Task<Cliente> GetPorCodigo(string idcliente)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Nuevo(Cliente cliente)
    {
        throw new NotImplementedException();
    }
}
