using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IPersGrupsRepositorio
    {
        void Configurar(string string_conexion);
        List<PersGrups> Listar();
        List<PersGrups> Buscar(Expression<Func<PersGrups, bool>> condiciones);
        PersGrups Guardar(PersGrups entidad);
        PersGrups Modificar(PersGrups entidad);
        PersGrups Borrar(PersGrups entidad);
    }
}
