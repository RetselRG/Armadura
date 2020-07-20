


namespace Armadura.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;

    public class Clave
    {
        [Key]
        public int IdClave { get; set; }

        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El Campo {0} solo puede tener {1} caracteres")]
        [Index("Clave_Contrasena_Index", IsUnique = true)]
        public string Contrasena { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaExpira { get; set; }
        [JsonIgnore]
        public virtual Empresas Empresa { get; set; }



    }
}
