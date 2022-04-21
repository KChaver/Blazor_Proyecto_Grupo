using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio;

public class PedidosRepositorio : IPedidosRepositorio
{

    private string CadenaConexion;

    public PedidosRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
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
        IEnumerable<Pedido> lista = new List<Pedido>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM pedidos;";
            lista = await conexion.QueryAsync<Pedido>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;


    }

    public Task<Pedido> GetPorCodigo(int idpedido)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Nuevo(Pedido pedidos)
    {
        throw new NotImplementedException();
    }
}
