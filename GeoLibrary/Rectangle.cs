namespace GeoLibrary;
public class Rectangle : IShape
{
    private readonly double _length;
    private readonly double _width;

    public Rectangle(double length, double width)
    {
        _length = length;
        _width = width;
    }

    public double CalculateArea()
    {
        return _length * _width;
    }

    public double CalculatePerimeter()
    {
        return 2 * (_length + _width);
    }
}