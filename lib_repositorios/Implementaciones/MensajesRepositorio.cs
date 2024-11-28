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
    public class MensajesRepositorio : IMensajesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio = null;

        public MensajesRepositorio(Conexion conexion, IAuditoriaRepositorio? iAuditoriaRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Mensajes> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Mensajes",
                Referencia = 0,
                Accion = "Listar"
            });
            return conexion!.Listar<Mensajes>();
        }

        public List<Mensajes> Buscar(Expression<Func<Mensajes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Mensajes Guardar(Mensajes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Mensajes",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            return entidad;
        }

        public Mensajes Modificar(Mensajes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Mensajes",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Mensajes Borrar(Mensajes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Mensajes",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}
