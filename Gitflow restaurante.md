# GitFlow aplicado al proyecto

Durante la práctica se utilizará Git para mantener el historial del proyecto y GitFlow como modelo de organización de las ramas.

El objetivo es separar el desarrollo de cada funcionalidad y mantener una versión estable del proyecto.

---

# 1. Preparación del repositorio

Antes de realizar el primer commit, comprobar que el proyecto contiene un archivo `.gitignore`.

## 1.1. .gitignore

El archivo `.gitignore` indica qué archivos y carpetas no deben añadirse al repositorio.

En un proyecto .NET no deben versionarse los archivos generados durante la compilación ni los archivos propios del entorno de desarrollo.

Como mínimo, deberán excluirse:

```gitignore id="yvh08s"
bin/
obj/
.vs/
```

Si se utiliza Rider:

```gitignore id="cf58id"
.idea/
```

El repositorio debe contener el código fuente y los archivos necesarios para reconstruir el proyecto, no los archivos generados durante la compilación.

Una estructura correcta podría ser:

```text id="mhbvev"
Restaurante/
├── .gitignore
├── Restaurante.sln
├── Restaurante/
│   ├── Restaurante.csproj
│   ├── Program.cs
│   ├── Producto.cs
│   ├── Bebida.cs
│   ├── Postre.cs
│   └── ...
```

No deberían aparecer en el repositorio:

```text id="dgayzx"
bin/
obj/
.vs/
.idea/
```

Antes de realizar el primer commit:

```bash id="c4zglp"
git status
```

Revisar los archivos detectados por Git.

Si aparecen carpetas como `bin`, `obj`, `.vs` o `.idea`, revisar el `.gitignore` antes de continuar.

Añadir una carpeta al `.gitignore` no elimina automáticamente archivos que ya hayan sido añadidos anteriormente al repositorio.

Por este motivo, el `.gitignore` debe configurarse antes del primer commit.

---

## 1.2. Inicialización

Si el proyecto todavía no utiliza Git:

```bash id="x5fc8k"
git init
```

Comprobar el estado:

```bash id="pp8v83"
git status
```

Realizar el primer commit:

```bash id="5yjmgw"
git add .
git commit -m "Proyecto inicial del restaurante"
```

Volver a comprobar:

```bash id="4i7t5q"
git status
```

El repositorio debería quedar sin cambios pendientes.

---

# 2. Ramas principales

Durante el desarrollo se utilizarán dos ramas principales:

```text id="g2bq5z"
main
develop
```

## main

Contiene las versiones estables del proyecto.

No se desarrollarán funcionalidades directamente en esta rama.

## develop

Contiene el estado actual del desarrollo.

Las funcionalidades terminadas se integrarán en esta rama.

Si todavía no existe:

```bash id="vb1xy4"
git switch -c develop
```

El flujo general será:

```text id="zgcygj"
feature/* ──────┐
feature/* ──────┼──> develop ──> release/* ──> main
feature/* ──────┘
```

---

# 3. Ramas de funcionalidad

Cada funcionalidad se desarrollará en una rama independiente.

Las ramas utilizarán el prefijo:

```text id="ch0gup"
feature/
```

Por ejemplo:

```text id="8zmq1i"
feature/entrantes
feature/carta
feature/menu
feature/pedidos
```

Las ramas deben representar funcionalidades, no ejercicios.

Evitar nombres como:

```text id="ezgf0j"
feature/ejercicio-1
feature/ejercicio-2
feature/ejercicio-3
```

Por ejemplo, los ejercicios relacionados con mostrar la carta, numerar productos, buscar productos o filtrar por precio pueden formar parte de:

```text id="c8cs22"
feature/carta
```

---

# 4. Crear una feature

Antes de comenzar una nueva funcionalidad, volver a `develop`:

```bash id="4izfr6"
git switch develop
```

Si se trabaja con un repositorio remoto:

```bash id="a97gu7"
git pull
```

Crear la nueva rama:

```bash id="4tnz1p"
git switch -c feature/carta
```

Comprobar la rama actual:

```bash id="a9d4kj"
git branch
```

El desarrollo de la funcionalidad se realizará en esta rama.

---

# 5. Commits durante el desarrollo

No se realizará un único commit al terminar toda la práctica.

Los commits deben representar cambios concretos realizados durante el desarrollo.

Por ejemplo:

```bash id="f7tk1g"
git add .
git commit -m "Añadida carta de productos"
```

Después:

```bash id="4j87df"
git add .
git commit -m "Añadida numeración de productos"
```

Y posteriormente:

```bash id="7wvg4u"
git add .
git commit -m "Añadido filtro de productos por precio"
```

Antes de realizar un commit puede utilizarse:

```bash id="j19fsj"
git status
```

para comprobar los archivos modificados.

También puede utilizarse:

```bash id="mrmim1"
git diff
```

para revisar los cambios realizados.

---

# 6. Mensajes de commit

Los mensajes deben indicar qué cambio se ha realizado.

Ejemplos:

```text id="5q6wqd"
Añadida clase Entrante
Añadida carta de productos
Añadida búsqueda de productos
Añadida validación con TryParse
Añadido menú principal
Añadida gestión de pedidos
Corregida validación al eliminar productos
```

Evitar mensajes como:

```text id="wh9v11"
Cambios
Cosas
Commit
Práctica
Terminado
Final
```

El historial puede consultarse con:

```bash id="rr1bbg"
git log --oneline
```

El historial debería permitir entender cómo ha evolucionado el proyecto.

---

# 7. Finalizar una feature

Cuando una funcionalidad esté terminada, comprobar primero que el proyecto funciona correctamente.

Revisar:

```bash id="p41ofc"
git status
```

No debería haber cambios pendientes.

Volver a `develop`:

```bash id="atbfsa"
git switch develop
```

Si existe repositorio remoto:

```bash id="8i1xjg"
git pull
```

Integrar la funcionalidad:

```bash id="gx04z3"
git merge feature/carta
```

Si la integración es correcta, eliminar la rama local:

```bash id="k3cxx6"
git branch -d feature/carta
```

En este momento la funcionalidad ya forma parte de `develop`.

---

# 8. Comenzar la siguiente funcionalidad

Las nuevas ramas deberán crearse siempre desde `develop`.

Por ejemplo:

```bash id="n0hvke"
git switch develop
git switch -c feature/menu
```

En esta rama podrían desarrollarse:

- Menú principal.
- Lectura de opciones.
- `switch`.
- Validación mediante `TryParse`.
- Separación de las opciones en métodos.

Cuando la funcionalidad esté terminada:

```bash id="u2eyxn"
git switch develop
git merge feature/menu
git branch -d feature/menu
```

---

# 9. Organización de las ramas de la práctica

Una posible organización sería:

```text id="r96vmh"
main
 |
 +-- develop
      |
      +-- feature/entrantes
      |
      +-- feature/carta
      |
      +-- feature/menu
      |
      +-- feature/pedidos
```

No es obligatorio utilizar exactamente estos nombres.

La división deberá tener sentido según las funcionalidades desarrolladas.

No es necesario crear una rama diferente para cada ejercicio.

---

# 10. Desarrollo de pedidos

Para comenzar la gestión de pedidos:

```bash id="b5ve6z"
git switch develop
git switch -c feature/pedidos
```

Durante el desarrollo pueden realizarse varios commits:

```text id="9c5iw8"
Añadida colección de productos al pedido
Añadida opción para añadir productos
Añadida visualización del pedido
Añadida eliminación de productos
Añadida finalización del pedido
```

Una vez terminada la funcionalidad:

```bash id="adn5hy"
git switch develop
git merge feature/pedidos
git branch -d feature/pedidos
```

---

# 11. Release

Cuando las funcionalidades previstas estén terminadas e integradas en `develop`, crear una rama de preparación de versión.

Por ejemplo:

```bash id="1f0eai"
git switch develop
git switch -c release/1.0.0
```

La rama `release` se utilizará para:

- Probar el funcionamiento completo de la aplicación.
- Corregir errores.
- Revisar validaciones.
- Revisar textos mostrados al usuario.
- Comprobar que el proyecto compila correctamente.

No se utilizará para desarrollar funcionalidades nuevas de gran tamaño.

Si se realizan correcciones:

```bash id="16qf0d"
git add .
git commit -m "Corregida validación del menú"
```

---

# 12. Publicar la versión

Cuando la versión esté preparada:

```bash id="1i6ohj"
git switch main
git merge release/1.0.0
```

Crear una etiqueta para identificar la versión:

```bash id="19nbfq"
git tag v1.0.0
```

Los cambios realizados durante la preparación de la versión también deben volver a `develop`:

```bash id="4kl7s6"
git switch develop
git merge release/1.0.0
```

Finalmente:

```bash id="f9s09e"
git branch -d release/1.0.0
```

El resultado será:

```text id="bxx5ym"
feature/* ──> develop ──> release/1.0.0 ──> main
                            |
                            └──────────────> develop
```

---

# 13. Repositorio remoto

Si se utiliza GitHub, GitLab u otro repositorio remoto, las ramas pueden publicarse durante el desarrollo.

La primera vez que se publica `develop`:

```bash id="dxo6vk"
git push -u origin develop
```

Para publicar una feature:

```bash id="t71vfb"
git push -u origin feature/carta
```

Después de configurar la relación con la rama remota:

```bash id="kyonwd"
git push
```

Cuando se publique la versión final:

```bash id="v19jts"
git push origin main
git push origin develop
git push origin --tags
```

---

# 14. Flujo habitual de trabajo

## Crear una funcionalidad

```bash id="1nltfu"
git switch develop
git pull
git switch -c feature/nombre-funcionalidad
```

## Trabajar

```bash id="edrw4g"
git status
git add .
git commit -m "Descripción del cambio"
git push
```

Pueden realizarse varios commits mientras se desarrolla la funcionalidad.

## Integrar

```bash id="i1gs7n"
git switch develop
git pull
git merge feature/nombre-funcionalidad
git push
```

## Comenzar otra funcionalidad

```bash id="g42ns8"
git switch develop
git switch -c feature/otra-funcionalidad
```

---

# 15. Qué debe evitarse

No desarrollar directamente sobre:

```text id="bdw2yf"
main
```

Evitar crear una rama por cada ejercicio:

```text id="cj8ivn"
feature/ejercicio1
feature/ejercicio2
feature/ejercicio3
```

Evitar realizar toda la práctica en un único commit:

```text id="tr8sra"
Práctica terminada
```

Evitar mensajes de commit que no expliquen el cambio realizado.

Evitar mezclar funcionalidades independientes en la misma rama sin necesidad.

Evitar crear una nueva `feature` partiendo de otra `feature`. Las nuevas funcionalidades deben comenzar desde `develop`.

---

# 16. Entrega del proyecto

La entrega incluirá:

1. Enlace al repositorio Git.
2. Archivo `.zip` con el proyecto final.

El repositorio deberá conservar el historial de commits y las ramas utilizadas durante el desarrollo.

El archivo ZIP contendrá el código necesario para abrir, compilar y ejecutar el proyecto.

Antes de crear el ZIP deberán eliminarse las carpetas generadas que no forman parte de la entrega:

```text id="g6hwgr"
bin/
obj/
.vs/
.idea/
.git/
```

No debe eliminarse el archivo:

```text id="hlw62r"
.gitignore
```

El ZIP deberá conservar los archivos necesarios del proyecto, entre ellos:

```text id="9vgy3c"
.gitignore
*.sln
*.csproj
*.cs
```

La carpeta `.git/` no debe incluirse en el ZIP. Esta carpeta contiene internamente el repositorio y su historial, que ya se entregan mediante el enlace al repositorio remoto.

El archivo `.gitignore`, en cambio, sí forma parte del proyecto y debe incluirse.

Antes de entregar, comprobar que el proyecto incluido en el ZIP puede abrirse y compilarse correctamente.

---

# 17. Comprobación final

Antes de entregar, revisar:

- Existe un archivo `.gitignore`.
- `bin`, `obj`, `.vs` e `.idea` no están versionados.
- Existe una rama `main`.
- Existe una rama `develop`.
- Se han utilizado ramas `feature/*`.
- Las ramas representan funcionalidades y no ejercicios individuales.
- Se han realizado varios commits durante el desarrollo.
- Los mensajes de commit describen los cambios realizados.
- No se ha desarrollado directamente en `main`.
- Las funcionalidades terminadas se han integrado en `develop`.
- Se ha preparado una versión mediante `release/1.0.0`.
- La versión estable se encuentra en `main`.
- Existe la etiqueta `v1.0.0`.
- El proyecto compila y funciona correctamente.
- Se entrega el enlace al repositorio.
- Se entrega el proyecto en formato ZIP.
- El ZIP no contiene `bin`, `obj`, `.vs`, `.idea` ni `.git`.

---

# Resumen

| Rama | Uso |
|---|---|
| `main` | Versiones estables |
| `develop` | Desarrollo integrado |
| `feature/*` | Desarrollo de funcionalidades |
| `release/*` | Preparación de una versión |
| `hotfix/*` | Correcciones urgentes sobre una versión publicada |

Para esta práctica se utilizarán principalmente:

```text id="6g2bdt"
main
develop
feature/*
release/*
```

Flujo general:

```text id="nqk2p8"
main
  ↑
release/1.0.0
  ↑
develop
  ↑
feature/*
```