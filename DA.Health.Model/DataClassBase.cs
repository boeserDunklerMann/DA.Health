using DA.Health.Model.Attributes;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DA.Health.Model
{
	public class DataClassBase
	{
		public virtual int ID { get; set; }
		public bool IsNew => ID == 0;
		public virtual bool DeleteMe { get; set; } = false;
		public virtual void FromDataRow(DataRow row)
		{
			Type myType = this.GetType();
			PropertyInfo[] properties = myType.GetProperties();
			properties.ToList().ForEach(pi =>
			{
				string colName = pi.Name;
				Attribute a = pi.GetCustomAttribute(typeof(DbField));
				Attribute omitDb = pi.GetCustomAttribute(typeof(OmitDbAttribute));
				if ((null != a) && (null == omitDb))
					colName = ((DbField)a).DbFieldName;

				if (row.Table.Columns.Contains(colName) && row[colName] != DBNull.Value)
					pi.SetValue(this, row[colName]);
			});
		}
	}
}
