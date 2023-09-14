# Art Living Emporium

Es una plataforma de comercio electrónico de arte en su categorias de pintura ( óleo y acuarela) y escultura (bustos y céramica),  que permite a los artistas exponer y vender sus obras de arte, y a los clientes explorar y adquirir piezas únicas. Para lograr esto, se prestara una atención especial al diseño y a la experiencia del usuario.Este repositorio contiene el código fuente y la documentación de la plataforma. Que nace de una  eCommerce en linea que esta diseñado y desarrollado para ofrecer una experiencia de compra excepcional tanto para los usuarios como para los administradores. 

### Logo eCommerce: Art Living Imperium

![](https://res.cloudinary.com/dhme3c8ll/image/upload/v1692950303/Logo-Arte_haqmng.png)

### Portada Principal de la eCommerce. Tú puedes amar el arte en todo su esplendor... 

![](https://res.cloudinary.com/dqc0wvttr/image/upload/v1693317518/Portada_f4hc6a.png)

# Funcionalidades Destacadas

- **Registro de Usuarios:** Los usuarios pueden registrarse como Clientes o Exponentes de arte.
- **Exposición de Obras:** Los Exponentes pueden cargar sus obras de arte para su revisión por parte del administrador.
- **Catálogo de Obras:** Los Clientes pueden explorar un catálogo completo de obras de arte, filtrar por categoría y tipo, y ver detalles de las obras disponibles.
- **Gestión de Pedidos:** Los Clientes pueden realizar pedidos y hacer un seguimiento de su estado. El administrador gestiona el estado de los pedidos.
- **Gestión de Marca:** Los Exponentes pueden gestionar su marca, incluyendo su nombre y descripción.
- **Interfaz Swagger:** Los Clientes pueden interactuar con la plataforma a través de Swagger para realizar pedidos de manera eficiente.

# Estructura de archivos 📁

En esta Interfaz de Programación de Aplicaciones (API), la organización y disposición de los archivos y carpetas dentro del código fuente de la API. Facilita el desarrollo, el mantenimiento y la colaboración en un proyecto de API. Por lo que a continuación, se describen los componentes típicos de la estructura de archivos que la integran.

### 1.- Base de Datos o API:
 Permite a las aplicaciones comunicarse entre sí, mientras que una base de datos es un sistema para almacenar y gestionar datos de manera organizada.
### 2.- Datos:
Para estructurar datos en una base de datos, usamos migraciones. Estas son secuencias de comandos que definen cambios en la base de datos, como crear o modificar tablas. Mantienen un registro de la evolución de la estructura de la base de datos.
### 3.- Entidades:
En el contexto de este proyecto la bases de datos, las entidades son como categorías que representan objetos del mundo real. Cada entidad se traduce generalmente en una tabla en la base de datos, y cada fila en esa tabla es una instancia específica de esa entidad. Por ejemplo, en una aplicación de gestión de productos de arte, tendrías una entidad llamada "Producto" que corresponde a todos los productos de arte disponibles. Cada fila en la tabla "Producto" sería una instancia individual de un producto con sus detalles únicos, como el nombre de la obra, el autor, la descripción y el precio. Cada producto en la vida real se convierte en una fila de datos en esa tabla.
### 4.- Web-Art-Imporium: 
Es la parte principal de nuestra aplicación web, es decir el cuerpo principal de la aplicación que contiene todas las cosas que hacen que funcione. Aquí es donde está el código que hace que la aplicación haga todas las cosas interesantes que queremos que haga. Esto incluye las diferentes funciones que los usuarios pueden utilizar, cómo se ven y funcionan las páginas, y cómo se conecta a la base de datos o la API para obtener y guardar información.
#### 4. 1.- Controlador:
Los controladores son funciones que manejan solicitudes, actúan como intermediarios entre la interfaz de usuario y los servicios backend de la API. Reciben solicitudes, ejecutan lógica y envían respuestas
#### 4. 2.- IServices: 
 Son interfaces que establecen contratos para operaciones en las tablas/entidades, como CRUD y otras acciones relacionadas con los datos.
#### 4. 3.- Servicios:
Los servicios almacenan la lógica de negocios y operaciones de las tablas. Implementan los métodos de las interfaces IServices, interactúan con la base de datos y realizan operaciones como leer, escribir, actualizar o eliminar registros.
#### 4. 4.- Appsettings.json: 
Donde SQL Server está vinculado a la base de datos. Es un archivo de configuración que almacena las cadenas de conexión necesarias para vincular una aplicación a una instancia de SQL Server, lo que permite una gestión más sencilla y flexible de la configuración de la base de datos.
#### 4. 5.-  Programa: 
La conexión entre la API y Swagger se encuentra en el archivo "Program.cs", que es el punto de entrada principal de la aplicación. En este archivo, se configura la API para integrar Swagger, una herramienta que proporciona documentación y pruebas para la API. Esta integración permite a los desarrolladores y usuarios explorar y utilizar fácilmente los puntos finales de la API.

# Diagrama Relacional
Hemos diseñado y creado prototipos de las interfaces de usuario. Puedes ver aquí 
[Fujo de Proceso](https://www.canva.com/design/DAFruNyV4gw/3B49UM-5Vwu7m0daW0r6Dg/edit?utm_content=DAFruNyV4gw&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)
[Diagrama de Tablas Relacionales](https://drive.google.com/file/d/1EiF45_dEufJYUXIiz4VYLHzcudxYibnZ/view?usp=sharing).

### Instrucciones de Uso y sus tecnologías utilizadas (LIFO (Last-In-First-Out)):
🖥️.-1. Clona este repositorio. **Microsoft Visual Studio 2022**, **Visual Code Studio**, **GitHub**
2. Configura el entorno de desarrollo siguiendo las instrucciones en el
   [Enlace Proyecto-Web-Art](https://github.com/isabellozano37/Proyecto-Web-Art.git))
   [Enlace Web-Art-Emporium-Backend](https://github.com/isabellozano37/Web-Art-Emporium-Backend.git.)
3.- Navega al directorio del proyecto: cd nombre_del_repositorio
4.- Instala las dependencias: npm install (**Axios**,  **J-son**,  **Cloudinariy**, **React**) 
5.- Inicia la aplicación: npm start
6. Ejecuta la aplicación y comienza a explorar las obras de arte o a contribuir como Exponente. (**Swagger** , **SQL Server** , **C#**) - 🔨
Debes de considerar que estas otras herramientas tecnológicas, como: - **Trello** [Enlace](https://trello.com/b/b1DVprfq/proyecto-7) y - **Figma** son importantes en la relización del proyecto. 

## Contribución
Si deseas contribuir a este proyecto, sigue estos pasos:
1.- Crea un fork del repositorio.
2.- Crea una rama para tu contribución: git checkout -b mi-contribucion
3.- Realiza tus cambios y asegúrate de seguir las pautas de estilo.
4.- Haz commit de tus cambios: git commit -m "Agrega mi contribución"
5.- Envía tus cambios a tu fork en GitHub: git push origin mi-contribucion
6.- Crea un Pull Request desde tu fork a este repositorio.


# Licencia
Este proyecto está bajo la licencia [Lc.Profram]. Consulta el archivo LICENSE.md para más detalles.

Contacto
Si tienes preguntas o sugerencias, no dudes en ponerte en contacto con nosotros:

Email: artlivingemporium@gmail.com
¡Gracias por tu interés en Art Living Imperum!

Autores ✒️
ISABEL LOZANO
ANGEL SERRANO
JUAN LUMBI
ANTHONY BRAYAN
RAUL MUÑOZ
