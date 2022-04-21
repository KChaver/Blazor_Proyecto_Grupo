using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Cliente
{
    [Required(ErrorMessage = "El Campo IdCliente es Obligatorio")]
    public string IdCliente { get; set; }
    [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
    public string Nombre { get; set; }

    public int edad { get; set; }
    [Required(ErrorMessage = "El Campo Direccion es Obligatorio")]
    public string Direccion { get; set; }
    public string Telefono { get; set; }
 
}
