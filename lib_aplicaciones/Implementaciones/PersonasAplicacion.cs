using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;


namespace lib_aplicaciones.Implementaciones
{
    public class PersonasAplicacion : IPersonasAplicacion
    {
        private IPersonasRepositorio? iRepositorio = null;

        public PersonasAplicacion(IPersonasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Personas Borrar(Personas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public List<Personas> Buscar(Personas entidad, string tipo)
        {
            Expression<Func<Personas, bool>>? condiciones = null;
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

        public Personas Guardar(Personas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = InsertarPersona(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Personas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public Personas Modificar(Personas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = InsertarPersona(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Personas InsertarPersona(Personas entidad)
        {
            entidad.Cedula = entidad.Cedula; //se crea asi el metodo o como seria? y para las tablas referenciadas como seria?
            entidad.Nombre = entidad.Nombre;


            return entidad;
        }

    }
}
