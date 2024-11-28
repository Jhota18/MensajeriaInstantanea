using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IMensajesPresentacion
    {
        Task<List<Mensajes>> Listar();
        Task<List<Mensajes>> Buscar(Mensajes entidad, string tipo);
        Task<Mensajes> Guardar(Mensajes entidad);
        Task<Mensajes> Modificar(Mensajes entidad);
        Task<Mensajes> Borrar(Mensajes entidad);
    }
}