using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class Combo : Producto
{
    // Un combo es un producto compuesto por otros productos.
    private List<Producto> productos = new List<Producto>();

    public void AgregarProducto(Producto producto)
    {
        // La lista acepta cualquier producto derivado de Producto.
        productos.Add(producto);
    }

    public override string ObtenerDescripcion()
    {
        string descripcion = $"{Nombre} - {Precio} €";

        // Se utiliza el método real de cada producto: esto demuestra polimorfismo.
        foreach (Producto producto in productos)
        {
            descripcion += $"\n  - {producto.ObtenerDescripcion()}";
        }

        return descripcion;
    }
}