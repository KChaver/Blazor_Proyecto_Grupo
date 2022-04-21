using BlazorGrupo.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BlazorGrupo.Pages.Pedidos;

partial class Pedidos
{
    [Inject] private IPedidosServiciocs _pedidosServicio { get; set; }
    private IEnumerable<Pedido> pedidosLista { get; set; } //posible falla

    protected override async Task OnInitializedAsync()
    {
        pedidosLista = await _pedidosServicio.GetLista();
    }
}
