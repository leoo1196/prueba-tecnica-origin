# prueba-tecnica-origin

## Stack

### Backend

.NET 6
EntityFrameworkCore 6

### Frontend

React 18.2.0

### Base de datos

SQL SERVER

## Pasos para correr la aplicacion

### Iniciar la API

Correr el proyecto [WebApi] como https en el puerto 7286 (ya configurado en launchSettings). 

Al iniciarse creara automaticamente la base [OriginTestDb] sobre la instancia local SQLEXPRESS01 (modificar el connectionString en caso de ser necesario).

Tambien se crearan automaticamente los datos de prueba en la tabla de tarjetas. Los conjuntos numero de tarjeta-pin son:

1111111111111111	1234
2222222222222222	4321
3333333333333333	6789

### Iniciar la app de front

Ejecutar los siguientes comandos para el proyecto [front]:

npm install
npm start