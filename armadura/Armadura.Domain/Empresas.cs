

namespace Armadura.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Empresas
    {
        [Key]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido (campo {0})")]
        [MaxLength(50,ErrorMessage ="El Nombre de la empresa no puede superar los 50 caracteres (Campo {1})")]
        [Index("Empresas_Nombre_Index",IsUnique =true)]
        public string Nombre { get; set; }
        [JsonIgnore]
        public virtual ICollection<Clave> Claves { get; set; }
    }
}
