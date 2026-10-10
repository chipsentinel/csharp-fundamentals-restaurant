using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class Bebida : Producto
{
    // override proporciona la descripción específica de Bebida.
    public int NumeroPersonas { get; set; }
    public bool SeSirveFrio { get; set; }
    public bool Cafeina { get; set; }
    public override string ObtenerDescripcion()
    {
        // El operador ternario transforma el valor booleano en texto.
        string temperatura = SeSirveFrio ? "frío" : "caliente";
        string cafeina = Cafeina ? "con" : "sin";
        return $"{Nombre} - {Precio} € {cafeina} cafeina, servido {temperatura}";
    }
}