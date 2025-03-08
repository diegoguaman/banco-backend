# 📌 BancoAPI - Backend en .NET con Docker y PostgreSQL

Este proyecto es un backend construido con **.NET 7/9**, usando **Docker** para facilitar la configuración del entorno de desarrollo y **PostgreSQL** como base de datos. Incluye documentación con **Swagger** para facilitar la exploración y prueba de los endpoints.

## 🚀 Características principales
- Arquitectura basada en capas: **API, Application, Domain, Infrastructure**
- Conexión con **PostgreSQL** usando **Entity Framework Core**
- Contenedores Docker para facilitar el despliegue
- Documentación con **Swagger**

---
## 📌 Requisitos previos
Antes de comenzar, asegúrate de tener instalados:

- [Docker](https://www.docker.com/get-started) y Docker Compose
- [Git](https://git-scm.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (versión compatible con el proyecto, 7.0 o 9.0 según configurado en `docker-compose.yml`)

---
## 📌 Instalación y configuración

### 1️⃣ **Clonar el repositorio**
```sh
git clone https://github.com/tu-usuario/BancoAPI.git
cd BancoAPI
```

### 2️⃣ **Configurar variables de entorno (Opcional)**
Si deseas personalizar la configuración de la base de datos, crea un archivo **`.env`** en la raíz del proyecto con el siguiente contenido:

```
POSTGRES_USER=postgres
POSTGRES_PASSWORD=mysecretpassword
POSTGRES_DB=BancoDB
```

### 3️⃣ **Construir y levantar los contenedores con Docker**
```sh
docker-compose up -d --build
```
✅ Esto iniciará:
- **API en http://localhost:8080**
- **Base de datos en `localhost:5432`**

Si usaste otro puerto en `docker-compose.yml`, asegúrate de acceder con el puerto correcto.

### 4️⃣ **Verificar que la API esté corriendo**
Prueba accediendo a:
```sh
curl http://localhost:8080/api/home
```
O abre en tu navegador:
```
http://localhost:8080/api/home
```
Deberías ver una respuesta JSON como:
```json
{"mensaje": "La API está funcionando 🚀"}
```

### 5️⃣ **Acceder a la documentación Swagger**
La API cuenta con documentación interactiva generada por Swagger:
```
http://localhost:8080/swagger
```
Aquí podrás explorar y probar los endpoints de manera sencilla.

---
## 📌 Comandos útiles

### **Apagar los contenedores**
```sh
docker-compose down
```

### **Reiniciar la API después de cambios**
```sh
docker-compose up -d --build
```

### **Ver los logs en tiempo real**
```sh
docker logs -f banco-api
```

### **Acceder a la base de datos dentro del contenedor**
```sh
docker exec -it banco-db psql -U postgres -d BancoDB
```

---
## 📌 Contribución
Si deseas contribuir, por favor:
1. **Haz un fork** del repositorio
2. **Crea una nueva rama** (`git checkout -b feature/nueva-funcionalidad`)
3. **Realiza tus cambios y súbelos** (`git push origin feature/nueva-funcionalidad`)
4. **Abre un Pull Request**

---
## 📌 Licencia
Este proyecto está bajo la licencia MIT. Puedes usarlo libremente para tus desarrollos. 🚀

