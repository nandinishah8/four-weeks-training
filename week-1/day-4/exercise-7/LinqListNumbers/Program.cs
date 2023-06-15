namespace LinqListNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of integers
            List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

            // Use LINQ to perform the following operations:

            // 1. Find all even numbers

            var evenNumbers = numbers.Where(num => num % 2 == 0);


            // 2. Find all numbers greater than a specific value (e.g., 20)

            int specificValue = 20;
            var greaterThanSpecificValue = numbers.Where(num => num > specificValue);


            // 3. Calculate the sum of all numbers

            int sum = numbers.Sum();

            // 4. Calculate the average of all numbers

            double average = numbers.Average();

            // 5. Find the minimum and maximum values in the list

            int minimum = numbers.Min();
            int maximum = numbers.Max();

            Console.WriteLine("Even numbers:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nNumbers greater than {0}:", specificValue);
            foreach (var num in greaterThanSpecificValue)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nSum: {0}", sum);
            Console.WriteLine("Average: {0}", average);
            Console.WriteLine("Minimum: {0}", minimum);
            Console.WriteLine("Maximum: {0}", maximum);
        }
    }
}
