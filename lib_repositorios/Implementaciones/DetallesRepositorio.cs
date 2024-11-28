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
    public class DetallesRepositorio : IDetallesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio = null;

        public DetallesRepositorio(Conexion conexion, IAuditoriaRepositorio iAuditoriaRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Detalles> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Detalles",
                Referencia = 0,
                Accion = "Listar"
            });
            return conexion!.Listar<Detalles>();
        }

        public List<Detalles> Buscar(Expression<Func<Detalles, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Detalles Guardar(Detalles entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Detalles",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            return entidad;
        }

        public Detalles Modificar(Detalles entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Detalles",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Detalles Borrar(Detalles entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Detalles",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}
