namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ubezpieczenie_Pacjenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PacjentID { get; set; }

        [StringLength(20)]
        public string Zawod { get; set; }

        [StringLength(20)]
        public string Pracodawca { get; set; }

        [StringLength(20)]
        public string AdresPracodawcy { get; set; }

        [StringLength(9)]
        public string NrTelefonuPracodawcy { get; set; }

        [StringLength(10)]
        public string StatusUbezpieczenia { get; set; }

        public int? NrUbezpieczenia { get; set; }

	    [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Column(TypeName = "date")]
        public DateTime DataWaznosci { get; set; }

        public virtual Pacjent Pacjent { get; set; }
    }
}
