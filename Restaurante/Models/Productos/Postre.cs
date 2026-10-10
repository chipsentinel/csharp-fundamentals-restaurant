using Restaurante.Models;

namespace Restaurante.Models.Productos;

public class Postre : Producto
{
    // Postre cumple el contrato definido por Producto.
    public int NumeroPersonas { get; set; }
    public bool SeSirveFrio { get; set; }
    public bool Azucar { get; set; }

    public override string ObtenerDescripcion()
    {
        // El operador ternario transforma el valor booleano en texto.
        string temperatura = SeSirveFrio ? "frío" : "caliente";
        string azucarado = Azucar ? "si" : "no";
        return $"{Nombre} - {Precio} € {azucarado} tiene azucar, servido {temperatura}";
    }
}