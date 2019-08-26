using System;

namespace DA.Health.Model.Attributes
{
	/// <summary>
	/// Mappt eine Property zu einer Spalte in der Database
	/// </summary>
	public sealed class DbField : Attribute
	{
		public string DbFieldName { get; private set; }

		public DbField(string fieldName)
		{
			DbFieldName = fieldName;
		}
	}
}
