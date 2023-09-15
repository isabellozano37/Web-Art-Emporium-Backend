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
    public class CompraControles : ControllerBase
    {
        private readonly IComprasServicio _comprasService;
        private readonly ServiceContext _serviceContext;

        public CompraControles(IComprasServicio compraService, ServiceContext serviceContext)
        {
            _comprasService = compraService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertCompras")]
        public int Post([FromQuery] string userNombre_Usuario, [FromQuery] string userContraseña, [FromBody] Compras compras)
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
                    TableName = "Compras",
                    Timestamp = DateTime.Now,
                    UserId = seletedUser.Id_Usuario
                });

                return _comprasService.InsertCompras(compras);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }

    }
}
