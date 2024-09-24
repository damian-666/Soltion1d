using Avalonia.Media;
using System;
using System.Collections.ObjectModel;

public class WaveViewModel
{
    /// <summary>
    /// path of view
    /// </summary>
    public Path Path { get; set; }
    public ObservableCollection<IWave> Waves { get; set; }

    public WaveViewModel()
    {
        Waves=new ObservableCollection<IWave>();
    }

    public void AddWave(IWave wave)
    {
        // here add the wave to the collection
        Waves.Add(wave);
    }

    public void UpdateWaves(double dt)
    {
        foreach (var wave in Waves)
        {
            wave.Update(dt);
        }
    }

    // Update the soliton based on the KdV equation
    public void UpdatePath(double dt, double Amplitude)
    {
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
Path.Data=pathGeometry;
}
