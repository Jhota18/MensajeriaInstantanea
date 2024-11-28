using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class DetallesAplicacion : IDetallesAplicacion
    {
        private IDetallesRepositorio? iRepositorio = null;

        public DetallesAplicacion(IDetallesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }
        public Detalles Borrar(Detalles entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public List<Detalles> Buscar(Detalles entidad, string tipo)
        {
            Expression<Func<Detalles, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "MENSAJE": condiciones = x => x.Mensaje == entidad.Mensaje;  break;
                case "COMPLEJA":
                    condiciones =
                        x => x.Mensaje == entidad.Mensaje; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Detalles Guardar(Detalles entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = InfoMensaje(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Detalles> Listar()
        {
            return iRepositorio!.Listar();
        }

        public Detalles Modificar(Detalles entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = InfoMensaje(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Detalles InfoMensaje(Detalles entidad)
        {
            entidad.Mensaje = entidad.Mensaje; //se crea asi el metodo o como seria? y para las tablas referenciadas como seria?
            entidad.Para = entidad.Para;
            entidad.Estado = entidad.Estado;

            return entidad;
        }

    }
}
