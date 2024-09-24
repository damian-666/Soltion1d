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

    /// <summary>
    /// idr eomf simd to updatae this and used a Vector< integet> and effectively make it fixed point by haveing is device by the domain sie..  Vector256<Integer32>  or Vector128<integet> or Vector64<integet> or Vector32<integet> or Vector16<integet> or Vector8<integet> or Vector4<integet> or Vector2
    </integet>
using System;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

public class FixedPointVector
    {
        private Vector<int> vector;
        private int domainSize;

        public FixedPointVector(int[] values, int domainSize)
        {
            if (values.Length!=Vector<int>.Count)
                throw new ArgumentException($"Input array must have {Vector<int>.Count} elements.");

            this.vector=new Vector<int>(values);
            this.domainSize=domainSize;
        }

        public Vector<int> Update(Vector<int> updateValues)
        {


            vector=Vector.Divide(vector+updateValues, new Vector<int>(domainSize));

            //now put the loop to the fixed point
            //double c = 1;
            //List<Vector2> points = new List<Vector2>();

            //for (double x = -1; x<=1; x+=dt)
            //{
            //    double u = Amplitude*Math.Pow(Math.Sech(Math.Sqrt(Amplitude)/2*(x-c*dt)), 2);
            //    points.Add(new Vector2((float)x, (float)u));
            //}

            //return points;
            return vector;
        }
    }
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public List<Vector2> Update2(double dt)
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
