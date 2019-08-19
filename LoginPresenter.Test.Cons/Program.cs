using DA.Health.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPresenter.Test.Cons
{
	class Program
	{
		public static object Login { get; private set; }

		static void Main(string[] args)
		{
			DA.Health.Contracts.Data.IDbAccessor db = Commons.ContractBinder.GetObject< DA.Health.Contracts.Data.IDbAccessor>();
			DA.Health.ViewModel.LoginViewModel vm = new DA.Health.ViewModel.LoginViewModel();
			vm.LoginName = "dunkelan";
			vm.PlainPassword = "";
			var loginAction = vm.DoLogin;
			loginAction.Execute(null);
			DA.Health.Contracts.Encryption.IEncHasher h = Commons.ContractBinder.GetObject<DA.Health.Contracts.Encryption.IEncHasher>();
			Login l = new Login() { ID = 1, Username = "dunkelan", Password = h.HashUserPasswort("dunkelan", "") };
			l.Mandant = db.LoadMandant(2);
			//db.SetLogin(l);

			Login l2 = db.LoadLogin("dunkelan", h.HashUserPasswort("dunkelan", "xyxyx"));
		}
	}
}
