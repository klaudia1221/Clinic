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
    
    public partial class Skierowanie
    {
        public int SkierowanieID { get; set; }
        public int PacjentID { get; set; }
        public int DotkorID { get; set; }
        public string Informacja { get; set; }
    
        public virtual Doktor Doktor { get; set; }
        public virtual Pacjent Pacjent { get; set; }
    }
}
