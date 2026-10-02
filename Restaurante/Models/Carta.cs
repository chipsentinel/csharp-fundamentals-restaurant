using System.Runtime.InteropServices;
using Restaurante.Models;

namespace Restaurante.Models;

public class Carta
{  

    public void AgregarProductoCarta(Producto producto)
    {
        // La lista acepta cualquier producto derivado de Carta.
        carta.Add(producto);
    }

    // Un pedido contiene productos, pero no hereda de Producto.
    private List<Producto> carta = new List<Producto>();
    
    public string ObtenerDescripcion()
    {
        string descripcion = "";

        // Se utiliza el método real de cada producto: esto demuestra polimorfismo.
        foreach (Producto producto in carta)
        {
            descripcion += $"\n  - {producto.ObtenerDescripcion()}";
        }

        return descripcion;
    }
}