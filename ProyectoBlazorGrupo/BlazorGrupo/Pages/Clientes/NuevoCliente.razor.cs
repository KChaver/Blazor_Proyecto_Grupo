using BlazorGrupo.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

//que funcioneeeeeeeeeee

namespace BlazorGrupo.Pages.Clientes;

    partial class NuevoCliente
    {
    [Inject] private IClientesServicio clienteServicio { get; set; }
    [Inject] NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Cliente client = new Cliente();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(client.IdCliente) || string.IsNullOrEmpty(client.Nombre) || string.IsNullOrEmpty(client.Direccion))
        {
            return;
        }

        bool inserto = await clienteServicio.Nuevo(client);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Cliente creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Cliente no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Clientes");
    }
    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Clientes");
    }
}

