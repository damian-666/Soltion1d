using System.ComponentModel;

public class Soliton : Wave, INotifyPropertyChanged
{
    private double _startPositionX;
    public double StartPositionX
    {
        get { return _startPositionX; }
        set
        {
            if (_startPositionX!=value)
            {
                _startPositionX=value;
                OnPropertyChanged(nameof(StartPositionX));
            }
        }
    }

    public override double Amplitude
    {
        get { return base.Amplitude; }
        set
        {
            if (base.Amplitude!=value)
            {
                base.Amplitude=value;
                OnPropertyChanged(nameof(Amplitude));
            }
        }
    }

    public Soliton(double amplitude, double width, double startPositionX) : base(amplitude, width):base(amplitude, width)
    {
        StartPositionX=startPositionX;

   

    }

    // ... rest of the class ...

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

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
