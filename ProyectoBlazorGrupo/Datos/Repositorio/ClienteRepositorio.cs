using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio;

public class ClienteRepositorio : IClienteRepositorio
{

    private string CadenaConexion;

    public ClienteRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
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
        IEnumerable<Cliente> lista = new List<Cliente>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM cliente;";
            lista = await conexion.QueryAsync<Cliente>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;
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
