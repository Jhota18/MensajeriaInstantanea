using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IGruposPresentacion
    {
        Task<List<Grupos>> Listar();
        Task<List<Grupos>> Buscar(Grupos entidad, string tipo);
        Task<Grupos> Guardar(Grupos entidad);
        Task<Grupos> Modificar(Grupos entidad);
        Task<Grupos> Borrar(Grupos entidad);
    }
}