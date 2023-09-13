using Data;
using Entities;
using Entities.Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class SolicitudesServicio : BaseContextService, ISolicitudesServicio
    {
        public SolicitudesServicio(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertSolicitudes(Solicitud solicitud)
        {
            _serviceContext.Solicitud.Add(solicitud);
            _serviceContext.SaveChanges();
            return solicitud.Id_Solicitud;
        }
    }
}