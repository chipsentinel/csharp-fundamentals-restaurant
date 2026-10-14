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

        if (!int.TryParse(entrada, out int numeroProducto))
        {
            if (double.TryParse(entrada, out _)) // Compruebo si es decimal, pero no necesito guardar su valor.
            {
                Console.WriteLine("Debes introducir un número entero.");
            }
            else
            {
                Console.WriteLine("Debes introducir un número.");
            }

            return null;
        }

        if (numeroProducto < 1 || numeroProducto > carta.Count)
        {
            Console.WriteLine("Ese producto no existe.");
            return null;
        }

        return carta[numeroProducto - 1]; // La lista empieza en 0 y la selección del usuario en 1.
    }


    public Producto? BuscarProductoPorNombre()
    {
        Console.Write("\nProducto a buscar:");
        string nombreBuscado = Console.ReadLine();

        foreach (Producto producto in carta)
        {
            if (producto.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return producto;
            }
        }
        return null;
    }

    public void BuscarProductoPorPrecio()
    {
        Console.Write("\n Precio máximo:");
        string entrada = Console.ReadLine();

        if(!decimal.TryParse(entrada, out decimal precioMaximo))
        {
            Console.WriteLine("Debes introducir un precio válido");
            return;
        }

        bool encontrado = false;    // Indica si al menos un producto cumple la condición

        Console.WriteLine($"\n Producto de hasta {precioMaximo} €:");

        foreach (Producto producto in carta)
        {
            if (producto.Precio <= precioMaximo)    // Incluye los productos cuyo precio coincide con el máximo
            {
                Console.WriteLine($"{producto.Nombre} - {producto.Precio} €");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.Write("No hay productos con rango de precio maximo");
        }
    }
}
