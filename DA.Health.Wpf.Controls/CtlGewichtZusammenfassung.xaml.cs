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
    /// Interaction logic for CtlGewichtSummary.xaml
    /// </summary>
    public partial class CtlGewichtZusammenfassung : UserControl
    {
        public CtlGewichtZusammenfassung()
        {
            InitializeComponent();
			DrawDiagram();
        }

		private void DrawDiagram()
		{
			Line line = new Line();
			Polygon polygon = new Polygon();
			polygon.Points = new PointCollection(GetPointList());
			polygon.StrokeThickness = 1;
			polygon.Stroke = Brushes.Red;
			canvas.Children.Add(polygon);
		}

		private List<Point> GetPointList()
		{
			List<Point> points = new List<Point>();
			if (null != vm.AllValues)
			{
				decimal min = vm.AllValues.Min();
				decimal max = vm.Max.HasValue ? vm.Max.Value : 0;
				double rng = (double)(max - min);
				double yScale = canvas.Height / rng;
				int xStep = (int)canvas.Width / vm.AllValues.Count;
				List<double> list = new List<double>();
				vm.AllValues.ForEach(d =>
				{
					list.Add((double)(d - min));
				});
				int curX = 0;
				list.ForEach(l => {
					l /= yScale;
					Point p = new Point(curX, l);
					points.Add(p);
					curX += xStep;
				});
			}
			return points;
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			DrawDiagram();
		}
	}
}
