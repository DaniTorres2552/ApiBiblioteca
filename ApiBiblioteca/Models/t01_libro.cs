namespace ApiBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t01_libro
    {
        [Key]
        public int f01_rowid { get; set; }

        [Required]
        [StringLength(100)]
        public string f01_titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime f01_fecha { get; set; }

        [Required]
        [StringLength(50)]
        public string f01_genero { get; set; }

        public int? f01_num_paginas { get; set; }

        [Required]
        [StringLength(80)]
        public string f01_autor { get; set; }
    }
}
