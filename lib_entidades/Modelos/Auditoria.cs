using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{

    public class Auditoria 
    {
        [Key] public int Id { get; set; }
        public string? Tabla { get; set; }
        public int Referencia { get; set; }
        public string? Accion { get; set; }
        
    }
}