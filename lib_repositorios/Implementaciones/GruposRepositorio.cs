using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class GruposRepositorio : IGruposRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio = null;

        public GruposRepositorio(Conexion conexion, IAuditoriaRepositorio? iAuditoriaRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Grupos> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Grupos",
                Referencia = 0,
                Accion = "Listar"
            });
            return conexion!.Listar<Grupos>();
        }

        public List<Grupos> Buscar(Expression<Func<Grupos, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Grupos Guardar(Grupos entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Grupos",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            return entidad;
        }

        public Grupos Modificar(Grupos entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Grupos",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Grupos Borrar(Grupos entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Grupos",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}