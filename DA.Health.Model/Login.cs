using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
