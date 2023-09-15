using Data;
using Entities;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Web.Http.Cors;
using Web_Art_Emporium.IServicios;
using WebApplication1.IServices;

namespace Web_Art_Emporium.Controles
{    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class DetalleCompraControles : ControllerBase
    {
        private readonly IDetalleCompraServicio _DetallecomprasService;
        private readonly ServiceContext _serviceContext;

        public DetalleCompraControles(IDetalleCompraServicio detalleCompraService, ServiceContext serviceContext)
        {
            _DetallecomprasService = detalleCompraService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertDetalleCompras")]
        public int Post([FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña, [FromBody] DetallesCompras Detallecompras)
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
                    TableName = "DetalleCompras",
                    Timestamp = DateTime.Now,
                    UserId = seletedUser.Id_Usuario
                });

                return _DetallecomprasService.InsertDetalleCompra(Detallecompras);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }

    }
}
