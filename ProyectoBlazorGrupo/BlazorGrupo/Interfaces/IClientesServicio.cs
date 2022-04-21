using Modelos;

namespace BlazorGrupo.Interfaces;

public interface IClientesServicio
{
    Task<bool> Nuevo(Cliente cliente);
    Task<bool> Actualizar(Cliente cliente);
    Task<bool> Eliminar(Cliente cliente);
    Task<IEnumerable<Cliente>> GetLista();
    Task<Cliente> GetPorCodigo(string idcliente);
}
