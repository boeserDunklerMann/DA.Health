using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.Model
{
	/// <summary>
	/// Mappt eine Property zu einer Spalte in der Database
	/// </summary>
	public class DbField : Attribute
	{
		public string DbFieldName { get; private set; }

		public DbField(string fieldName)
		{
			DbFieldName = fieldName;
		}
	}
}
