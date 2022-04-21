using BlazorGrupo.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BlazorGrupo.Pages.Clientes;

partial class Clientes
{
    [Inject] private IClientesServicio _clienteServicio { get; set; }
    private IEnumerable<Cliente> clientesLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        clientesLista = await _clienteServicio.GetLista();
    }

}
