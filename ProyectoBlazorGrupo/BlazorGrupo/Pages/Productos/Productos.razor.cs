using BlazorGrupo.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BlazorGrupo.Pages.Productos;

partial class Productos
{
    [Inject] private IProductoServicio _productoServicio { get; set; }
    private IEnumerable<Producto> productosLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        productosLista = await _productoServicio.GetLista();
    }
}
