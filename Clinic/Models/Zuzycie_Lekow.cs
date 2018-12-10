namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Zuzycie_Lekow
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WizytaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZaopatrzenieID { get; set; }

        public int? Ilosc { get; set; }

        public virtual Wizyta Wizyta { get; set; }

        public virtual Zaopatrzenie Zaopatrzenie { get; set; }
    }
}
