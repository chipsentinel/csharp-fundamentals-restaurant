# csharp-fundamentals-restaurant
Proyecto práctico de fundamentos de C# centrado en el desarrollo de una aplicación sencilla de gestión de un restaurante.
## C# y .NET

- **C#** es el lenguaje de programación. El código se escribe en archivos como `Program.cs` o `Producto.cs`.
- **.NET** es la plataforma que compila y ejecuta el código C#.
- El proyecto utiliza **.NET 8**, indicado en `Restaurante/Restaurante.csproj` mediante `net8.0`.

La relación es similar a Java y la JVM:

```text
C#       -> lenguaje
.NET     -> plataforma de ejecución y herramientas
```

`.NET Core` es el nombre antiguo de la plataforma. Desde .NET 5 se utiliza el nombre `.NET`, por lo que `.NET 8` es la versión actual que utiliza este proyecto.

## Estructura inicial

La aplicación se organiza de esta forma:

```text
Restaurante/
├── Program.cs
├── MenuApp.cs
├── Restaurante.csproj
├── Models/
│   ├── Producto.cs
│   ├── Productos/
│   │   ├── Bebida.cs
│   │   ├── PlatoPrincipal.cs
│   │   ├── Postre.cs
│   │   ├── Entrante.cs
│   │   └── Combo.cs
│   └── Pedidos/
│       └── Pedido.cs
└── Interfaces/
	├── IConAlergenos.cs
	└── IDescontable.cs
```

Las carpetas ayudan a organizar el código, pero la conexión entre archivos se realiza mediante los espacios de nombres (`namespace`) y las directivas `using`.

La relación principal de las clases será:

```text
Producto
├── Bebida
├── PlatoPrincipal
├── Postre
├── Entrante
└── Combo

Pedido
└── List<Producto>
```

`Combo` es un producto compuesto por otros productos. `Pedido` no es un producto: contiene una colección de productos seleccionados por el cliente.

## Namespaces

La clase base `Producto` pertenece a:

```csharp
namespace Restaurante.Models;
```

Las clases concretas de productos pertenecen a:

```csharp
namespace Restaurante.Models.Productos;
```

La clase `Pedido` pertenece a:

```csharp
namespace Restaurante.Models.Pedidos;
```

Para utilizar una clase desde otro espacio de nombres se utiliza `using`, de forma parecida a `import` en Java:

```csharp
using Restaurante.Models.Productos;
```

Mover un archivo a otra carpeta no cambia automáticamente su `namespace`. Si se reorganizan carpetas, hay que revisar también los `namespace` y los `using`.

## Conceptos básicos de C# utilizados

Una clase sencilla de producto puede comenzar así:

```csharp
public abstract class Producto
{
	public string Nombre { get; set; } = string.Empty;
	public decimal Precio { get; set; }
}
```

- `public`: permite que otras clases utilicen la clase o el miembro.
- `class`: declara una clase, que sirve como molde para crear objetos.
- `abstract`: indica que `Producto` es una clase base y no se puede crear directamente con `new Producto()`.
- `string`: representa texto.
- `decimal`: representa números decimales y es apropiado para precios.
- `Nombre` y `Precio`: son propiedades del objeto.
- `get`: permite leer el valor de una propiedad.
- `set`: permite cambiar el valor de una propiedad.
- `string.Empty`: inicializa el texto como una cadena vacía, evitando que empiece siendo `null`.

Una clase derivada puede heredar de `Producto`:

```csharp
public class Bebida : Producto
{
}
```

La expresión `: Producto` indica herencia. `Bebida` recibe las propiedades de `Producto` y más adelante podrá añadir propiedades o métodos propios. En Java, la idea equivalente se expresa con `extends`.

`Producto` también define un método abstracto:

```csharp
public abstract string ObtenerDescripcion();
```

Este método es un contrato: cada clase concreta que herede de `Producto` debe proporcionar su propia implementación. Para cumplirlo se utiliza `override`:

```csharp
public override string ObtenerDescripcion()
{
	return $"{Nombre} - {Precio} €";
}
```

El método devuelve un texto (`string`) y la expresión `$"..."` permite insertar propiedades dentro de una cadena. En Java existe una idea equivalente mediante la redefinición de métodos heredados.

`Entrante` añade propiedades que no son comunes a todos los productos:

```csharp
public int NumeroPersonas { get; set; }
public bool SeSirveFrio { get; set; }
```

El operador ternario permite elegir entre dos textos según un valor booleano:

```csharp
string temperatura = SeSirveFrio ? "frío" : "caliente";
```

Un `Combo` también es un `Producto`, pero está compuesto por otros productos. Por eso utiliza composición además de herencia:

```csharp
public void AgregarProducto(Producto producto)
{
	productos.Add(producto);
}
```

Al mostrar un combo se recorre su lista con `foreach` y se llama a `ObtenerDescripcion()` de cada elemento. Como la lista es de tipo `Producto`, pero puede contener bebidas, entrantes o postres, este recorrido demuestra el polimorfismo.

Para crear un objeto se utiliza `new`:

```csharp
Bebida bebida = new Bebida();
```

La variable `bebida` apunta a un objeto creado a partir de la clase `Bebida`. Después se puede utilizar una propiedad:

```csharp
bebida.Nombre = "Coca-Cola";
Console.WriteLine(bebida.Nombre);
```

`Console.WriteLine` escribe información en la consola. La clase `Console` forma parte de las bibliotecas de .NET.

Una colección de productos se declara con `List<T>`:

```csharp
private List<Producto> productos = new List<Producto>();
```

- `List<Producto>` significa una lista cuyos elementos son objetos `Producto` o clases derivadas.
- `productos` es el nombre de la variable.
- `new List<Producto>()` crea una lista vacía.
- `private` limita el acceso directo a la clase que contiene la lista.

Esto permite que un `Combo` o un `Pedido` almacene bebidas, postres y otros productos en una única colección.

En los archivos de consola se puede escribir directamente código como:

```csharp
Console.WriteLine("Texto");
```

Este formato se llama **top-level statements**. Es una forma abreviada de escribir el método `Main` que sirve como punto de entrada del programa. .NET ejecuta esas instrucciones al iniciar la aplicación.

El proyecto tiene activadas estas opciones en el archivo `.csproj`:

```xml
<ImplicitUsings>enable</ImplicitUsings>
<Nullable>enable</Nullable>
```

`ImplicitUsings` añade automáticamente algunos `using` habituales, como los necesarios para `List<T>`. `Nullable` ayuda a detectar posibles valores `null` antes de ejecutar el programa.

## Comandos básicos de .NET

Los siguientes comandos se ejecutan desde la raíz del repositorio, donde está `Restaurante.sln`.

Comprobar la versión instalada:

```bash
dotnet --version
```

`dotnet --v` no es un comando válido. La opción correcta es `--version`.

Compilar el proyecto:

```bash
dotnet build Restaurante/Restaurante.csproj
```

Una compilación correcta debe terminar con:

```text
Compilación correcta.
0 Advertencias
0 Errores
```

Ejecutar el proyecto:

```bash
dotnet run --project Restaurante/Restaurante.csproj
```

También se puede ejecutar desde la carpeta `Restaurante` con:

```bash
dotnet run
```

Si se utiliza `dotnet run --project Restaurante` desde dentro de la carpeta `Restaurante`, .NET buscará una segunda carpeta `Restaurante` y mostrará un error. En ese caso se debe utilizar `dotnet run` o volver a la raíz del repositorio.

## Ejecución y depuración en VS Code

El botón de ejecución de VS Code puede mostrar `C#: Iniciar proyecto de inicio` o una configuración como `.NET 5+ and .NET Core`. Ambas opciones pueden ejecutar el proyecto .NET; no cambian el lenguaje ni convierten el proyecto.

Para depurar:

1. Abrir `Program.cs`.
2. Colocar un punto de interrupción haciendo clic a la izquierda de una línea.
3. Pulsar `F5` o el botón verde de ejecución.
4. Observar las variables en el panel de depuración.

El mensaje relacionado con `vsdbg` es informativo. Si el programa termina con el código `0`, ha finalizado correctamente.

Que aparezca `Hello, World!` o una prueba como `Coca-Cola` solo indica qué código contiene actualmente `Program.cs`; no representa todavía el menú final del restaurante.

## Comprobación mínima de la base

Durante la preparación inicial se utiliza una prueba pequeña para comprobar que las clases están conectadas:

```csharp
using Restaurante.Models.Productos;

Bebida bebida = new Bebida();
bebida.Nombre = "Coca-Cola";
Console.WriteLine(bebida.Nombre);
```

Esta prueba verifica que:

- `Program.cs` encuentra el namespace de productos.
- `Bebida` existe.
- `Bebida` hereda de `Producto`.
- Se puede crear un objeto.
- Se puede asignar y leer una propiedad.

No es todavía la aplicación completa. Es una prueba temporal de la estructura y puede evolucionar cuando se empiece a crear la carta.

## Rama `feature/entrantes`

La primera funcionalidad del ejercicio consiste en crear la clase `Entrante` y probar tres productos desde `Program.cs`:

```csharp
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
```

La salida comprobada es:

```text
Patatas bravas - 6,00 € para 2 personas, servido caliente
Nachos - 7,00 € para 2 personas, servido caliente
Ensaladilla rusa - 5,50 € para 2 personas, servido frío
```

Los precios son valores de ejemplo. Lo importante en esta prueba es comprobar la herencia, las propiedades propias de `Entrante`, el método `ObtenerDescripcion()` y el uso de `bool` para indicar la temperatura.

## Comprobaciones antes de cerrar una rama

Antes de hacer un commit se recomienda ejecutar:

```bash
dotnet build Restaurante/Restaurante.csproj
dotnet run --project Restaurante/Restaurante.csproj
git diff --check
git status
```

La rama no debe cerrarse mientras la compilación termine con errores.

## Flujo de trabajo con Git

La rama `feature/project-setup` contiene la preparación del proyecto: estructura de carpetas, proyecto .NET, modelos iniciales, namespaces y una prueba mínima.

No debe contener todavía el menú completo, búsquedas, validaciones con `TryParse` ni la gestión completa de pedidos.

Cuando la base esté comprobada:

```bash
git status
git add .
git commit -m "Prepara la estructura base del restaurante"
git push origin feature/project-setup
```

Las siguientes ramas representan funcionalidades completas y no ejercicios aislados. La rama actual termina la funcionalidad de entrantes; la siguiente será la carta del restaurante:

```text
feature/entrantes
feature/carta-restaurante
feature/menu
feature/pedidos
```

La idea es que cada rama añada una parte comprobable del programa y que el historial permita entender la evolución del proyecto.
