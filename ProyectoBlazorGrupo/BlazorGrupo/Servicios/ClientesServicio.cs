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


    public async Task<bool> Actualizar(Cliente cliente)
    {
        return await clienteRepositorio.Actualizar(cliente);
    }

    public async Task<bool> Eliminar(Cliente cliente)
    {
        return await clienteRepositorio.Eliminar(cliente);
    }

    public async Task<IEnumerable<Cliente>> GetLista()
    {
        return await clienteRepositorio.GetLista();
    }

    public async Task<Cliente> GetPorCodigo(string idcliente)
    {
        return await clienteRepositorio.GetPorCodigo(idcliente);
    }

    public async Task<bool> Nuevo(Cliente cliente)
    {
        return await clienteRepositorio.Nuevo(cliente);
    }
}
