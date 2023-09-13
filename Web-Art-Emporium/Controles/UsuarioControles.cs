using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class UsuarioControles : ControllerBase
    {

        private readonly IUsuarioServicio _userService;
        private readonly ServiceContext _serviceContext;

        public UsuarioControles(IUsuarioServicio userService, ServiceContext serviceContext)
        {
            _userService = userService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertUsers")]
        public int Post([FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña, [FromBody] Usuario usuario)
        {
            var seletedUser = _serviceContext.Set<Usuario>()
                               .Where(u => u.Nombre_Usuario == userNombre_Usuario
                                    && u.Contraseña == userContraseña
                                    && u.IdRoll == 1)
                                .FirstOrDefault();
            if (seletedUser != null)
            {

                _serviceContext.AuditLogs.Add(new AuditLog
                {
                    Action = "Insert",
                    TableName = "Users",
                    Timestamp = DateTime.Now,
                    UserId = seletedUser.Id_Usuario
                });

                return _userService.InsertUsers(usuario);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }

        [HttpPut(Name = "UpdateUser")]
        public IActionResult UpdateUser(int userId, [FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña, [FromBody] Usuario updatedUser)
        {
            var seletedUser = _serviceContext.Set<Usuario>()
                               .Where(u => u.Nombre_Usuario == userNombre_Usuario
                                    && u.Contraseña == userContraseña
                                    && u.IdRoll == 1)
                                .FirstOrDefault();

            if (seletedUser != null)
            {
                var user = _serviceContext.Usuario.FirstOrDefault(p => p.Id_Usuario == userId);

                if (user != null)
                {
                    user.Nombre_Usuario = updatedUser.Nombre_Usuario;
                    user.Apellidos_Usuario = updatedUser.Apellidos_Usuario;
                    user.Direccion_Usuario = updatedUser.Direccion_Usuario;
                    user.Telefono = updatedUser.Telefono;
                    user.Email = updatedUser.Email;
                    user.Contraseña = updatedUser.Contraseña;
                    user.IdRoll = updatedUser.IdRoll;

                    _serviceContext.AuditLogs.Add(new AuditLog
                    {
                        Action = "Update",
                        TableName = "Users",
                        Timestamp = DateTime.Now,
                        UserId = seletedUser.Id_Usuario
                    });

                    _serviceContext.SaveChanges();

                    return Ok("El ususario se ha actualizado correctamente.");
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

        [HttpGet(Name = "GetUsers")]
        public IActionResult GetUsers([FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña)
        {
            var seletedUser = _serviceContext.Set<Usuario>()
                               .Where(u => u.Nombre_Usuario == userNombre_Usuario
                                    && u.Contraseña == userContraseña
                                    && u.IdRoll == 1)
                                .FirstOrDefault();

            if (seletedUser != null)
            {
                var users = _serviceContext.Usuario.ToList();

                return Ok(users);
            }
            else
            {
                return Unauthorized("El usuario no está autorizado o no existe");
            }
        }

        [HttpDelete(Name = "DeleteUser")]
        public IActionResult DeleteUser(int userId, [FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña)
        {
            var seletedUser = _serviceContext.Set<Usuario>()
                               .Where(u => u.Nombre_Usuario == userNombre_Usuario
                                    && u.Contraseña == userContraseña
                                    && u.IdRoll == 1)
                                .FirstOrDefault();

            if (seletedUser != null)
            {
                var user = _serviceContext.Usuario.FirstOrDefault(p => p.Id_Usuario == userId);

                if (user != null)
                {
                    _serviceContext.AuditLogs.Add(new AuditLog
                    {
                        Action = "Delete",
                        TableName = "Users",
                        Timestamp = DateTime.Now,
                        UserId = seletedUser.Id_Usuario
                    });

                    _serviceContext.Usuario.Remove(user);
                    _serviceContext.SaveChanges();

                    return Ok("El usuario se ha eliminado correctamente.");
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
