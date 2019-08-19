using DA.Health.Contracts.Data;
using DA.Health.Contracts.Encryption;
using DA.Health.Model;
using DA.lib.MVVM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DA.Health.ViewModel
{
	public sealed class LoginViewModel : ObservableObject
	{
		private readonly IEncHasher _hasher = Commons.ContractBinder.GetObject<IEncHasher>();
		private string _loginName;
		public string LoginName
		{
			get => _loginName;
			set
			{
				_loginName = value;
				RaisePropertyChangedEvent(nameof(LoginName));
			}
		}

		private string _plainPassword;
		public string PlainPassword
		{
			get => _plainPassword;
			set
			{
				_plainPassword = value;
			}
		}

		public LoginViewModel()
		{
			LoginName = Environment.UserName;
		}

		private Login _login;
		public Login AuthenticatedLogin => _login;

		#region Actions
		private void Login()
		{
			byte[] cryptedPass = _hasher.HashUserPasswort(_loginName, _plainPassword);
			IDbAccessor db = Commons.ContractBinder.GetObject<IDbAccessor>();
			_login = db.LoadLogin(_loginName, cryptedPass);

		}
		#endregion

		#region Commands
		public ICommand DoLogin => new DelegateCommand(Login);
		#endregion
	}
}
