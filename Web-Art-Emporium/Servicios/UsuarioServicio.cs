using Data;
using Entities.Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class UsuarioServicio : BaseContextService, IUsuarioServicio
    {
        public UsuarioServicio(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertUsers(Usuario usuario)
        {
            _serviceContext.Usuario.Add(usuario);
            _serviceContext.SaveChanges();
            return usuario.Id_Usuario;
        }
    }
}