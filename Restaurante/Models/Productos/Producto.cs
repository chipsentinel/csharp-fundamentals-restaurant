namespace Restaurante.Models.Productos;


// Clase padre => Producto
public abstract class Producto
{
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}

