using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Implementaciones
{
    public class GruposAplicacion : IGruposAplicacion
    {
        private IGruposRepositorio? iRepositorio = null;

        public GruposAplicacion(IGruposRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Grupos Borrar(Grupos entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public List<Grupos> Buscar(Grupos entidad, string tipo)
        {
            Expression<Func<Grupos, bool>>? condiciones = null;
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

        public Grupos Guardar(Grupos entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = CrearGrupo(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Grupos> Listar()
        {
            return iRepositorio!.Listar();
        }

        public Grupos Modificar(Grupos entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = CrearGrupo(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Grupos CrearGrupo(Grupos entidad)
        {
            entidad.Nombre = entidad.Nombre;

            return entidad;
        }

    }

}
