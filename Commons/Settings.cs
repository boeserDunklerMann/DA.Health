using DA.Health.Contracts.Data;
using DA.Health.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
	public sealed class Settings
	{
		#region Keys
		public const int WEIGHT_UNIT = 1;
		#endregion

		private readonly Mandant _mandant;
		private readonly List<Setting> _settings;

		public Settings(Mandant mandant)
		{
			_mandant = mandant;
			_settings = ContractBinder.GetObject<IDbAccessor>().LoadSettings(_mandant);
		}

		public Setting GetSetting(int settingsKey)
		{
			return _settings.Where(s => s.ID == settingsKey && s.Mandant.ID == _mandant.ID).First();
		}

		public Setting this[int settingsKey]
		{
			get
			{
				return GetSetting(settingsKey);
			}
			set
			{
				if (_settings.Contains(value))
				{
					_settings[_settings.IndexOf(value)] = value;
				}
				else
				{
					int newID = _settings.Where(s=>s.Mandant.ID==_mandant.ID).OrderBy(s => s.ID).Last().ID + 1;
					value.ID = newID;
					value.IsNew = true;
					_settings.Add(value);
				}
			}
		}
		public void Save()
		{
			IDbAccessor db = ContractBinder.GetObject<IDbAccessor>();
			_settings.ForEach(s => db.SetSetting(s));
		}
	}
}
