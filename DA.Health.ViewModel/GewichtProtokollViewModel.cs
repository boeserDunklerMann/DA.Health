using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Health.Contracts.Data;
using DA.lib.MVVM.Framework;
using DA.Health.Model;
using System.Windows.Input;

namespace DA.Health.ViewModel
{
	public sealed class GewichtProtokollViewModel : ObservableObject
	{
		private static GewichtProtokollViewModel _instance;
		public static GewichtProtokollViewModel Instance => _instance;

		private IDbAccessor _db;

		private Mandant _selectedMandant;
		public Mandant SelectedMandant
		{
			get { return _selectedMandant; }
			set
			{
				_selectedMandant = value;
				RaisePropertyChangedEvent(nameof(SelectedMandant));
				LoadGewicht();
			}
		}
		public List<GewichtMesswert> Gewicht { get; private set; }

		private GewichtMesswert _selectedMesswert;
		public GewichtMesswert SelectedMesswert
		{
			get
			{
				return _selectedMesswert;
			}
			set
			{
				_selectedMesswert = value;
				RaisePropertyChangedEvent(nameof(SelectedMesswert));
				GewichtEintragViewModel.Instance.SelectedEintrag = value;
			}
		}
		public GewichtProtokollViewModel()
		{
			_db = Commons.ContractBinder.GetObject<IDbAccessor>();
			GewichtProtokollViewModel._instance = this;
		}

		private void LoadGewicht()
		{
			if (null != _selectedMandant)
			{
				Gewicht = _db.LoadGewicht(_selectedMandant);
				RaisePropertyChangedEvent(nameof(Gewicht));
			}
		}

		#region Actions
		private void AddNew()
		{
			GewichtMesswert neuerEintrag = new GewichtMesswert();
			neuerEintrag.Datum = DateTime.Now;
			neuerEintrag.Mandant = SelectedMandant;
			_db.SetGewicht(neuerEintrag);
			Gewicht.Add(neuerEintrag);
			RaisePropertyChangedEvent(nameof(Gewicht));
			SelectedMesswert = neuerEintrag;
		}
		#endregion

		#region Commands
		public ICommand DoAddNew => new DelegateCommand(AddNew);
		#endregion
	}
}
