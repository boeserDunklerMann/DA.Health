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
	}
}
