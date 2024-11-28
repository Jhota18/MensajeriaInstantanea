using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IPersGrupsPresentacion
    {
        Task<List<PersGrups>> Listar();
        Task<List<PersGrups>> Buscar(PersGrups entidad, string tipo);
        Task<PersGrups> Guardar(PersGrups entidad);
        Task<PersGrups> Modificar(PersGrups entidad);
        Task<PersGrups> Borrar(PersGrups entidad);
    }
}