using GeoLibrary;

namespace GeoTest;


[TestClass]
public class ShapeTests
{
    [TestMethod]
    public void SquareAreaTestCase()
    {
        var square = new Square(5);
        var result = square.CalculateArea();
        Assert.AreEqual(25, result);
    }

    [TestMethod]
    public void SquarePerimeterTestCase()
    {
        var square = new Square(5);
        var result = square.CalculatePerimeter();
        Assert.AreEqual(20, result);
    }

    [TestMethod]
    public void RectangleAreaTestCase()
    {
        var rectangle = new Rectangle(5, 3);
        var result = rectangle.CalculateArea();
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void RectanglePerimeterTestCase()
    {
        var rectangle = new Rectangle(5, 3);
        var result = rectangle.CalculatePerimeter();
        Assert.AreEqual(16, result);
    }

    [TestMethod]
    public void TriangleAreaTestCase()
    {
        var triangle = new Triangle(3, 4, 5);
        var result = triangle.CalculateArea();
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TrianglePerimeterTestCase()
    {
        var triangle = new Triangle(3, 4, 5);
        var result = triangle.CalculatePerimeter();
        Assert.AreEqual(12, result);
    }
}
