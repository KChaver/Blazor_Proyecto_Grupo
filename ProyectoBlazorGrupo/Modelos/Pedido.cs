using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Pedido
{
    //[Required(ErrorMessage = "El Campo IdPedido es Obligatorio")]
    public int IdPedido { get; set; }
    [Required(ErrorMessage = "El Campo Codigo Producto es Obligatorio")]
    public string CodigoProducto { get; set; }
    [Required(ErrorMessage = "El Campo IdCliente es Obligatorio")]
    public string IdCliente { get; set; }
    //[Required(ErrorMessage = "El Campo unidades es Obligatorio")]
    public int Unidades { get; set; }

    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }
    
}
