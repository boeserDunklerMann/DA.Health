using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
				if (null != a)
					colName = ((DbField)a).DbFieldName;

				if (row.Table.Columns.Contains(colName) && row[colName] != DBNull.Value)
					pi.SetValue(this, row[colName]);
			});
		}
	}
}
