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
    public class MensajesAplicacion : IMensajesAplicacion   //totalmente incompleto
    {
        private IMensajesRepositorio? iRepositorio = null;

        public MensajesAplicacion(IMensajesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Mensajes Borrar(Mensajes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public List<Mensajes> Buscar(Mensajes entidad, string tipo)
        {
            Expression<Func<Mensajes, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "CONTENIDO": condiciones = x => x.Contenido!.Contains(entidad.Contenido!); break;
                case "COMPLEJA":
                    condiciones =
                        x => x.Contenido!.Contains(entidad.Contenido!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Mensajes Guardar(Mensajes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = MEnviado(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Mensajes> Listar()
        {
            return iRepositorio!.Listar();
        }

        public Mensajes Modificar(Mensajes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

           entidad = MEnviado(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Mensajes MEnviado(Mensajes entidad)
        {
            entidad.Contenido = entidad.Contenido; //se crea asi el metodo o como seria? y para las tablas referenciadas como seria?
            entidad.Fecha = entidad.Fecha;
            entidad.Estado = entidad.Estado;
            entidad.Borrado = entidad.Borrado;
            entidad.De = entidad.De;
            entidad.Para = entidad.Para;
            entidad.Grupo = entidad.Grupo;

            return entidad;
        }

    }
}
