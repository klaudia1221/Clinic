namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recepta")]
    public partial class Recepta
    {
        public int ReceptaID { get; set; }

        public int PacjentID { get; set; }

        public int DoktorID { get; set; }

	    [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [StringLength(20)]
        public string Lek { get; set; }

        public decimal? Refundacja { get; set; }

        public bool? Status { get; set; }

        public virtual Doktor Doktor { get; set; }

        public virtual Pacjent Pacjent { get; set; }
    }
}
