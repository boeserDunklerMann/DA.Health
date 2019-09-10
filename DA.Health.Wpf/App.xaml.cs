using System.Windows;
using Commons;

namespace DA.Health.Wpf
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			
			Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
			try
			{
				LoginWindow login = new LoginWindow();
				if (login.ShowDialog() == true)
				{
					Statics.CurrentLogin = login.Login;
					MainWindow window = new MainWindow();
					ShutdownMode = ShutdownMode.OnMainWindowClose;
					MainWindow = window;
					window.Show();
				}
				else
				{
					// TODO: Zeige Login-FM
					if (!login.Login.Validated)
					{
						MessageBox.Show("Login falsch");
					}
				}
			}
			catch (System.Exception ex)
			{
				HuchWindow huch = new HuchWindow(ex);
				huch.ShowDialog();
				Shutdown();
			}
		}
	}
}
