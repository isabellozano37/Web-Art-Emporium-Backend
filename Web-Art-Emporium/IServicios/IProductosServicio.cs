using Entities.Entities;

namespace WebApplication1.IServices
{
    public interface IProductosServicio
    {     
        int InsertProductos(Productos productos);
        List<Productos> ObtenerProductosPorTipo(int tipoId);
    }
}
