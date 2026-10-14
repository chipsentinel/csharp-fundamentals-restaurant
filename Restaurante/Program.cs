using Restaurante.Models;
using Restaurante.Models.Productos;

// Esta prueba confirma que Program puede utilizar las clases de Productos.


// Bebidas
Bebida cocacola = new Bebida();
cocacola.Nombre = "Coca-Cola";
cocacola.SeSirveFrio = true;
cocacola.Cafeina = true;
// Console.WriteLine(cocacola.Nombre);
Bebida cafe = new Bebida();
cafe.Nombre = "Cafe";
cafe.SeSirveFrio = false;
cafe.Cafeina = false;

// Entratnes
Entrante patatas = new Entrante();
patatas.Nombre = "Patatas bravas";
patatas.Precio = 6.00m;
patatas.NumeroPersonas = 2;
patatas.SeSirveFrio = false;
// Console.WriteLine(patatas.ObtenerDescripcion());
// Entrante nachos = new Entrante();
// nachos.Nombre = "Nachos";
// nachos.Precio = 7.00m;
// nachos.NumeroPersonas = 2;
// nachos.SeSirveFrio = false;
// Console.WriteLine(nachos.ObtenerDescripcion());
Entrante ensaladilla = new Entrante();
ensaladilla.Nombre = "Ensaladilla rusa";
ensaladilla.Precio = 5.50m;
ensaladilla.NumeroPersonas = 2;
ensaladilla.SeSirveFrio = true;
// Console.WriteLine(ensaladilla.ObtenerDescripcion());

// Platos principales
PlatoPrincipal cachopo = new PlatoPrincipal();
cachopo.Nombre = "Cachopo";
cachopo.Precio = 12.00m;
cachopo.NumeroPersonas = 2;
cachopo.SeSirveFrio = false;
PlatoPrincipal huevos = new PlatoPrincipal();
huevos.Nombre = "Huevos rotos";
huevos.Precio = 8.00m;
huevos.NumeroPersonas = 2;
huevos.SeSirveFrio = false;

// Postres
Postre tarta = new Postre();
tarta.Nombre = "Tarta de queso";
tarta.Precio = 4.40m;
tarta.SeSirveFrio = true;
tarta.Azucar = false;
Postre sorbete = new Postre();
sorbete.Nombre = "Sorbete de limon";
sorbete.Precio = 3.80m;
sorbete.SeSirveFrio = true;
sorbete.Azucar = true;


Carta miCarta = new Carta();
string tituloCarta = "\n=== CARTA DEL RESTAURANTE ===";
Console.Write(tituloCarta);
Console.WriteLine(miCarta.ObtenerDescripcion());
// Bebidas
miCarta.AgregarProductoCarta(cocacola);
miCarta.AgregarProductoCarta(cafe);

// Entratnes
miCarta.AgregarProductoCarta(patatas);
// miCarta.AgregarProductoCarta(nachos);
miCarta.AgregarProductoCarta(ensaladilla);


// Plato principal
miCarta.AgregarProductoCarta(cachopo);
miCarta.AgregarProductoCarta(huevos);

// Postres
miCarta.AgregarProductoCarta(tarta);
miCarta.AgregarProductoCarta(sorbete);


Console.WriteLine(miCarta.ObtenerDescripcion());

// El signo ? indica que el método puede devolver un Producto o null si la selección no es válida.
Producto? productoElegido = miCarta.SeleccionarProductoCarta();


if (productoElegido != null)
{
    Console.WriteLine("\nHas elegido:");
    Console.WriteLine(productoElegido.ObtenerDescripcion());
}
else
{
    Console.WriteLine("Debes introducir un número.");
}

