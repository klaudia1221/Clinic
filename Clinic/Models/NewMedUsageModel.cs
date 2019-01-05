using System.Collections.Generic;
using System.Linq;

namespace Clinic.Models
{
	public class NewMedUsageModel
	{
		public IEnumerable<Zuzycie_Lekow> MedUsage { get; set; }
		public int? Id { get; set; }
	}
}