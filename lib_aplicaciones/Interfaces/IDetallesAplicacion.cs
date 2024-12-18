﻿using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_aplicaciones.Interfaces
{
    public interface IDetallesAplicacion
    {
        void Configurar(string string_conexion);
        List<Detalles> Listar();
        List<Detalles> Buscar(Detalles entidad, string tipo);
        Detalles Guardar(Detalles entidad);
        Detalles Modificar(Detalles entidad);
        Detalles Borrar(Detalles entidad);
    }
}
