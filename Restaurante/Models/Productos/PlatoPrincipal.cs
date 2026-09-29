using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class PlatoPrincipal : Producto
{
    // Cada clase hija puede devolver una descripción distinta.
    public override string ObtenerDescripcion()
    {
        return $"{Nombre} - {Precio} €";
    }
}