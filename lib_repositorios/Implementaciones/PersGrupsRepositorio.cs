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
    public class PersGrupsRepositorio : IPersGrupsRepositorio
    {
        private Conexion? conexion = null;

        public PersGrupsRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<PersGrups> Listar()
        {
            return conexion!.Listar<PersGrups>();
        }

        public List<PersGrups> Buscar(Expression<Func<PersGrups, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public PersGrups Guardar(PersGrups entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public PersGrups Modificar(PersGrups entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public PersGrups Borrar(PersGrups entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}
