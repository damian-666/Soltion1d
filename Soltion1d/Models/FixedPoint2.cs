public struct FixedPoint
{
    private const int FractionalBits = 16;
    private const int FractionalMask = (1<<FractionalBits)-1;
    private readonly int _value;

    public FixedPoint(int value) => _value=value<<FractionalBits;
    public FixedPoint(double value) => _value=(int)(value*(1<<FractionalBits));

    public static FixedPoint operator +(FixedPoint a, FixedPoint b) => new FixedPoint { _value=a._value+b._value };
    public static FixedPoint operator -(FixedPoint a, FixedPoint b) => new FixedPoint { _value=a._value-b._value };

    public static FixedPoint operator *(FixedPoint a, FixedPoint b)
    {
        long result = (long)a._value*b._value;
        result+=1<<(FractionalBits-1);
        result>>=FractionalBits;
        return new FixedPoint { _value=(int)result };
    }

    public static FixedPoint operator /(FixedPoint a, FixedPoint b)
    {
        long result = ((long)a._value<<FractionalBits)/b._value;
        return new FixedPoint { _value=(int)result };
    }

    public override string ToString() => ((double)_value/(1<<FractionalBits)).ToString();
}
public struct FixedPoint






{
    private const int FractionalBits = 16;
    private const int IntegerBits = 32-FractionalBits;
    private const int FractionalMask = (1<<FractionalBits)-1;

    private readonly int _value;

    public FixedPoint(int value)
    {
        _value=value<<FractionalBits;
    }

    public FixedPoint(double value)
    {
        _value=(int)(value*(1<<FractionalBits));
    }

    public static FixedPoint operator +(FixedPoint a, FixedPoint b)
    {
        return new FixedPoint { _value=a._value+b._value };
    }

    public static FixedPoint operator -(FixedPoint a, FixedPoint b)
    {
        return new FixedPoint { _value=a._value-b._value };
    }

    public static FixedPoint operator *(FixedPoint a, FixedPoint b)
    {
        long result = (long)a._value*b._value;
        result+=1<<(FractionalBits-1); // for rounding
        result>>=FractionalBits;
        return new FixedPoint { _value=(int)result };
    }

    public static FixedPoint operator /(FixedPoint a, FixedPoint b)
    {
        long result = ((long)a._value<<FractionalBits)/b._value;
        return new FixedPoint { _value=(int)result };
    }

    public override string ToString()
    {
        return ((double)_value/(1<<FractionalBits)).ToString();
    }
}
