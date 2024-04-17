using GeoLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

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

        // Square feature enabled
        if (await featureManager.IsEnabledAsync("Square"))
        {
            Console.WriteLine("Square is enabled");
            // Square access
            Console.WriteLine("Enter the length of the square:");
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double sideLength))
            {
                Square square = new Square(sideLength);
                Console.WriteLine($"Area of the Square: {square.CalculateArea()}, Perimeter of the Square: {square.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Entered input is invalid");
            }
        }
        // Square feature disabled
        else
        {
            Console.WriteLine("Square is disabled.");
        }

        // Rectangle feature enabled
        if (await featureManager.IsEnabledAsync("Rectangle"))
        {
            Console.WriteLine("Rectangle is enabled");
            // Rectangle access
            Console.WriteLine("Enter the length of the rectangle:");
            string? lengthInput = Console.ReadLine();
            Console.WriteLine("Enter the width of the rectangle:");
            string? widthInput = Console.ReadLine();
            if (double.TryParse(lengthInput, out double length) && double.TryParse(widthInput, out double width))
            {
                Rectangle rectangle = new Rectangle(length, width);
                Console.WriteLine($"Area of the Rectangle: {rectangle.CalculateArea()}, Perimeter of the Rectangle: {rectangle.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Entered input is invalid");
            }
        }
        // Rectangle feature disabled
        else
        {
            Console.WriteLine("Rectangle is disabled");
        }

        // Triangle feature enabled
        if (await featureManager.IsEnabledAsync("Triangle"))
        {
            Console.WriteLine("Triangle is enabled");
            // Triangle access
            Console.WriteLine("Enter the length of side A of the triangle:");
            string? sideAInput = Console.ReadLine();
            Console.WriteLine("Enter the length of side B of the triangle:");
            string? sideBInput = Console.ReadLine();
            Console.WriteLine("Enter the length of side C of the triangle:");
            string? sideCInput = Console.ReadLine();
            if (double.TryParse(sideAInput, out double sideA) && double.TryParse(sideBInput, out double sideB) && double.TryParse(sideCInput, out double sideC))
            {
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                Console.WriteLine($"Area of the Triangle: {triangle.CalculateArea()}, Perimeter of the Triangle: {triangle.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Entered input is invalid");
            }
        }
        // Triangle feature disabled
        else
        {
            Console.WriteLine("Triangle is disabled");
        }
    

