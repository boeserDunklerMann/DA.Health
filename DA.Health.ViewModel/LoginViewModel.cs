using DA.Health.Contracts.Encryption;
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

		#region Actions
		private void Login()
		{
			string cryptedPass = _hasher.HashUserPasswort(_loginName, _plainPassword);
		}
		#endregion

		#region Commands
		public ICommand DoLogin => new DelegateCommand(Login);
		#endregion
	}
}
