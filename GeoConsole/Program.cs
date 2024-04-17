using System;
using System.Collections.Generic;
using GeoLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        var featureManagement = new Dictionary<string, string> {
            { "FeatureManagement:Square", "true"},
            { "FeatureManagement:Rectangle", "true"},
            { "FeatureManagement:Triangle", "true"}
        };
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement)
            .Build();
        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var featureManager = serviceProvider.GetRequiredService<IFeatureManagerSnapshot>();

        if (await featureManager.IsEnabledAsync("Square"))
        {
            Console.WriteLine("Square feature is enabled.");
            // Provide access to Square
            Console.WriteLine("Enter the length of the square:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double sideLength))
            {
                Square square = new Square(sideLength);
                Console.WriteLine($"Square - Area: {square.CalculateArea()}, Perimeter: {square.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Invalid input for Square");
            }
        }
        else
        {
            Console.WriteLine("Square feature is disabled.");
        }

        if (await featureManager.IsEnabledAsync("Rectangle"))
        {
            Console.WriteLine("Rectangle feature is enabled.");
            // Provide access to Rectangle
            Console.WriteLine("Enter the length of the rectangle:");
            string lengthInput = Console.ReadLine();
            Console.WriteLine("Enter the width of the rectangle:");
            string widthInput = Console.ReadLine();
            if (double.TryParse(lengthInput, out double length) && double.TryParse(widthInput, out double width))
            {
                Rectangle rectangle = new Rectangle(length, width);
                Console.WriteLine($"Rectangle - Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Invalid input for Rectangle. Please enter valid numbers.");
            }
        }
        else
        {
            Console.WriteLine("Rectangle feature is disabled.");
        }

        if (await featureManager.IsEnabledAsync("Triangle"))
        {
            Console.WriteLine("Triangle feature is enabled.");
            // Provide access to Triangle
            Console.WriteLine("Enter the length of side A of the triangle:");
            string sideAInput = Console.ReadLine();
            Console.WriteLine("Enter the length of side B of the triangle:");
            string sideBInput = Console.ReadLine();
            Console.WriteLine("Enter the length of side C of the triangle:");
            string sideCInput = Console.ReadLine();
            if (double.TryParse(sideAInput, out double sideA) && double.TryParse(sideBInput, out double sideB) && double.TryParse(sideCInput, out double sideC))
            {
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                Console.WriteLine($"Triangle - Area: {triangle.CalculateArea()}, Perimeter: {triangle.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Invalid input for Triangle. Please enter valid numbers.");
            }
        }
        else
        {
            Console.WriteLine("Triangle feature is disabled.");
        }
    }
}
