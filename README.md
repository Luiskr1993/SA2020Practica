# SA2020Practica
Este proyecto tiene como objetivo establecer comunicación con un servicio SOAP, a través del cual se ejecutarán diversas funciones para la creación de contactos dentro de una aplicación Joomla llamada "API Hal". Para la primera práctica se ejecutarán las funciones de creación de nuevos contactos y la función de listar contactos. Para interactuar con dicho servicio se construyó una aplicación web en la cual se encontrará una sección específica para cada función a consumir correspondiente a la API. El resultado retornado por ambas funciones se mostrará en las secciones correspondientes a la función ejecutada.  

## Comenzando 🚀
Puedes obtener una copia del código descargando las carpetas correspondientes de este repositorio.


## Pre-requisitos 📋

_Que cosas necesitas para instalar el software y como instalarlas_

Para poder ejecutar la aplicación es necesario tener instalado algún entorno de Visual Studio (Recomendado VS2017). Y también es necesario algún navegador web para poder visualizar la ejecución del proyecto.


## ¿Cómo funciona? ⚙️

1. Para poder probar la aplicación, es necesario ejecutar el proyecto dentro de visual studio, el cual abrirá la aplicación web en una nueva ventana del navegador seleccionado.
2. En la pantalla principal hay una sección de información en la cual se encuentran mis datos de estudiante. También hay una sección para listar una cantidad de contactos y también una sección para agregar un nuevo contacto.

#### Agregar nuevo contacto 🖇️
Para agregar un nuevo contacto basta con ubicarse en la sección identificada con esta función y hacer lo siguiente:
1. Escribir el nombre del nuevo contacto a agregar.
2. Dar click en el botón agregar.

Si el contacto fue agregado correctamente, la aplicación mostrará un mensaje de éxito justo arriba del botón "Agregar". De lo contrarió indicará al usuario que no se pudo realizar la acción.

#### Listar Contactos 🔩
Para visualizar una lista de varios contactos basta con ubicarse en la sección identificada con esta función y hacer lo siguiente:
1. Escribir un término especifico para filtrar los contactos. "Ejemplo: filtrar por letra 'A'"
2. Escribir la cantidad de contactos a visualizar. 
3. Dar click en "Listar Contactos>>"

Si la comunicación con la API se realizó exitosamente, la aplicación mostrará debajo del botón "Listar Contactos" una tabla ordenada por ID y Nombre de contacto. 

## Construido con 🛠️

* [Visual Studio 2017](https://visualstudio.microsoft.com/es/) - El framework utilizado
* [C#] - Lenguaje de code-behind utilizado
* [API Hal]( https://api.softwareavanzado.world/index.php?webserviceClient=administrator&webserviceVersion=1.0.0&option=contact&api=hal&format=doc) - Servicio SOAP


## Autores ✒️


* **Luis Carlos Valiente Salazar - 201122864** - *Desarrollo*
