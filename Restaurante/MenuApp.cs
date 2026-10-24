using Restaurante.Models;

public static class MenuApp
{
    public static void MostrarCarta(List<Producto> carta)
    {
        Console.WriteLine("\n=== CARTA ===");

        int numero = 1;

        foreach (Producto producto in carta)
        {
            Console.WriteLine(
                $"{numero}. {producto.Nombre} - {producto.Precio} €"
            );

            numero++;
        }
    }
}