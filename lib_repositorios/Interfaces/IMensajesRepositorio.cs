using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IMensajesRepositorio
    {
        void Configurar(string string_conexion);
        List<Mensajes> Listar();
        List<Mensajes> Buscar(Expression<Func<Mensajes, bool>> condiciones);
        Mensajes Guardar(Mensajes entidad);
        Mensajes Modificar(Mensajes entidad);
        Mensajes Borrar(Mensajes entidad);
    }
}
