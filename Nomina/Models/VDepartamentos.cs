using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomina.Models
{
    [MetadataType(typeof(VDepartamentos))]
    public partial class Departamento
    {
        class VDepartamentos
        {
    
            [Display(Name = "Nombre Departamento")]
            public string NombreDepartamento { get; set; }

            
            
        }
    }
}