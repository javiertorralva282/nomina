using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomina.Models
{
    [MetadataType(typeof(VEmpleado))]

    public partial class Empleado
    {
        class VEmpleado
        {
            public int EmpleadoID { get; set; }
            [Display(Name = "Nombre Empleado")]
            public string NombreEmpleado { get; set; }
            public Nullable<int> DepartamentoID { get; set; }
            [Display(Name = "Estatus de empleados")]
            public string Estatus { get; set; }
            [Display(Name = "Sueldo del empleado")]
            public Nullable<int> Sueldo { get; set; }
        }
    }
}