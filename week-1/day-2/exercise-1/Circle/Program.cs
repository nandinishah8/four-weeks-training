namespace Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a Circle object and display its area and circumference
            Circle circle = new Circle(5);
            double area = circle.CalculateArea();
            Console.WriteLine("Area: " + area);

            double circumference = circle.CalculateCircumference();
            Console.WriteLine("Circumference: " + circumference);

            Console.ReadLine();

        }
    }
}