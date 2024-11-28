using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class EstadosAplicacion : IEstadosAplicacion
    {
        private IEstadosRepositorio? iRepositorio = null;

        public EstadosAplicacion(IEstadosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Estados Borrar(Estados entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public List<Estados> Buscar(Estados entidad, string tipo)
        {
            Expression<Func<Estados, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;               
                case "COMPLEJA":
                    condiciones =
                        x => x.Nombre!.Contains(entidad.Nombre!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Estados Guardar(Estados entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = ConsultarEstado(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Estados> Listar()
        {
            return iRepositorio!.Listar();
        }

        public Estados Modificar(Estados entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = ConsultarEstado(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Estados ConsultarEstado(Estados entidad)
        {
            entidad.Nombre = entidad.Nombre;

            return entidad;
        }

    }
}
