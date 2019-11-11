using System.ComponentModel.DataAnnotations;

namespace Nomina.Models
{
    [MetadataType(typeof(VNomina))]
    public partial class Nomina
    {
        class VNomina
        {
            [Display(Name = "Empleado")]
            [Required(ErrorMessage = "La nomina es requerido")]
            public int EmpleadoID { get; set; }
            [Display(Name = "Días trabajados")]
            public int DiasTrabajados { get; set; }
            [Display(Name = "Sueldo por Día ")]
            public int SueldoPorDia { get; set; }
            [Display(Name = "Sueldo quincenal ")]
            public int SueldoQuincenal { get; set; }

        }
    }
}