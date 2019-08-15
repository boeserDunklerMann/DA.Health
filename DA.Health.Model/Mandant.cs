using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.Model
{
	public sealed class Mandant : DataClassBase
	{
		public Mandant Parent { get; set; }
		[DbField("Des")]
		public string Des { get; set; }
		public byte[] SecurityToken { get; set; }
		public DateTime ChangeDate { get; set; }
		[DbField("MandantID")]
		public override int ID { get; set; }
		public override string ToString()
		{
			return Des;
		}
	}
}
