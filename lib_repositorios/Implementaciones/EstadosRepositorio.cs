using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Implementaciones
{
    public class EstadosRepositorio : IEstadosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio = null;

        public EstadosRepositorio(Conexion conexion, IAuditoriaRepositorio? iAuditoriaRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Estados> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Estados",
                Referencia = 0,
                Accion = "Listar"
            });
            return conexion!.Listar<Estados>();
        }

        public List<Estados> Buscar(Expression<Func<Estados, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Estados Guardar(Estados entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Estados",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            return entidad;
        }

        public Estados Modificar(Estados entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Estados",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Estados Borrar(Estados entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Estados",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}
