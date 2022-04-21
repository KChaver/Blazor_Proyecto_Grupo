using BlazorGrupo.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
namespace BlazorGrupo.Pages.Productos
{
    partial class NuevoProducto
    {
        [Inject] private IProductoServicio productoServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        private Producto products = new Producto();

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(products.Codigo) || string.IsNullOrEmpty(products.Descripcion))
            {
                return;
            }
            bool inserto = await productoServicio.Nuevo(products);

            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Producto creado con exito", SweetAlertIcon.Success);

            }
            else
            {
                await Swal.FireAsync("Error", "Usuario no se pudo crear", SweetAlertIcon.Error);

            }
            navigationManager.NavigateTo("/Productos");
        }
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Productos");

        }

    }
}
