using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class GruposRepositorio : IGruposRepositorio
    {
        private Conexion? conexion = null;

        public GruposRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Grupos> Listar()
        {
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
            return entidad;
        }

        public Grupos Modificar(Grupos entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Grupos Borrar(Grupos entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}