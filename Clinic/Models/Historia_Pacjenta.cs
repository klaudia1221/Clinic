namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Historia_Pacjenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PacjentID { get; set; }

        public bool? Odra { get; set; }

        public bool? Swinka { get; set; }

        public bool? Rozyczka { get; set; }

        public virtual Pacjent Pacjent { get; set; }
    }
}
