namespace Restaurante.Models;


// Clase padre => Producto
public abstract class Producto
{
    // Todos los productos comparten un nombre y un precio.
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }

    // Cada tipo de producto debe definir su propia descripción.
    public abstract string ObtenerDescripcion();
}
