using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosAplicacion
    {
        void Configurar(string string_conexion);
        List<Estados> Listar();
        List<Estados> Buscar(Estados entidad, string tipo);
        Estados Guardar(Estados entidad);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
    }
}
