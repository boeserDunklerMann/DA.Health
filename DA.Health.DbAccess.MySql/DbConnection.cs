using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.DbAccess.MySql
{
	class DbConnection
	{
		private static bool _initialised = false;
		private readonly static iS.MySql.SqlCon _con;
		public iS.MySql.SqlCon Connection
		{
			get { return _con; }
		}

		static DbConnection()
		{
			_con = iS.MySql.SqlCon.Instance;
		}
		public void Init(string connectionString)
		{
			if (!_initialised)
			{
				_con.InitDbConnection(connectionString);
				_initialised = true;
			}
		}
	}
}
