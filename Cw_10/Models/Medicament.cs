﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw_10.Models
{
    public class Medicament
    {
		public Medicament()
		{
			Prescription_Medicaments = new HashSet<Prescription_Medicament>();
		}
		public int IdMedicament { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }

		public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
	}
}
