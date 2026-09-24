# Práctica C# - Restaurante

El objetivo de la práctica es continuar el desarrollo de la aplicación de restaurante utilizada en clase.

Se trabajarán los siguientes contenidos:

- Clases y objetos.
- Herencia.
- Clases y métodos abstractos.
- `override`.
- Polimorfismo.
- Colecciones `List<T>`.
- Comprobación de tipos mediante `is`.
- Métodos y parámetros.
- `while` y `switch`.
- Lectura de datos mediante `Console.ReadLine()`.
- Validación mediante `TryParse()`.

La práctica deberá desarrollarse utilizando Git y siguiendo el flujo de trabajo descrito en `GITFLOW.md`.

---

# Bloque 1 - Herencia y polimorfismo

## 1. Clase Entrante

Crear una nueva clase `Entrante` que herede de `Producto`.

Un entrante tendrá la siguiente información:

- Nombre.
- Precio.
- Número de personas para las que está pensado.
- Si se sirve frío o caliente.

Implementar el método:

```csharp
ObtenerDescripcion()
```

para que devuelva la información del entrante.

Crear en `Program.cs` al menos tres entrantes:

- Patatas bravas.
- Nachos.
- Ensaladilla rusa.

Mostrar por pantalla la descripción de cada uno.

---

## 2. Carta del restaurante

Crear diferentes productos para el restaurante:

- 2 bebidas.
- 2 platos principales.
- 2 postres.
- 2 entrantes.

Todos los productos se almacenarán en una única colección:

```csharp
List<Producto>
```

Recorrer la colección utilizando un `foreach` y mostrar el nombre y el precio de todos los productos.

Ejemplo:

```text
=== CARTA ===

Patatas bravas - 6 €
Hamburguesa - 12 €
Pizza - 11 €
Coca-Cola - 3 €
Tarta de queso - 5 €
```

Responder:

1. ¿Por qué una `List<Producto>` puede contener objetos de tipo `Bebida`, `Postre`, `PlatoPrincipal` o `Entrante`?
2. ¿Qué relación existe entre estas clases y `Producto`?

---

## 3. Carta numerada

Modificar la visualización de la carta para que cada producto aparezca numerado.

Ejemplo:

```text
=== CARTA ===

1. Patatas bravas - 6 €
2. Hamburguesa - 12 €
3. Pizza - 11 €
4. Coca-Cola - 3 €
5. Tarta de queso - 5 €
```

La numeración deberá generarse al recorrer la colección.

No se indicará manualmente el número correspondiente a cada producto.

---

## 4. Filtrado por tipo

Recorrer la colección de productos y mostrar únicamente aquellos que sean de tipo `Bebida`.

Para realizar la comprobación se puede utilizar:

```csharp
producto is Bebida
```

Mostrar la descripción completa de cada bebida encontrada.

Responder:

1. ¿Qué tipo tiene la variable utilizada para recorrer la `List<Producto>`?
2. ¿Puede esa variable contener un objeto cuyo tipo real sea `Bebida`?
3. ¿Qué permite comprobar el operador `is`?

---

## 5. Polimorfismo

Analizar el siguiente código:

```csharp
Producto producto1 = new Bebida(...);
Producto producto2 = new Postre(...);
Producto producto3 = new Entrante(...);

Console.WriteLine(producto1.ObtenerDescripcion());
Console.WriteLine(producto2.ObtenerDescripcion());
Console.WriteLine(producto3.ObtenerDescripcion());
```

Sin ejecutar inicialmente el programa, responder:

1. ¿Cuál es el tipo de la variable `producto1`?
2. ¿Cuál es el tipo real del objeto almacenado en `producto1`?
3. ¿Qué implementación de `ObtenerDescripcion()` se ejecutará?
4. ¿Qué ocurrirá con `producto2`?
5. ¿Qué ocurrirá con `producto3`?
6. ¿Qué concepto de programación orientada a objetos permite este comportamiento?

Después de responder, ejecutar el código y comprobar el resultado.

---

## 6. ¿Compila?

Analizar los siguientes fragmentos sin ejecutarlos inicialmente.

Para cada caso indicar:

- Si compila.
- Si no compila, explicar el motivo.
- Si compila, indicar qué tipo tiene la variable y cuál es el tipo real del objeto cuando sean diferentes.

### A

```csharp
Producto producto = new Producto(...);
```

### B

```csharp
Bebida bebida = new Bebida(...);
Producto producto = bebida;
```

### C

```csharp
Producto producto = new Bebida(...);
```

### D

```csharp
Producto producto = new Bebida(...);
Bebida bebida = producto;
```

### E

```csharp
List<Producto> productos = new List<Producto>();

productos.Add(new Bebida(...));
productos.Add(new Postre(...));
productos.Add(new Entrante(...));
```

### F

```csharp
Producto producto = new Bebida(...);

Console.WriteLine(producto.ObtenerDescripcion());
```

Después de responder, comprobar los resultados ejecutando los fragmentos necesarios.

---

# Bloque 2 - Entrada de datos y validación

## 7. Seleccionar un producto

Permitir al usuario seleccionar un producto mediante su número.

Ejemplo:

```text
=== CARTA ===

1. Patatas bravas - 6 €
2. Hamburguesa - 12 €
3. Pizza - 11 €

¿Qué producto quieres? 3

Has elegido:
Pizza - 11 €
```

Utilizar `int.TryParse()` para comprobar que el valor introducido puede convertirse a un número entero.

Si el usuario introduce:

```text
¿Qué producto quieres? hola
```

el programa deberá mostrar:

```text
Debes introducir un número.
```

---

## 8. Validar la selección

Ampliar el ejercicio anterior para controlar también que el número corresponda a un producto existente.

Ejemplo de entrada no numérica:

```text
¿Qué producto quieres? Pepe

Debes introducir un número.
```

Ejemplo de número inexistente:

```text
¿Qué producto quieres? 27

Ese producto no existe.
```

El producto solamente se mostrará cuando la selección sea válida.

Probar también valores como:

```text
0
-3
999
2.5
```

El programa no deberá finalizar inesperadamente como consecuencia de una entrada incorrecta.

---

## 9. Buscar un producto por nombre

Solicitar al usuario el nombre de un producto.

Ejemplo:

```text
Producto a buscar: Cerveza
```

Recorrer la carta y comprobar si existe.

Si se encuentra:

```text
Producto encontrado:

Cerveza - 3 €
```

Si no existe:

```text
No se ha encontrado el producto.
```

Resolver el ejercicio sin utilizar LINQ.

La búsqueda no debería depender de que el usuario escriba exactamente las mismas mayúsculas y minúsculas utilizadas al crear el producto.

Por ejemplo:

```text
cerveza
Cerveza
CERVEZA
```

deberían permitir encontrar el mismo producto.

---

## 10. Productos por precio

Solicitar al usuario un precio máximo:

```text
Precio máximo: 10
```

Utilizar `decimal.TryParse()` para validar el valor introducido.

Mostrar todos los productos cuyo precio sea igual o inferior al indicado.

Ejemplo:

```text
Productos de hasta 10 €:

Patatas bravas - 6 €
Coca-Cola - 3 €
Tarta de queso - 5 €
```

Si no existe ningún producto que cumpla la condición, mostrar un mensaje indicándolo.

Resolver el ejercicio sin utilizar LINQ.

---

## 11. Producto más caro

Recorrer la carta y localizar el producto con el precio más alto.

Ejemplo:

```text
El producto más caro es:

Hamburguesa XXL - 16 €
```

El resultado deberá calcularse a partir de los productos almacenados en la colección.

No se indicará manualmente cuál es el producto más caro.

Resolver el ejercicio sin utilizar LINQ.

---

# Bloque 3 - Métodos y menú de la aplicación

## 12. Extraer la visualización de la carta a un método

Hasta ahora la carta se ha mostrado directamente desde `Program.cs`.

Crear un método que reciba la colección de productos y muestre la carta:

```csharp
MostrarCarta(List<Producto> carta)
```

El método:

- Recibirá la carta mediante un parámetro.
- No creará los productos.
- No creará una nueva carta.
- Mostrará los productos que recibe.

La llamada desde el programa deberá ser similar a:

```csharp
MostrarCarta(carta);
```

Modificar el programa para utilizar este método siempre que sea necesario mostrar la carta.

---

## 13. Separar operaciones en métodos

Crear métodos para las operaciones realizadas en los ejercicios anteriores.

Como referencia:

```csharp
MostrarCarta(List<Producto> carta)
ElegirProducto(List<Producto> carta)
BuscarProducto(List<Producto> carta)
MostrarProductosPorPrecio(List<Producto> carta)
MostrarProductoMasCaro(List<Producto> carta)
```

Los métodos deberán recibir mediante parámetros la información que necesiten.

Evitar utilizar variables globales para acceder a la carta desde todos los métodos.

---

## 14. Menú principal

Crear un menú que permita acceder a las operaciones desarrolladas.

Ejemplo:

```text
========================
      RESTAURANTE
========================

1. Ver carta
2. Elegir producto
3. Buscar producto
4. Productos por precio
5. Producto más caro
0. Salir

Elige una opción:
```

El programa deberá continuar ejecutándose hasta que el usuario seleccione `0`.

Utilizar:

- `while`.
- `switch`.
- `Console.ReadLine()`.
- `TryParse()`.

Cada opción del `switch` deberá llamar al método correspondiente.

Ejemplo:

```csharp
switch (opcion)
{
    case 1:
        MostrarCarta(carta);
        break;

    // ...
}
```

Si el usuario introduce una opción incorrecta, mostrar un mensaje y volver al menú.

---

## 15. Revisar la estructura de Program.cs

Revisar el código después de implementar el menú.

El código principal debería encargarse principalmente de:

1. Crear los datos iniciales.
2. Mostrar el menú.
3. Leer la opción.
4. Ejecutar la operación correspondiente.

La lógica de búsqueda, visualización o filtrado no debería estar escrita directamente dentro de cada `case` del `switch`.

Por ejemplo, se evitará una estructura de este tipo:

```csharp
case 3:

    foreach (...)
    {
        if (...)
        {
            // ...
        }
    }

    break;
```

y se utilizará:

```csharp
case 3:
    BuscarProducto(carta);
    break;
```

---

# Bloque 4 - Gestión de pedidos

## 16. Crear un pedido

Añadir la posibilidad de almacenar los productos seleccionados por un cliente.

Crear:

```csharp
List<Producto> pedido = new List<Producto>();
```

Modificar el menú:

```text
========================
      RESTAURANTE
========================

1. Ver carta
2. Añadir producto al pedido
3. Ver pedido
4. Buscar producto
5. Productos por precio
0. Salir
```

Crear un método para añadir productos:

```csharp
AgregarProductoAlPedido(
    List<Producto> carta,
    List<Producto> pedido
)
```

Al seleccionar la opción correspondiente:

1. Mostrar la carta numerada.
2. Solicitar el número del producto.
3. Validar la entrada mediante `TryParse()`.
4. Comprobar que el producto existe.
5. Añadirlo al pedido.
6. Mostrar un mensaje de confirmación.

Ejemplo:

```text
¿Qué producto quieres añadir? 2

Hamburguesa añadida al pedido.
```

---

## 17. Ver el pedido

Crear un método:

```csharp
MostrarPedido(List<Producto> pedido)
```

El método mostrará los productos añadidos y calculará el precio total.

Ejemplo:

```text
=== TU PEDIDO ===

Hamburguesa       12 €
Cerveza            3 €
Tarta de queso     5 €

----------------------
TOTAL:             20 €
```

El total deberá calcularse recorriendo los productos del pedido.

Si el pedido está vacío, mostrar:

```text
El pedido está vacío.
```

---

## 18. Eliminar un producto del pedido

Añadir una opción al menú:

```text
4. Eliminar producto del pedido
```

Crear el método correspondiente.

Al seleccionar esta opción, mostrar el pedido numerado:

```text
=== TU PEDIDO ===

1. Hamburguesa - 12 €
2. Cerveza - 3 €
3. Tarta de queso - 5 €

¿Qué producto quieres eliminar?
```

Validar:

- Que el usuario haya introducido un número.
- Que el número corresponda a un producto del pedido.

Si la selección es correcta:

```text
Cerveza eliminada del pedido.
```

Si el pedido está vacío, no se solicitará ningún número.

---

## 19. Finalizar el pedido

Añadir una opción:

```text
5. Finalizar pedido
```

Al finalizar, mostrar un resumen:

```text
======= TICKET =======

Hamburguesa       12 €
Cerveza            3 €
Tarta de queso     5 €

----------------------
Productos:          3
TOTAL:             20 €

Gracias por tu visita.
```

Después de finalizar el pedido, vaciar el pedido actual para permitir comenzar uno nuevo.

Si el pedido está vacío, no deberá generarse un ticket.

---

## 20. Menú final

Al terminar los ejercicios anteriores, el menú deberá permitir acceder a todas las funcionalidades implementadas.

Una posible organización es:

```text
========================
      RESTAURANTE
========================

1. Ver carta
2. Añadir producto al pedido
3. Ver pedido
4. Eliminar producto del pedido
5. Finalizar pedido
6. Buscar producto
7. Productos por precio
8. Producto más caro
0. Salir

Elige una opción:
```

Revisar que:

- Una entrada incorrecta no finalice la aplicación.
- Las opciones se ejecuten mediante métodos.
- La carta se pase a los métodos que la necesiten.
- El pedido se pase a los métodos que lo necesiten.
- El menú vuelva a mostrarse después de ejecutar cada operación.
- La opción `0` finalice el programa.

---

# Organización del trabajo

La práctica está dividida en cuatro bloques.

## Bloque 1 - Herencia y polimorfismo

Ejercicios 1 a 6.

Se amplía el modelo de clases y se trabaja con diferentes tipos de objetos mediante `Producto`.

## Bloque 2 - Entrada de datos y validación

Ejercicios 7 a 11.

Se incorporan datos introducidos por el usuario y se utiliza `TryParse()` para validarlos.

## Bloque 3 - Métodos y menú

Ejercicios 12 a 15.

Se reorganiza el código mediante métodos y se construye el menú principal de la aplicación.

## Bloque 4 - Gestión de pedidos

Ejercicios 16 a 20.

Se amplía la aplicación para permitir crear y gestionar un pedido.

No es necesario utilizar `try/catch` para realizar estos ejercicios.

---

# Control de versiones

La práctica deberá realizarse utilizando Git y siguiendo el flujo de trabajo descrito en `GITFLOW.md`.

Las ramas deberán representar funcionalidades y no ejercicios individuales.

Por ejemplo:

```text
feature/entrantes
feature/carta
feature/menu
feature/pedidos
```

El repositorio deberá permitir revisar la evolución del proyecto mediante las ramas y los commits realizados durante el desarrollo.