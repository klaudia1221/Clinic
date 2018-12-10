namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Leczenie")]
    public partial class Leczenie
    {
        public int LeczenieID { get; set; }

        public int PacjentID { get; set; }

        public int DoktorID { get; set; }

	    [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [StringLength(20)]
        public string Opis { get; set; }

        [StringLength(20)]
        public string Rezultat { get; set; }

        public virtual Doktor Doktor { get; set; }

        public virtual Pacjent Pacjent { get; set; }
    }
}
