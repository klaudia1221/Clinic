namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pacjent")]
    public partial class Pacjent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacjent()
        {
            Leczenie = new HashSet<Leczenie>();
            Recepta = new HashSet<Recepta>();
            Skierowanie = new HashSet<Skierowanie>();
            Wizyta = new HashSet<Wizyta>();
        }

        public int PacjentID { get; set; }

	    [Required]
		[StringLength(20)]
        public string Imie { get; set; }

	    [Required]
		[StringLength(20)]
        public string Nazwisko { get; set; }

        [StringLength(20)]
        public string StanCywilny { get; set; }

	    [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Column(TypeName = "date")]
        public DateTime? DataUrodzenia { get; set; }

	    [RegularExpression("[MK]",
		    ErrorMessage = "Poprawne wartoœci: M, K")]
		[StringLength(1)]
        public string Plec { get; set; }

        [StringLength(20)]
        public string Adres { get; set; }

	    [RegularExpression("[0-9]{9}",
		    ErrorMessage = "Podaj poprawny numer telefonu, sk³adaj¹cy siê z 9 cyfr")]
		[StringLength(9)]
        public string NrTelefonu { get; set; }

	    [EmailAddress(ErrorMessage = "Podaj poprawny adres email")]
		[StringLength(20)]
        public string Email { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
		public byte[] RowVersion { get; set; }

        public virtual Historia_Pacjenta Historia_Pacjenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leczenie> Leczenie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recepta> Recepta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skierowanie> Skierowanie { get; set; }

        public virtual Ubezpieczenie_Pacjenta Ubezpieczenie_Pacjenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wizyta> Wizyta { get; set; }
    }
}
