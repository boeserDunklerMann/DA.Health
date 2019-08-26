using DA.Health.Model;
using DA.lib.MVVM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.ViewModel
{
	public sealed class GewichtZusammenfassungViewModel: ObservableObject
	{
		private static GewichtZusammenfassungViewModel _instance;
		public static GewichtZusammenfassungViewModel Instance => _instance;

		private Mandant _selectedMandant;
		private Commons.Settings _settings;
		public Mandant SelectedMandant
		{
			get { return _selectedMandant; }
			set
			{
				_selectedMandant = value;
				_settings = new Commons.Settings(_selectedMandant);
				RaisePropertyChangedEvent(nameof(WeightUnit));
				RaisePropertyChangedEvent(nameof(SelectedMandant));
				LoadSummary();
			}
		}

		/// <summary>
		/// Lädt die Zusammenfassung und veranlasst die View sich zu aktualisieren
		/// </summary>
		public void LoadSummary()
		{
			List<GewichtMesswert> messwerts = ((GewichtProtokollViewModel)GewichtProtokollViewModel.Instance).Gewicht;
			if (messwerts.Count > 0)
			{
				Min = messwerts.Min(mw => mw.Value);
				Avg = messwerts.Average(mw => mw.Value);
				Max = messwerts.Max(mw => mw.Value);
				var datum = messwerts.Select((mw)=> new { mw.Datum }).OrderBy(x => x.Datum);
				FirstDate = (DateTime?)datum.First().Datum;
				LastDate = datum.Last().Datum;
			}
			else
			{
				Min = Max = Avg = null;
				FirstDate = LastDate = null;
			}
			RaisePropertyChangedEvent(nameof(Min));
			RaisePropertyChangedEvent(nameof(Avg));
			RaisePropertyChangedEvent(nameof(Max));
			RaisePropertyChangedEvent(nameof(LastDate));
			RaisePropertyChangedEvent(nameof(FirstDate));
		}

		public decimal? Min { get; set; }
		public decimal? Avg { get; set; }
		public decimal? Max { get; set; }
		public DateTime? FirstDate { get; set; }
		public DateTime? LastDate { get; set; }
		public string WeightUnit => _settings?[Commons.Settings.WEIGHT_UNIT]?.SettingsValue;

		public GewichtZusammenfassungViewModel()
		{
			_instance = this;
		}
	}
}
