using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DA.Health.Contracts.Data;
using DA.Health.Model;
using DA.lib.MVVM.Framework;
namespace DA.Health.ViewModel
{
	public sealed class GewichtEintragViewModel : ObservableObject
	{
		private static GewichtEintragViewModel _instance;
		public static GewichtEintragViewModel Instance => _instance;
		private readonly IDbAccessor _db;

		private GewichtMesswert _selectedEintrag;
		public GewichtMesswert SelectedEintrag
		{
			get { return _selectedEintrag; }
			set
			{
				_selectedEintrag = value;
				RaisePropertyChangedEvent(nameof(SelectedEintrag));
			}
		}
		
		public GewichtEintragViewModel()
		{
			_db = Commons.ContractBinder.GetObject<IDbAccessor>();
			GewichtEintragViewModel._instance = this;
		}

		private void RaiseChangeEvent()
		{
			GewichtProtokollViewModel.Instance.LoadGewicht();
			GewichtZusammenfassungViewModel.Instance.LoadSummary();
		}

		#region Actions
		private void SaveAction()
		{
			_db.SetGewicht(_selectedEintrag);
			RaiseChangeEvent();
		}

		private void DeleteAction()
		{
			_selectedEintrag.DeleteMe = true;
			SaveAction();
		}
		#endregion

		#region Commands
		public ICommand DoSave => new DelegateCommand(SaveAction);
		public ICommand DoDelete => new DelegateCommand(DeleteAction);
		#endregion
	}
}
