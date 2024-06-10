# FutbolMatch

FutbolMatch es un proyecto diseñado para facilitar la organización y gestión de partidos de fútbol. Permite a los usuarios registrarse, iniciar sesión y reservar una cancha.

## Características

- **Registro**: Los usuarios pueden registrarse en la plataforma. Los administradores de cada cancha deben ser creados por el webmaster.
- **Gestión de usuarios**: Administración de usuarios, incluyendo roles, permisos, bloqueo y borrado.
- **Creación de canchas y horarios**: Los administradores dan de alta sus canchas y los horarios permitidos.
- **Reservas**: Los usuarios pueden reservar canchas especificando el establecimiento, el horario y la cancha.

## Tecnologías Utilizadas

El proyecto está desarrollado utilizando varias tecnologías y frameworks:

- **ASP.NET**: Para el backend y la gestión de la lógica de negocio.
- **Bootstrap**: Para el diseño y la interfaz de usuario.
- **MySQL**: Como sistema de gestión de base de datos.

## Estructura del Proyecto

El proyecto está organizado en varias capas para separar responsabilidades:

- **UI**: Capa de Interfaz de Usuario, donde se manejan las vistas y la interacción con el usuario.
- **BE**: Entidades de Negocio, donde se definen los objetos utilizados a lo largo del proyecto.
- **BLL**: Capa de Lógica de Negocio, donde se implementa la lógica principal de la aplicación.
- **DAL**: Capa de Acceso a Datos, encargada de la comunicación con la base de datos.
- **SERVICES**: Servicios adicionales, como la encriptación y gestión de sesiones.
