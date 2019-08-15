using DA.Health.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.Contracts.Data
{
	public interface IDbAccessor
	{
		#region Mandanten
		List<Model.Mandant> LoadMandants();
		Model.Mandant LoadMandant(int mandantID);
		void SetMandant(Model.Mandant mandant);
		#endregion

		#region Gewicht
		List<Model.GewichtMesswert> LoadGewicht(Model.Mandant mandant);
		void SetGewicht(Model.GewichtMesswert gewicht);
		#endregion

		#region Setting
		List<Setting> LoadSettings(Mandant mandant);
		void SetSetting(Setting setting);
		#endregion
	}
}
