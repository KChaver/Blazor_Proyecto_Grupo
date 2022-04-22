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

    public async Task<bool> Actualizar(Cliente cliente)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE cliente SET IdCliente = @IdCliente, Nombre = @Nombre,  edad = @edad, Direccion = @Direccion, Telefono = @Telefono WHERE IdCliente = @IdCliente ;";
            resultado = await conexion.ExecuteAsync(sql, new
            {
                cliente.IdCliente,
                cliente.Nombre,
                cliente.edad,
                cliente.Direccion,
                cliente.Telefono
            });
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Eliminar(Cliente cliente)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "DELETE FROM cliente WHERE IdCliente = @IdCliente ;";
            resultado = await conexion.ExecuteAsync(sql, new { cliente.IdCliente});
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
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

    public async Task<Cliente> GetPorCodigo(string idcliente)
    {
        Cliente client = new Cliente();
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM cliente WHERE IdCliente = @IdCliente;";
            client = await conexion.QueryFirstAsync<Cliente>(sql, new { idcliente });
        }
        catch (Exception)
        {
        }
        return client;
    }

    public async Task<bool> Nuevo(Cliente cliente)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO cliente (IdCliente, Nombre,  edad, Direccion, Telefono) VALUES (@IdCliente, @Nombre,  @edad, @Direccion, @Telefono)";
            resultado = await conexion.ExecuteAsync(sql, cliente);
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
