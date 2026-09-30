using Restaurante.Models;
using Restaurante.Models.Productos;

// Esta prueba confirma que Program puede utilizar las clases de Productos.
Bebida bebida = new Bebida();
bebida.Nombre = "Coca-Cola";
Console.WriteLine(bebida.Nombre);


Entrante patatas = new Entrante();
patatas.Nombre = "Patatas bravas";
patatas.Precio = 6.00m;
patatas.NumeroPersonas = 2;
patatas.SeSirveFrio = false;
Console.WriteLine(patatas.ObtenerDescripcion());

Entrante nachos = new Entrante();
nachos.Nombre = "Nachos";
nachos.Precio = 7.00m;
nachos.NumeroPersonas = 2;
nachos.SeSirveFrio = false;
Console.WriteLine(nachos.ObtenerDescripcion());

Entrante ensaladilla = new Entrante();
ensaladilla.Nombre = "Ensaladilla rusa";
ensaladilla.Precio = 5.50m;
ensaladilla.NumeroPersonas = 2;
ensaladilla.SeSirveFrio = true;
Console.WriteLine(ensaladilla.ObtenerDescripcion());




Carta miCarta = new Carta();
string tituloCarta = "\n=== CARTA DEL RESTAURANTE ===";
Console.WriteLine(tituloCarta);
Console.WriteLine(miCarta.ObtenerDescripcion());

miCarta.AgregarProductoCarta(bebida);
miCarta.AgregarProductoCarta(patatas);
miCarta.AgregarProductoCarta(nachos);
miCarta.AgregarProductoCarta(ensaladilla);

Console.WriteLine(miCarta.ObtenerDescripcion());