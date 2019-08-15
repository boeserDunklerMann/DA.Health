using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.Model
{
    public sealed class GewichtMesswert : DataClassBase
    {
		public Mandant Mandant { get; set; }
		public DateTime Datum { get; set; }
		[DbField("Wert")]
		public decimal Value { get; set; }
		public string Bemerkung { get; set; }
	}
}
