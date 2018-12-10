namespace Clinic.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class KlinikaEntities : DbContext
	{
		public KlinikaEntities()
			: base("name=KlinikaEntities")
		{
		}

		public virtual DbSet<Doktor> Doktor { get; set; }
		public virtual DbSet<Historia_Pacjenta> Historia_Pacjenta { get; set; }
		public virtual DbSet<Leczenie> Leczenie { get; set; }
		public virtual DbSet<Pacjent> Pacjent { get; set; }
		public virtual DbSet<Recepta> Recepta { get; set; }
		public virtual DbSet<Skierowanie> Skierowanie { get; set; }
		public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
		public virtual DbSet<Ubezpieczenie_Pacjenta> Ubezpieczenie_Pacjenta { get; set; }
		public virtual DbSet<Wizyta> Wizyta { get; set; }
		public virtual DbSet<Zaopatrzenie> Zaopatrzenie { get; set; }
		public virtual DbSet<Zuzycie_Lekow> Zuzycie_Lekow { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Doktor>()
				.Property(e => e.Imie)
				.IsUnicode(false);

			modelBuilder.Entity<Doktor>()
				.Property(e => e.Nazwisko)
				.IsUnicode(false);

			modelBuilder.Entity<Doktor>()
				.Property(e => e.Adres)
				.IsUnicode(false);

			modelBuilder.Entity<Doktor>()
				.Property(e => e.NrTelefonu)
				.IsUnicode(false);

			modelBuilder.Entity<Doktor>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Doktor>()
				.Property(e => e.Specjalizacja)
				.IsUnicode(false);

			modelBuilder.Entity<Doktor>()
				.HasMany(e => e.Leczenie)
				.WithRequired(e => e.Doktor)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Doktor>()
				.HasMany(e => e.Recepta)
				.WithRequired(e => e.Doktor)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Doktor>()
				.HasMany(e => e.Skierowanie)
				.WithRequired(e => e.Doktor)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Doktor>()
				.HasMany(e => e.Wizyta)
				.WithRequired(e => e.Doktor)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Leczenie>()
				.Property(e => e.Opis)
				.IsUnicode(false);

			modelBuilder.Entity<Leczenie>()
				.Property(e => e.Rezultat)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.Imie)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.Nazwisko)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.StanCywilny)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.Plec)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.Adres)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.NrTelefonu)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Pacjent>()
				.Property(e => e.RowVersion)
				.IsFixedLength();

			modelBuilder.Entity<Pacjent>()
				.HasOptional(e => e.Historia_Pacjenta)
				.WithRequired(e => e.Pacjent);

			modelBuilder.Entity<Pacjent>()
				.HasMany(e => e.Leczenie)
				.WithRequired(e => e.Pacjent)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Pacjent>()
				.HasMany(e => e.Recepta)
				.WithRequired(e => e.Pacjent)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Pacjent>()
				.HasMany(e => e.Skierowanie)
				.WithRequired(e => e.Pacjent)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Pacjent>()
				.HasOptional(e => e.Ubezpieczenie_Pacjenta)
				.WithRequired(e => e.Pacjent);

			modelBuilder.Entity<Pacjent>()
				.HasMany(e => e.Wizyta)
				.WithRequired(e => e.Pacjent)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Recepta>()
				.Property(e => e.Lek)
				.IsUnicode(false);

			modelBuilder.Entity<Recepta>()
				.Property(e => e.Refundacja)
				.HasPrecision(3, 2);

			modelBuilder.Entity<Skierowanie>()
				.Property(e => e.Informacja)
				.IsUnicode(false);

			modelBuilder.Entity<Ubezpieczenie_Pacjenta>()
				.Property(e => e.Zawod)
				.IsUnicode(false);

			modelBuilder.Entity<Ubezpieczenie_Pacjenta>()
				.Property(e => e.Pracodawca)
				.IsUnicode(false);

			modelBuilder.Entity<Ubezpieczenie_Pacjenta>()
				.Property(e => e.AdresPracodawcy)
				.IsUnicode(false);

			modelBuilder.Entity<Ubezpieczenie_Pacjenta>()
				.Property(e => e.NrTelefonuPracodawcy)
				.IsUnicode(false);

			modelBuilder.Entity<Ubezpieczenie_Pacjenta>()
				.Property(e => e.StatusUbezpieczenia)
				.IsUnicode(false);

			modelBuilder.Entity<Wizyta>()
				.Property(e => e.TypWizyty)
				.IsUnicode(false);

			modelBuilder.Entity<Wizyta>()
				.Property(e => e.Waga)
				.HasPrecision(5, 2);

			modelBuilder.Entity<Wizyta>()
				.Property(e => e.Temperatura)
				.HasPrecision(3, 1);

			modelBuilder.Entity<Wizyta>()
				.Property(e => e.CisnienieKrwi)
				.IsUnicode(false);

			modelBuilder.Entity<Wizyta>()
				.Property(e => e.Objawy)
				.IsUnicode(false);

			modelBuilder.Entity<Wizyta>()
				.Property(e => e.Diagnoza)
				.IsUnicode(false);

			modelBuilder.Entity<Wizyta>()
				.HasMany(e => e.Zuzycie_Lekow)
				.WithRequired(e => e.Wizyta)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zaopatrzenie>()
				.Property(e => e.Nazwa)
				.IsUnicode(false);

			modelBuilder.Entity<Zaopatrzenie>()
				.Property(e => e.Opis)
				.IsUnicode(false);

			modelBuilder.Entity<Zaopatrzenie>()
				.Property(e => e.Cena)
				.HasPrecision(6, 2);

			modelBuilder.Entity<Zaopatrzenie>()
				.HasMany(e => e.Zuzycie_Lekow)
				.WithRequired(e => e.Zaopatrzenie)
				.WillCascadeOnDelete(false);
		}
	}
}
