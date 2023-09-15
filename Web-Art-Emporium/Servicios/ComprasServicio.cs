using Data;
using Entities.Entities;
using Web_Art_Emporium.IServicios;
using WebApplication1.Services;

namespace Web_Art_Emporium.Servicios
{
    public class ComprasServicio : BaseContextService, IComprasServicio
    {
        public ComprasServicio(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertCompras(Compras compras)
        {
            _serviceContext.Compras.Add(compras);
            _serviceContext.SaveChanges();
            return compras.Id_Compras;
        }
    }
}
