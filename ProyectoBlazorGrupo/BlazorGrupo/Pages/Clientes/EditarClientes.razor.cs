using BlazorGrupo.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorGrupo.Pages.Clientes;

partial class EditarClientes
{
    [Inject] private IClientesServicio _clienteServicio { get; set; }

    protected override async Task OnInitializedAsync()
    {
       
    }
}
