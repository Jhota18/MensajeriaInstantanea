using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_aplicaciones.Interfaces
{
    public interface IPersGrupsAplicacion
    {
        void Configurar(string string_conexion);
        List<PersGrups> Listar();
        List<PersGrups> Buscar(PersGrups entidad, string tipo);
        PersGrups Guardar(PersGrups entidad);
        PersGrups Modificar(PersGrups entidad);
        PersGrups Borrar(PersGrups entidad);
    }
}
