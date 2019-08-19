using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Health.Model;
using MySql.Data.MySqlClient;

namespace DA.Health.DbAccess.MySql
{
	public class DbaMySql : Contracts.Data.IDbAccessor
	{
		private const string CONNECTION_STRING = "Server=meereen;Database=Health;Uid=health;Pwd=gesundheit;";
		private readonly iS.MySql.SqlCon _con;

		public DbaMySql()
		{
			_con = iS.MySql.SqlCon.Instance;
			_con.InitDbConnection(CONNECTION_STRING);
		}

		#region Gewicht
		public List<GewichtMesswert> LoadGewicht(Mandant mandant)
		{
			DataTable tbl = _con.GetData("CALL sp_GetGewichts(?mid)", new MySqlParameter("?mid", mandant.ID));
			List<GewichtMesswert> gewichts = new List<GewichtMesswert>();
			foreach (DataRow row in tbl.Rows)
			{
				GewichtMesswert g = new GewichtMesswert();
				g.FromDataRow(row);
				g.Mandant = LoadMandant((int)row["MandantID"]);
				gewichts.Add(g);
			}
			return gewichts;
		}

		public void SetGewicht(GewichtMesswert gewicht)
		{
			if (gewicht.DeleteMe)
			{
				DeleteGewicht(gewicht);
				return;
			}
			if (gewicht.IsNew)
			{
				object id = _con.LookUp("CALL sp_InsertGewicht(?datum, ?wert, ?bemerkung, ?mid)",
					new MySqlParameter("?datum", gewicht.Datum),
					new MySqlParameter("?wert", gewicht.Value),
					new MySqlParameter("?bemerkung", gewicht.Bemerkung),
					new MySqlParameter("?mid", gewicht.Mandant.ID));
				gewicht.ID = Convert.ToInt32(id);
			}
			else
			{
				_con.ExecuteQuery("CALL sp_UpdateGewicht(?datum, ?wert, ?bemerkung, ?mid, ?gid)",
					new MySqlParameter("?datum", gewicht.Datum),
					new MySqlParameter("?wert", gewicht.Value),
					new MySqlParameter("?bemerkung", gewicht.Bemerkung),
					new MySqlParameter("?mid", gewicht.Mandant.ID),
					new MySqlParameter("?gid", gewicht.ID));
			}
		}

		private void DeleteGewicht(Model.GewichtMesswert gewicht)
		{
			_con.ExecuteQuery("CALL sp_DeleteGewicht(?gid)", new MySqlParameter("?gid", gewicht.ID));
		}
		#endregion

		#region Mandant
		public Mandant LoadMandant(int mandantID)
		{
			DataTable tbl = _con.GetData("CALL sp_GetMandant(?mid)", new MySqlParameter("?mid", mandantID));
			if (tbl.Rows.Count != 1)
				throw new ApplicationException("zu viele oder kein Mandant zu einer ID gefunden");
			Mandant m = new Mandant();
			m.FromDataRow(tbl.Rows[0]);
			if (!(tbl.Rows[0]["ParentMandantID"] is DBNull))
			{
				m.Parent = LoadMandant((int)tbl.Rows[0]["ParentMandantID"]);
			}
			return m;
		}

		public List<Mandant> LoadMandants()
		{
			DataTable tbl =_con.GetData("CALL sp_GetMandants()");
			List<Mandant> mandants = new List<Mandant>();
			foreach (DataRow row in tbl.Rows)
			{
				Mandant m = new Mandant();
				m.FromDataRow(row);
				if (!(row["ParentMandantID"] is DBNull))
					m.Parent = LoadMandant((int)row["ParentMandantID"]);
				mandants.Add(m);
			}
			return mandants;
		}

		public void SetMandant(Model.Mandant mandant)
		{
			if (mandant.DeleteMe)
			{
				DeleteMandant(mandant);
				return;
			}
			if (mandant.IsNew)
			{
				object id = _con.LookUp("CALL sp_InsertMandant(?pmid, ?des)",
					new MySqlParameter("?pmid", mandant.Parent?.ID),
					new MySqlParameter("?des", mandant.Des));
				mandant.ID = Convert.ToInt32(id);
			}
			else
			{
				_con.ExecuteQuery("CALL sp_UpdateMandant(?mid, ?pmid, ?des)",
					new MySqlParameter("?mid", mandant.ID),
					new MySqlParameter("?pmid", mandant.Parent?.ID),
					new MySqlParameter("?des", mandant.Des));
			}
		}

		private void DeleteMandant(Mandant mandant)
		{
			_con.ExecuteQuery("CALL sp_DeleteMandant(?mid)", new MySqlParameter("?mid", mandant.ID));
		}
		#endregion

		#region Setting
		public List<Setting> LoadSettings(Mandant mandant)
		{
			DataTable t = _con.GetData("CALL sp_GetSettings(?mid)", new MySqlParameter("?mid", mandant.ID));
			List<Setting> retval = new List<Setting>();
			foreach (DataRow row in t.Rows)
			{
				Setting s = new Setting();
				s.FromDataRow(row);
				s.Mandant = LoadMandant((int)row["MandantID"]);
				retval.Add(s);
			}
			return retval;
		}

		public void SetSetting(Setting setting)
		{
			if (setting.DeleteMe)
			{
				_con.ExecuteQuery("CALL sp_DeleteSetting(?sid, ?mid)",
						new MySqlParameter("?sid", setting.ID),
						new MySqlParameter("?mid", setting.Mandant.ID)
					);
			}
			else
			{
				if (setting.IsNew)
				{
					_con.ExecuteQuery("CALL sp_InsertSetting(?sid, ?mid, ?val)",
						new MySqlParameter("?sid", setting.ID),
						new MySqlParameter("?mid", setting.Mandant.ID),
						new MySqlParameter("?val", setting.SettingsValue));
				}
				else
				{
					_con.ExecuteQuery("CALL sp_UpdateSetting(?sid, ?mid, ?val)",
						new MySqlParameter("?sid", setting.ID),
						new MySqlParameter("?mid", setting.Mandant.ID),
						new MySqlParameter("?val", setting.SettingsValue));
				}
			}
		}
		#endregion

		#region Login
		public Login LoadLogin(string username, byte[] password)
		{
			// TODO DA: SP aufrufen
			DataTable tbl = _con.GetData("CALL sp_GetLogin(?user,?pass)",
				new MySqlParameter("?user", username),
				new MySqlParameter("?pass", password));
			if (tbl.Rows.Count > 1)
				throw new ApplicationException($"Zu viele Logins zu User \"${username}\" gefunden, Mglw. Datenbankproblem!");
			Login retval = new Login();

			if (tbl.Rows.Count == 1)    // wenn keine Zeilen zurückkamen, war user u./od. Pass falsch
			{
				retval.FromDataRow(tbl.Rows[0]);
				retval.Mandant = LoadMandant((int)tbl.Rows[0]["MandantID"]);
			}
			return retval;
		}

		public void SetLogin(Login login)
		{
			// TODO DA: SP aufrufen
			if (login.DeleteMe)
			{
				_con.ExecuteQuery("DELETE FROM Login WHERE LoginID=?lid", new MySqlParameter("?lid", login.ID));
			}
			else
			{
				if (login.IsNew)
				{
					string sql = "INSERT INTO Login (Username, Pasword, MandantID, Changedate) VALUES (?user, ?pass, ?mid, NOW())";
					_con.ExecuteQuery(sql, new MySqlParameter("?user", login.Username),
						new MySqlParameter("?pass", login.Password), new MySqlParameter("?mid", login.Mandant.ID));
					object id = _con.LookUp("SELECT LAST_INSERT_ID()");
					login.ID = Convert.ToInt32(id);
				}
				else
				{
					string sql = "UPDATE Login SET Username=?user, Password=?pass, MandantID=?mid, ChangeDate=NOW() WHERE LoginID=?lid";
					_con.ExecuteQuery(sql, new MySqlParameter("?user", login.Username),
						new MySqlParameter("?pass", login.Password), new MySqlParameter("?mid", login.Mandant.ID),
						new MySqlParameter("?lid", login.ID));
				}
			}
		}
		#endregion

	}
}
