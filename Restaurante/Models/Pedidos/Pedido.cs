using Restaurante.Models;

namespace Restaurante.Models.Pedidos;

public class Pedido
{
    // Un pedido contiene productos, pero no hereda de Producto.
    private List<Producto> productos = new List<Producto>();
}