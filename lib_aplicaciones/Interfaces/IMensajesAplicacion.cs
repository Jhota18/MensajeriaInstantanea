using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_aplicaciones.Interfaces
{
    public interface IMensajesAplicacion
    {
        void Configurar(string string_conexion);
        List<Mensajes> Listar();
        List<Mensajes> Buscar(Mensajes entidad, string tipo);
        Mensajes Guardar(Mensajes entidad);
        Mensajes Modificar(Mensajes entidad);
        Mensajes Borrar(Mensajes entidad);
    }
}
