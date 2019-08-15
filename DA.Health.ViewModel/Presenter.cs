using DA.Health.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.ViewModel
{
	public class Presenter : DA.lib.MVVM.Framework.ObservableObject
	{
		DA.Health.Contracts.Data.IDbAccessor _db = Commons.ContractBinder.GetObject<Contracts.Data.IDbAccessor>();

		public List<Mandant> Mandants { get; private set; }

		public Presenter() : base()
		{
			LoadMandants();
		}

		private void LoadMandants()
		{
			Mandants = _db.LoadMandants();
		}
	}
}
