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
    public class PersGrupsAplicacion : IPersGrupsAplicacion //preguntar si asi se crea para estas clases 
    {
        private IPersGrupsRepositorio? iRepositorio = null;
   

        public PersGrupsAplicacion(IPersGrupsRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }



        public PersGrups Borrar(PersGrups entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public List<PersGrups> Buscar(PersGrups entidad, string tipo)
        {
            Expression<Func<PersGrups, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "GRUPO": condiciones = x => x.Grupo == entidad.Grupo; break;
                case "COMPLEJA":
                    condiciones =
                        x => x.Grupo == entidad.Grupo; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public PersGrups Guardar(PersGrups entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = EnvioA(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<PersGrups> Listar()
        {
            return iRepositorio!.Listar();
        }

        public PersGrups Modificar(PersGrups entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = EnvioA(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private PersGrups EnvioA(PersGrups entidad)
        {
            entidad.Grupo = entidad.Grupo; //se crea asi el metodo o como seria? y para las tablas referenciadas como seria?
            entidad.Persona = entidad.Persona;

            return entidad;
        }

    }
}
