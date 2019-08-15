﻿using System;
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
				//m.Parent = new Mandant();
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
				// sp_UpdateMandant
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
	}
}
