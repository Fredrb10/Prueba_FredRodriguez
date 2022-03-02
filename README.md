# Prueba Tecnica Fred Rodriguez
Proyecto para gestion de libros usando una arquitectura orientada a microservicios para seguridad y .NET 5 MVC para el entorno web.

## ¿Cómo iniciar el proyecto?

### 1. Actualizar los puertos de los proyectos
* FredRodriguez.Library.Authentication: localhost:44309
* FredRodriguez.Library.Travel: localhost:44360
* FredRodriguez.Library.Identity.Api: localhost:44383

### 2. Cambiar las cadenas de conexión
Actualice las cadenas de conexión tanto del proyecto web como la del microservicio identity por las suyas.

### 3. Ejecutar las migraciones
Tanto en el proyecto de microservicios como el web se utilizo el metodo code first usando el orm de Microsoft Entity Framework
* Para ejecutar la migración del Api establecer como proyecto de inicio FredRodriguez.Library.Identity.Api una vez en la consola selecciona el proyecto FredRodriguez.Library.Identity.Persistence.Database para correr la migracion
* Establecer como proyecto de inicio y seleccion FredRodriguez.Library.Travel para la migración del aplicativo web 

Ambas migraciones pueden ser ejecutadas mediante el siguiente comando:
```
update-database 
```
### 4. Agregar usuario a la base de datos
Para este fin existen dos alternativas:
* Meditante la Api: para esto el proyecto FredRodriguez.Library.Identity.Api debe estar arriba, se adjunta archivo postman donde se relacionan los metodos de esta Api entre los cuales se encuentra el de crear un usuario
* Meditante sentencia sql: ejecutar la siguiente sentencia en la base de datos creada, la contraseña creada en esta es 123456:
```
INSERT [Identity].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'cc7deafd-2977-4c1b-91ad-7b8d37a01ffe', N'admin@prueba.com', N'ADMIN@PRUEBA.COM', N'admin@prueba.com', N'ADMIN@PRUEBA.COM', 0, N'AQAAAAEAACcQAAAAEL5faIXPhAOdXYU+vAAKbF32yd2ONSGUdGJ6wo9jkhm8KKlLF/h5x0zjJbcPKt8WYg==', N'PS7QHYXIO4NUC65ZYEP4SBEYOXP4DTWA', N'e955992b-abf5-41d3-b504-ec6dc0632989', NULL, 0, 0, NULL, 1, 0, N'Fred', N'Rodríguez')
```
### 4. Ejecución del proyecto
Se debe establecer en la solución de visual studio como proyectos de inicio múltiples seleccionando los siguientes proyectos:
* FredRodriguez.Library.Authentication
* FredRodriguez.Library.Identity.Api
* FredRodriguez.Library.Travel

Lo anterior debido a que cada proyecto cumple una funcionalidad en el flujo de la aplicación

## Flujo de la aplicación
El proyecto web FredRodriguez.Library.Authentication contiene un formulario para iniciar sesion, desde este conecta con la Api de seguridad FredRodriguez.Library.Identity.Api para gestionar el acceso segun el usuario(correo electronico) y contraseña ingresados, si no son validos mostrará un mensaje denegando el acceso de lo contrario continuara hacia el proyecto FredRodriguez.Library.Travel donde se listan, editan y eliminan los libros.
