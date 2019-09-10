using DA.Health.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DA.Health.Wpf.Controls
{
	/// <summary>
	/// Interaction logic for LoginControl.xaml
	/// </summary>
	public partial class LoginControl : UserControl
	{
		public LoginControl()
		{
			InitializeComponent();
			loginViewModel.AfterLogin += LoginViewModel_AfterLogin;
			Login = null;
		}

		private void LoginViewModel_AfterLogin()
		{
			if (null != AfterLogin)
			{
				//if (!loginViewModel.HasFailed)
				{
					Login = loginViewModel.AuthenticatedLogin;
					AfterLogin();
				}
			}
		}

		public delegate void AfterLoginEventHandler();
		public event AfterLoginEventHandler AfterLogin;
		public Login Login { get; private set; }
	}
}
