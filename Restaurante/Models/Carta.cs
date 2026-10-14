using System.ComponentModel;
using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class Carta
{  

    public void AgregarProductoCarta(Producto producto)
    {
        // La lista acepta cualquier producto derivado de Carta.
        carta.Add(producto);
    }

    // La lista acepta cualquier producto derivado de Producto.
    private List<Producto> carta = new List<Producto>();

    
    public string ObtenerDescripcion()
    {
        string descripcion = "";
        int contador = 1;
        // Se utiliza el método real de cada producto: esto demuestra polimorfismo.
        foreach (Producto producto in carta)    // "in" recorre la colección carta y asigna cada producto a la variable producto.
        {
         //   if (producto is Bebida)           // "is" comprueba si el tipo real del objeto es Bebida.
                descripcion += $"\n  {contador}. {producto.ObtenerDescripcion()}";
                contador++;
        }
        return descripcion;
     }

    
    // El signo ? indica que el método puede devolver un Producto o null si la selección no es válida.
    public Producto? SeleccionarProductoCarta()
    {
        Console.Write("\n¿Qué producto quieres? ");
        string entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int numeroProducto))
        {
            if (numeroProducto >= 1 && numeroProducto <= carta.Count)
            {
                return carta[numeroProducto - 1];
            }
        }
        
        return null;
        
    }
}
