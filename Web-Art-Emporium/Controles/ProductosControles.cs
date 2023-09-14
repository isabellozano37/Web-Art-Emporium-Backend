using Data;
using Entities;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosServicio _productoService;
        private readonly ServiceContext _serviceContext;

        public ProductosController(IProductosServicio productoService, ServiceContext serviceContext)
        {
            _productoService = productoService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "AceptarSolicitudYGuardarEnProductos")]
        public IActionResult AceptarSolicitudYGuardarEnProductos(int solicitudId, [FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña)
        {
            var selectedUser = _serviceContext.Set<Usuario>()
                .Where(u => u.Nombre_Usuario == userNombre_Usuario
                    && u.Contraseña == userContraseña
                    && u.IdRoll == 1)
                .FirstOrDefault();

            if (selectedUser != null)
            {
                var solicitud = _serviceContext.Solicitud.FirstOrDefault(p => p.Id_Solicitud == solicitudId);

                if (solicitud != null)
                {

                    _serviceContext.AuditLogs.Add(new AuditLog
                    {
                        Action = "Accept",
                        TableName = "Solicitud",
                        Timestamp = DateTime.Now,
                        UserId = selectedUser.Id_Usuario
                    });

                    
                    _productoService.InsertProductos(new Productos
                    {
                        Imagen = solicitud.Imagen,
                        Nombre = solicitud.Nombre,
                        Descripción = solicitud.Descripción,
                        Precio = solicitud.Precio,
                        Estado = solicitud.Estado,
                        IdSolicitud = solicitud.Id_Solicitud,
                        IdTipos = solicitud.IdTipos
                    });

                    //_serviceContext.Solicitud.Remove(solicitud);
                    

                    return Ok("La solicitud se ha aceptado y el producto se ha guardado correctamente en la tabla 'Productos'.");
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



        [HttpDelete(Name = "EliminarSolicitud")]
        public IActionResult EliminarSolicitud(int solicitudId, [FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña)
        {
            var selectedUser = _serviceContext.Set<Usuario>()
                .Where(u => u.Nombre_Usuario == userNombre_Usuario
                    && u.Contraseña == userContraseña
                    && u.IdRoll == 1)
                .FirstOrDefault();

            if (selectedUser != null)
            {
                var solicitud = _serviceContext.Solicitud.FirstOrDefault(s => s.Id_Solicitud == solicitudId);

                if (solicitud != null)
                {
                    _serviceContext.AuditLogs.Add(new AuditLog
                    {
                        Action = "Denegado",
                        TableName = "Solicitud",
                        Timestamp = DateTime.Now,
                        UserId = selectedUser.Id_Usuario
                    });

                    _serviceContext.Solicitud.Remove(solicitud);
                    _serviceContext.SaveChanges();

                    return Ok("La solicitud se ha eliminado correctamente.");
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

        [HttpGet]
        [Route("ProductosPorTipo/{tipoId}")]
        public IActionResult ProductosPorTipo(int tipoId)
        {
            // Realiza una consulta para obtener los productos por tipoId
            var productosPorTipo = _productoService.ObtenerProductosPorTipo(tipoId);

            if (productosPorTipo == null)
            {
                return NotFound("No se encontraron productos para este tipo.");
            }

            return Ok(productosPorTipo);
        }
    }
}


