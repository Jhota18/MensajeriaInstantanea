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

        public MensajesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Mensajes> Listar()
        {
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
            return entidad;
        }

        public Mensajes Modificar(Mensajes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Mensajes Borrar(Mensajes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}
