using BlazorGrupo.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BlazorGrupo.Pages.Clientes;

partial class EditarClientes
{
    [Inject] private IClientesServicio _clienteServicio { get; set; }

    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }
    [Parameter] public string IdCliente { get; set; }
    Cliente client = new Cliente();
    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(IdCliente))
        {
            client = await _clienteServicio.GetPorCodigo(IdCliente);
        }
    }

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(client.IdCliente) || string.IsNullOrEmpty(client.Nombre) || string.IsNullOrEmpty(client.Direccion))
        {
            return;
        }

        bool edito = await _clienteServicio.Actualizar(client);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Cliente actualizado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Cliente no se pudo actualizar", SweetAlertIcon.Error);
        }
        _navigationManager.NavigateTo("/Clientes");
    }
    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Clientes");
    }

    protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar el registro?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _clienteServicio.Eliminar(client);

            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Cliente eliminado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Clientes");
            }
            else
            {
                await Swal.FireAsync("Error", "Cliente no se pudo eliminar", SweetAlertIcon.Error);
            }
        }
    }



}

    
