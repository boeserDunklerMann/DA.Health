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
using System.Windows.Shapes;

namespace DA.Health.Wpf
{
	/// <summary>
	/// Interaction logic for HuchWindow.xaml
	/// </summary>
	public partial class HuchWindow : Window
	{
		public HuchWindow(Exception exception)
		{
			InitializeComponent();
			Exception e = exception;
			while (e.InnerException != null)
				e = e.InnerException;

			txtError.Text = $"{e.Message}\r\nbei: \r\n{e.StackTrace}";
		}
	}
}
