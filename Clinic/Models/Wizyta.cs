//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wizyta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wizyta()
        {
            this.Zuzycie_Lekow = new HashSet<Zuzycie_Lekow>();
        }
    
        public int WizytaID { get; set; }
        public int PacjentID { get; set; }
        public int DoktorID { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<System.TimeSpan> Godzina { get; set; }
        public string TypWizyty { get; set; }
        public Nullable<int> Wzrost { get; set; }
        public Nullable<decimal> Waga { get; set; }
        public Nullable<decimal> Temperatura { get; set; }
        public string CisnienieKrwi { get; set; }
        public string Objawy { get; set; }
        public string Diagnoza { get; set; }
    
        public virtual Doktor Doktor { get; set; }
        public virtual Pacjent Pacjent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zuzycie_Lekow> Zuzycie_Lekow { get; set; }
    }
}