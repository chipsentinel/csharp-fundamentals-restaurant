using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class Bebida : Producto
{
    // override proporciona la descripción específica de Bebida.
    public override string ObtenerDescripcion()
    {
        return $"{Nombre} - {Precio} €";
    }
}