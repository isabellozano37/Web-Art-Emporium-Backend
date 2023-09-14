using Data;
using Entities.Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class ProductosServicio : BaseContextService, IProductosServicio
    {
        public ProductosServicio(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertProductos(Productos productos)
        {
            _serviceContext.Productos.Add(productos);
            _serviceContext.SaveChanges();
            return productos.IdProductos;
        }
    }
}