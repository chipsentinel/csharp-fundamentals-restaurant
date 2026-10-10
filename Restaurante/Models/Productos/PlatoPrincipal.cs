using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class PlatoPrincipal : Producto
{
    // Cada clase hija puede devolver una descripción distinta.
    public int NumeroPersonas { get; set; }
    public bool SeSirveFrio { get; set; }
    public override string ObtenerDescripcion()
    {
        // El operador ternario transforma el valor booleano en texto.
        string temperatura = SeSirveFrio ? "frío" : "caliente";
        return $"{Nombre} - {Precio} € para {NumeroPersonas} personas, servido {temperatura}";
    }
}