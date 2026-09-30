using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class Entrante : Producto
{
    // Estas propiedades son propias de un entrante y no de todos los productos.
    public int NumeroPersonas { get; set; }
    public bool SeSirveFrio { get; set; }

    public override string ObtenerDescripcion()
    {
        // El operador ternario transforma el valor booleano en texto.
        string temperatura = SeSirveFrio ? "frío" : "caliente";
        return $"{Nombre} - {Precio} € para {NumeroPersonas} personas, servido {temperatura}";
    }
}

