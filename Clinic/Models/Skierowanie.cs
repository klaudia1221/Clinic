namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skierowanie")]
    public partial class Skierowanie
    {
        public int SkierowanieID { get; set; }

        public int PacjentID { get; set; }

        public int DoktorID { get; set; }

        [StringLength(20)]
        public string Informacja { get; set; }

        public virtual Doktor Doktor { get; set; }

        public virtual Pacjent Pacjent { get; set; }
    }
}
