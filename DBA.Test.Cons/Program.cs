using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Health.Contracts;
using DA.Health.Model;

namespace DBA.Test.Cons
{
	class Program
	{
		static void Main(string[] args)
		{
			DA.Health.Contracts.Data.IDbAccessor db = new DA.Health.DbAccess.MySql.DbaMySql();
			var ms = db.LoadMandants();
			var gs = db.LoadGewicht(ms.Where(m => m.ID==2).First());
			GewichtMesswert messwert = gs[0];
			messwert.Bemerkung = "TEst";
			db.SetGewicht(messwert);
			messwert = new GewichtMesswert() { Bemerkung = "Nochn Test...", Datum = DateTime.Now, Value = 100, Mandant=ms.Find(m => m.ID==2) };
			db.SetGewicht(messwert);
			messwert.DeleteMe = true;
			db.SetGewicht(messwert);

			Mandant ma = new Mandant() { Des = "André Test" };
			db.SetMandant(ma);
			ma.Parent = ms[0];
			db.SetMandant(ma);
			ma.DeleteMe = true;
			db.SetMandant(ma);
		}
	}
}
