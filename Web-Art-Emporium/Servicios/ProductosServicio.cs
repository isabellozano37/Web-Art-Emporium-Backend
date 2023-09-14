using Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Productos> ObtenerProductosPorTipo(int tipoId)
        {
            // Realiza la consulta para obtener productos por tipoId
            var productosPorTipo = _serviceContext.Productos
                .Where(p => p.IdTipos == tipoId)
                .ToList();

            return productosPorTipo;
        }
    }
}