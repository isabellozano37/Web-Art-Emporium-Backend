using Data;
using Entities;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class SolicitudesControles : ControllerBase
    {

        private readonly ISolicitudesServicio _solicitudService;
        private readonly ServiceContext _serviceContext;

        public SolicitudesControles(ISolicitudesServicio solicitudService, ServiceContext serviceContext)
        {
            _solicitudService = solicitudService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertSolicitudes")]
        public int Post([FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña, [FromBody] Solicitud solicitud)
        {
            var seletedUser = _serviceContext.Set<Usuario>()
                               .Where(u => u.Nombre_Usuario == userNombre_Usuario
                                    && u.Contraseña == userContraseña
                                    && u.IdRoll == 2)
                                .FirstOrDefault();

            if (seletedUser != null)
            {

                _serviceContext.AuditLogs.Add(new AuditLog
                {
                    Action = "Insert",
                    TableName = "Solicitud",
                    Timestamp = DateTime.Now,
                    UserId = seletedUser.Id_Usuario
                });

                return _solicitudService.InsertSolicitudes(solicitud);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }

        [HttpPut(Name = "UpdateSolicitud")]
        public IActionResult UpdateSolicitud(int solicitudId, [FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña, [FromBody] Solicitud updatedSolicitud)
        {
            var seletedUser = _serviceContext.Set<Usuario>()
                               .Where(u => u.Nombre_Usuario == userNombre_Usuario
                                    && u.Contraseña == userContraseña
                                    && u.IdRoll == 2)
                                .FirstOrDefault();

            if (seletedUser != null)
            {
                var solicitud = _serviceContext.Solicitud.FirstOrDefault(p => p.Id_Solicitud == solicitudId);

                if (solicitud != null)
                {
                    solicitud.Imagen = updatedSolicitud.Imagen;
                    solicitud.Nombre = updatedSolicitud.Nombre;
                    solicitud.Descripción = updatedSolicitud.Descripción;
                    solicitud.Precio = updatedSolicitud.Precio;
                    solicitud.Estado = updatedSolicitud.Estado;

                    _serviceContext.AuditLogs.Add(new AuditLog
                    {
                        Action = "Update",
                        TableName = "Solicitud",
                        Timestamp = DateTime.Now,
                        UserId = seletedUser.Id_Usuario
                    });

                    _serviceContext.SaveChanges();

                    return Ok("La Solicitud se ha actualizado correctamente.");
                }
                else
                {
                    return NotFound("No se ha encontrado la solicitud con el identificador especificado.");
                }
            }
            else
            {
                return Unauthorized("El usuario no está autorizado o no existe");
            }
        }

        [HttpGet(Name = "GetSolicitudes")]
        public IActionResult GetSolicitudes(int userId, [FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña)
        {
            var selectedUser = _serviceContext.Set<Usuario>()
                .Where(u => u.Nombre_Usuario == userNombre_Usuario
                    && u.Contraseña == userContraseña
                    && u.IdRoll == 2)
                .FirstOrDefault();

            if (selectedUser != null)
            {
                var solicitudes = _serviceContext.Solicitud
                    .Where(s => s.IdUsuario == userId) 
                    .ToList();

                return Ok(solicitudes);
            }
            else
            {
                return Unauthorized("El usuario no está autorizado o no existe");
            }
        }

        [HttpDelete(Name = "DeleteSolicitud")]
        public IActionResult DeleteUser(int solicitudId, [FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña)
        {
            var seletedUser = _serviceContext.Set<Usuario>()
                               .Where(u => u.Nombre_Usuario == userNombre_Usuario
                                    && u.Contraseña == userContraseña
                                    && u.IdRoll == 2)
                                .FirstOrDefault();

            if (seletedUser != null)
            {
                var solicitud = _serviceContext.Solicitud.FirstOrDefault(p => p.Id_Solicitud == solicitudId);

                if (solicitud != null)
                {
                    _serviceContext.AuditLogs.Add(new AuditLog
                    {
                        Action = "Delete",
                        TableName = "Users",
                        Timestamp = DateTime.Now,
                        UserId = seletedUser.Id_Usuario
                    });

                    _serviceContext.Solicitud.Remove(solicitud);
                    _serviceContext.SaveChanges();

                    return Ok("La solicitud se ha eliminado correctamente.");
                }
                else
                {
                    return NotFound("No se ha encontrado el usuario con el identificador especificado.");
                }
            }
            else
            {
                return Unauthorized("El usuario no está autorizado o no existe");
            }
        }

    }
}
