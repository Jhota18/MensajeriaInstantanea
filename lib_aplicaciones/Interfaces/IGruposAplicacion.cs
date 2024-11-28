using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_aplicaciones.Interfaces
{
    public interface IGruposAplicacion 
    {
        void Configurar(string string_conexion);
        List<Grupos> Listar();
        List<Grupos> Buscar(Grupos entidad, string tipo);
        Grupos Guardar(Grupos entidad);
        Grupos Modificar(Grupos entidad);
        Grupos Borrar(Grupos entidad);
    }
}
