using System;

namespace DA.Health.Model
{
	public sealed class Setting : DataClassBase
	{
		[DbField("SettingsID")]
		public override int ID { get => base.ID; set => base.ID = value; }
		public string SetingsValue { get; set; }
		public DateTime ChangeDate { get; set; }
		public Mandant Mandant { get; set; }
		public override bool Equals(object obj)
		{
			if (obj is Setting)
				return ((Setting)obj).ID == ID && ((Setting)obj).Mandant.Equals(Mandant);
			return false;
		}
		public override int GetHashCode()
		{
			unchecked // only needed if you're compiling with arithmetic checks enabled
			{ // (the default compiler behaviour is *disabled*, so most folks won't need this)
				int hash = 13;
				hash = (hash * 7) + ID.GetHashCode();
				hash = (hash * 7) + Mandant.ID.GetHashCode();
			    return hash;
			}
		}
		public new bool IsNew { get; set; }
	}
}
