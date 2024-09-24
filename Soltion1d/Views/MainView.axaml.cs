using Avalonia.Controls;
using Avalonia.Media;
using System;

namespace Soltion1d.Views
{
    public partial class MainView : UserControl:     NotifiableBase
    {
        public MainView()
        {
            InitializeComponent();
        }



        public override void Update(double dt)
        {
            // Update the soliton based on the KdV equation
            double c = 1;
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathGeometry.Figures.Add(pathFigure);
            for (double x = -1; x<=1; x+=dt)
            {
                double u = Amplitude*Math.Pow(Math.Sech(Math.Sqrt(Amplitude)/2*(x-c*dt)), 2);
                pathFigure.Segments.Add(new LineSegment(new Point(x, u)));
            }
            Path.Data=pathGeometry;
        }
    }
}