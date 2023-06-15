namespace LinqFilterAndSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Person objects
            List<Person> people = new List<Person>
            {
                new Person { Name = "John", Age = 25, Country = "USA" },
                new Person { Name = "Jane", Age = 30, Country = "Canada" },
                new Person { Name = "Mark", Age = 28, Country = "USA" },
                new Person { Name = "Emily", Age = 22, Country = "Australia" }
            };


            // Use LINQ to filter and sort the list

            var filteredAndSorted = people
                .Where(person => person.Age > 25) // Filter people above 25 years old
                .OrderBy(person => person.Name); // Sort the filtered list by name


            // Print the filtered and sorted list of people to the console

            foreach (var person in filteredAndSorted)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Country: {person.Country}");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}
