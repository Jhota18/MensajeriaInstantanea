using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Detalles
    {
        [Key] public int Id { get; set; }
        public int Mensaje { get; set; }
        public int Para { get; set; }
        public int Estado { get; set; }

        [NotMapped] public Personas? _Persona { get; set; }
        [NotMapped] public Estados? _Estado { get; set; }
        [NotMapped] public Mensajes? _Mensaje { get; set; }

        public bool Validar()
        {
            if (Mensaje < 1 ||
                Para < 1 ||
                Estado < 1 || Estado > 2)
                return false;
            return true;
        }
    }
}
