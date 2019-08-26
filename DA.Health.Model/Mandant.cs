using DA.Health.Model.Attributes;
using System;

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
		public override bool Equals(object obj)
		{
			if (obj is Mandant)
				return ((Mandant)obj).ID == ID;
			return false;
		}
		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}
	}
}
