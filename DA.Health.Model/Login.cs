using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Health.Model.Attributes;

namespace DA.Health.Model
{
	public sealed class Login : DataClassBase
	{
		[DbField("LoginID")]
		public override int ID { get => base.ID; set => base.ID = value; }
		public string Username { get; set; }
		public byte[] Password { get; set; }
		public DateTime ChangeDate { get; set; }
		public Mandant Mandant { get; set; }
		/// <summary>
		/// Wurde das Login mit den Credentials validiert?
		/// </summary>
		[OmitDb()]
		public bool Validated { get; set; }
		/// <summary>
		/// Ist der User der Entwickler?
		/// </summary>
		[OmitDb()]
		public bool IsDevLogin { get { return Username.ToLower() == "dunkelan"; } }
	}
}
