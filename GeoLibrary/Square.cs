namespace GeoLibrary;
public class Square : IShape
{
    private readonly double _sideLength;

    public Square(double sideLength)
    {
        _sideLength = sideLength;
    }

    public double CalculateArea()
    {
        return _sideLength * _sideLength;
    }

    public double CalculatePerimeter()
    {
        return 4 * _sideLength;
    }
}
