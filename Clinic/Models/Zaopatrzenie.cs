namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zaopatrzenie")]
    public partial class Zaopatrzenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zaopatrzenie()
        {
            Zuzycie_Lekow = new HashSet<Zuzycie_Lekow>();
        }

        public int ZaopatrzenieID { get; set; }

        [StringLength(20)]
        public string Nazwa { get; set; }

        [StringLength(40)]
        public string Opis { get; set; }

        public decimal Cena { get; set; }

        public int? Dostepnosc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zuzycie_Lekow> Zuzycie_Lekow { get; set; }
    }
}
