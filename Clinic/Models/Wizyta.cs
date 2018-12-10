namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wizyta")]
    public partial class Wizyta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wizyta()
        {
            Zuzycie_Lekow = new HashSet<Zuzycie_Lekow>();
        }

        public int WizytaID { get; set; }

        public int PacjentID { get; set; }

        public int DoktorID { get; set; }

	    [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        public TimeSpan? Godzina { get; set; }

        [StringLength(10)]
        public string TypWizyty { get; set; }

        public int? Wzrost { get; set; }

        public decimal? Waga { get; set; }

        public decimal? Temperatura { get; set; }

        [StringLength(7)]
        public string CisnienieKrwi { get; set; }

        [StringLength(40)]
        public string Objawy { get; set; }

        [StringLength(40)]
        public string Diagnoza { get; set; }

        public virtual Doktor Doktor { get; set; }

        public virtual Pacjent Pacjent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zuzycie_Lekow> Zuzycie_Lekow { get; set; }
    }
}
