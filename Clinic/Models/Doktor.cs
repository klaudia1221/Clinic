namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doktor")]
    public partial class Doktor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doktor()
        {
            Leczenie = new HashSet<Leczenie>();
            Recepta = new HashSet<Recepta>();
            Skierowanie = new HashSet<Skierowanie>();
            Wizyta = new HashSet<Wizyta>();
        }

        public int DoktorID { get; set; }

        [StringLength(20)]
        public string Imie { get; set; }

        [StringLength(20)]
        public string Nazwisko { get; set; }

	    [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Column(TypeName = "date")]
        public DateTime? DataUrodzenia { get; set; }

        [StringLength(50)]
        public string Adres { get; set; }

        [StringLength(9)]
        public string NrTelefonu { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Specjalizacja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leczenie> Leczenie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recepta> Recepta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skierowanie> Skierowanie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wizyta> Wizyta { get; set; }
    }
}
