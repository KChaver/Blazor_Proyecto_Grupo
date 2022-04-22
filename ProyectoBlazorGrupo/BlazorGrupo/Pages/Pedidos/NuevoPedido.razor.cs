using BlazorGrupo.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BlazorGrupo.Pages.Pedidos;

partial class NuevoPedido
{
    [Inject] private IPedidosServiciocs pedidosServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Pedido pedi = new Pedido();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(pedi.CodigoProducto) || string.IsNullOrEmpty(pedi.IdCliente))
        {
            return;
        }
        bool inserto = await pedidosServicio.Nuevo(pedi);

        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Factura creada con exito", SweetAlertIcon.Success);

        }
        else
        {
            await Swal.FireAsync("Error", "Factura no se pudo crear", SweetAlertIcon.Error);

        }
        navigationManager.NavigateTo("/Pedidos");
    }
    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Pedidos");

    }
}
