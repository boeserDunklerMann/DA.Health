using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.Model.Attributes
{
	/// <summary>
	/// Damit wird eine Property im Model markiert, die nicht in der DB serialisiert werden soll (weil sie z.B. berechnet wird).
	/// </summary>
	public class OmitDbAttribute : Attribute
	{
		public OmitDbAttribute()
		{
		}
	}
}
