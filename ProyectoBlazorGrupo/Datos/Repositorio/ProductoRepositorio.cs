using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio;

public class ProductoRepositorio : IProductoRepositorio
{
    private string CadenaConexion;

    public ProductoRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
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

        IEnumerable<Producto> lista = new List<Producto>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM producto;";
            lista = await conexion.QueryAsync<Producto>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;

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
