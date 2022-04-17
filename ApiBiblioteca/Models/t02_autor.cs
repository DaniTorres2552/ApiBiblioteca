namespace ApiBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t02_autor
    {
        [Key]
        public int f02_rowid { get; set; }

        [Required]
        [StringLength(80)]
        public string f02_nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime f02_fecha_nacimiento { get; set; }

        [StringLength(50)]
        public string f02_ciudad { get; set; }

        [StringLength(50)]
        public string f02_correo { get; set; }
    }
}
