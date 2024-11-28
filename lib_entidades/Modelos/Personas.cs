using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{

    public class Personas 
    {
        [Key] public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Cedula) ||
                string.IsNullOrEmpty(Nombre) )
                return false;
            return true;
        }

    }
}