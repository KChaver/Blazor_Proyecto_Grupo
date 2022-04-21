using BlazorGrupo.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BlazorGrupo.Pages.Productos;

partial class EditarProducto
{
    [Inject] private IProductoServicio _productoServicio { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    [Parameter] public string Codigo { get; set; }
    
   
    Producto products = new Producto();


    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Codigo))
        {
            
            
            products = await _productoServicio.GetPorCodigo(Codigo);

        }
      
     }
  
    protected async Task Guardar()
    {
        if(string.IsNullOrEmpty(products.Codigo) || string.IsNullOrEmpty(products.Descripcion))
        {
            return;
        }
        bool edito = await _productoServicio.Actualizar(products);
        
        if (edito)
        {
            await Swal.FireAsync("Felicidades","Producto actualizado con exito",SweetAlertIcon.Success);

        }
        else
        {
            await Swal.FireAsync("Error", "No se pudo editar el producto", SweetAlertIcon.Error);

        }
        _navigationManager.NavigateTo("/Productos");
    }
    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Productos");

    }
    protected async Task Eliminar()
    {
        bool elimino = false;
        
        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "Seguro que quiere elimanr el producto?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value)){

            elimino = await _productoServicio.Eliminar(products);
            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Producto Eliminado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Productos");
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo eliminar  el producto", SweetAlertIcon.Error);

            }


        }
        
       
       


        }
}
