# 🔐 Sistema de Autenticación JWT - Q10 Task Manager

## Características Implementadas

### ✅ Autenticación JWT Completa
- **Registro de usuarios** con validación de datos
- **Login** con email y contraseña
- **Tokens JWT** con expiración configurable
- **Hash de contraseñas** con BCrypt (salt rounds: 12)
- **Validación de tokens** en tiempo real

### ✅ Autorización Basada en Roles
- **Roles**: `User` y `Admin`
- **Políticas de autorización** personalizadas
- **Claims** en tokens JWT para información del usuario
- **Endpoints protegidos** con diferentes niveles de acceso

### ✅ Seguridad Avanzada
- **Validación de tokens** con firma digital
- **Claims personalizados** (UserId, Email, Role)
- **Logging de seguridad** para auditoría
- **Configuración flexible** via appsettings.json

### ✅ Integración con Swagger
- **Autenticación Bearer Token** en Swagger UI
- **Botón "Authorize"** para ingresar tokens
- **Documentación automática** de endpoints protegidos

## 🚀 Cómo Usar

### 1. Ejecutar la Aplicación
```bash
cd api/Q10.TaskManager.Api
dotnet run
```

### 2. Acceder a Swagger
- URL: `https://localhost:7000/swagger`
- Usar el botón "Authorize" para autenticarse

### 3. Usuario Administrador por Defecto
- **Email**: `admin@q10taskmanager.com`
- **Password**: `Admin123!`

### 4. Flujo de Autenticación

#### Paso 1: Registrar Usuario
```http
POST /api/auth/register
{
  "username": "testuser",
  "email": "test@example.com",
  "password": "Test123!",
  "firstName": "Test",
  "lastName": "User"
}
```

#### Paso 2: Iniciar Sesión
```http
POST /api/auth/login
{
  "email": "test@example.com",
  "password": "Test123!"
}
```

#### Paso 3: Usar Token en Requests
```http
GET /api/tasks
Authorization: Bearer YOUR_JWT_TOKEN
```

## 🔒 Endpoints de Seguridad

### Públicos (No requieren autenticación)
- `GET /api/security/public` - Información pública
- `POST /api/auth/register` - Registro de usuarios
- `POST /api/auth/login` - Inicio de sesión

### Protegidos (Requieren autenticación)
- `GET /api/security/protected` - Información protegida
- `GET /api/security/token-info` - Información del token
- `GET /api/tasks` - Listar tareas
- `POST /api/tasks` - Crear tarea
- `PUT /api/tasks/{id}` - Actualizar tarea
- `DELETE /api/tasks/{id}` - Eliminar tarea

### Solo Administradores
- `GET /api/security/admin-only` - Información solo para admins

### Usuarios y Administradores
- `GET /api/security/user-or-admin` - Información para usuarios autenticados

## ⚙️ Configuración JWT

```json
{
  "JwtSettings": {
    "SecretKey": "YourSuperSecretKeyThatIsAtLeast32CharactersLong!",
    "Issuer": "Q10TaskManager",
    "Audience": "Q10TaskManagerUsers",
    "ExpirationMinutes": 60
  }
}
```

## 🛡️ Ventajas de Seguridad de .NET Core 9

### 1. **Autenticación JWT Robusta**
- Validación de firma digital
- Claims personalizados
- Expiración automática de tokens
- Validación de issuer y audience

### 2. **Hash de Contraseñas Seguro**
- BCrypt con salt rounds configurables
- Resistente a ataques de fuerza bruta
- Salt único por contraseña

### 3. **Autorización Granular**
- Políticas de autorización personalizadas
- Roles y claims flexibles
- Middleware de autorización integrado

### 4. **Logging de Seguridad**
- Auditoría de intentos de login
- Logging de operaciones sensibles
- Trazabilidad completa de acciones

### 5. **Configuración Flexible**
- Configuración via appsettings.json
- Diferentes configuraciones por ambiente
- Secretos seguros para producción

### 6. **Integración con Swagger**
- Autenticación visual en Swagger UI
- Documentación automática de seguridad
- Testing fácil de endpoints protegidos

## 🧪 Testing

Usa el archivo `test-auth.http` para probar todos los endpoints:

1. **Registrar usuario** → Obtener token
2. **Usar token** en requests protegidos
3. **Probar diferentes roles** (User vs Admin)
4. **Verificar validación** de tokens

## 📊 Estructura de Base de Datos

```sql
CREATE TABLE "Users" (
    "Id" SERIAL PRIMARY KEY,
    "Username" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(255) NOT NULL UNIQUE,
    "PasswordHash" TEXT NOT NULL,
    "FirstName" VARCHAR(100),
    "LastName" VARCHAR(100),
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "LastLoginAt" TIMESTAMP,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "Role" VARCHAR(50) NOT NULL DEFAULT 'User'
);
```

## 🔧 Próximos Pasos

1. **Refresh Tokens** para renovación automática
2. **Rate Limiting** para prevenir ataques
3. **2FA** con autenticación de dos factores
4. **Audit Logs** para cumplimiento
5. **CORS** configurado para producción
6. **HTTPS** obligatorio en producción

---

**¡El sistema de autenticación está listo para usar!** 🎉