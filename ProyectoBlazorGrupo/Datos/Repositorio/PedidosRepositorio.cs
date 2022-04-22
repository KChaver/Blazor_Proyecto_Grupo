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

    public async Task<bool> Nuevo(Pedido pedidos)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO pedidos (IdPedido,CodigoProducto,IdCliente,Unidades,Total,Fecha) VALUES(@IdPedido,@CodigoProducto,@IdCliente,@Unidades,@Total,@Fecha) "; //aqui cambiar a @fecha
            resultado = await conexion.ExecuteAsync(sql, pedidos);
            return resultado > 0;
        }
        catch (Exception)
        {

            return false;
        }
    }
}
