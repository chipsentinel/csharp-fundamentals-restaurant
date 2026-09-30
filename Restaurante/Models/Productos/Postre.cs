using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class Postre : Producto
{
    // Postre cumple el contrato definido por Producto.
    public override string ObtenerDescripcion()
    {
        return $"{Nombre} - {Precio} €";
    }
}