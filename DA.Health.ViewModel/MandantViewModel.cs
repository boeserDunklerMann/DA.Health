using DA.Health.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DA.lib.MVVM.Framework;
using DA.Health.Contracts.Data;

namespace DA.Health.ViewModel
{
	public class MandantViewModel : ObservableObject
	{
		IDbAccessor _db = Commons.ContractBinder.GetObject<Contracts.Data.IDbAccessor>();
		public List<Mandant> Mandants { get; private set; }

		private Mandant _selectedMandant;
		public Mandant SelectedMandant
		{
			get
			{
				return _selectedMandant;
			}
			set
			{
				_selectedMandant = value;
				RaisePropertyChangedEvent(nameof(SelectedMandant));
				((GewichtProtokollViewModel)GewichtProtokollViewModel.Instance).SelectedMandant = value;
				((GewichtZusammenfassungViewModel)GewichtZusammenfassungViewModel.Instance).SelectedMandant = value;
			}
		}
		/// <summary>
		/// Der Des-String des ausgewählten Mandants
		/// </summary>
		public string Des { get; set; }

		public MandantViewModel()
		{
			LoadMandants();
		}

		private void LoadMandants()
		{
			Mandants = _db.LoadMandants();
		}

		#region Actions
		private void AddMandant()
		{
			Mandant neuerMandant = new Mandant() { Des = this.Des };
			_db.SetMandant(neuerMandant);
			Mandants.Add(neuerMandant);
			RaisePropertyChangedEvent(nameof(Mandants));
		}
		private void DeleteSelectedMandant()
		{
			_selectedMandant.DeleteMe = true;
			_db.SetMandant(_selectedMandant);
			Mandants.Remove(_selectedMandant);
			SelectedMandant = null;
			RaisePropertyChangedEvent(nameof(SelectedMandant));
		}
		#endregion

		#region Commands
		public ICommand DoAddMandant => new DelegateCommand(AddMandant);
		public ICommand DoDeleteMandant => new DelegateCommand(DeleteSelectedMandant);
		#endregion
	}
}
