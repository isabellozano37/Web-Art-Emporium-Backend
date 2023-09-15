using Data;
using Entities;
using Entities.Entities;
using Web_Art_Emporium.IServicios;
using WebApplication1.Services;

namespace Web_Art_Emporium.Servicios
{
    public class DetalleCompraServicio : BaseContextService, IDetalleCompraServicio
    {
        public DetalleCompraServicio(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertDetalleCompra(DetallesCompras detalleCompras)
        {
            _serviceContext.DetallesCompras.Add(detalleCompras);
            _serviceContext.SaveChanges();
            return detalleCompras.Id_DetallesCompras;
        }
    }
}
