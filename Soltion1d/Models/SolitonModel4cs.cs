using System.Numerics;
using System.Collections.Generic;

public class SolitonModel
{
    public double Amplitude { get; set; }

    public List<Vector2> Update(double dt)
    {
        double c = 1;
        List<Vector2> points = new List<Vector2>();

        for (double x = -1; x<=1; x+=dt)
        {
            double u = Amplitude*Math.Pow(Math.Sech(Math.Sqrt(Amplitude)/2*(x-c*dt)), 2);
            points.Add(new Vector2((float)x, (float)u));
        }

        return points;
    }
}
