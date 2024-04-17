namespace GeoLibrary;
public class Triangle : IShape
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double CalculateArea()
    {
        double s = (_sideA + _sideB + _sideC) / 2;
        return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
    }

    public double CalculatePerimeter()
    {
        return _sideA + _sideB + _sideC;
    }
}