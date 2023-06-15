namespace LinqToObjectsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "John", Age = 25, Country = "USA" },
                new Person { Name = "Jane", Age = 30, Country = "Canada" },
                new Person { Name = "Mark", Age = 28, Country = "USA" },
                new Person { Name = "Emily", Age = 22, Country = "Australia" }
            };


            //Write queries using LINQ for following operations

            //1. Get all people from USA
            var peopleFromUSA = people.Where(p => p.Country == "USA");
            Console.WriteLine("People from USA:");
            foreach (var person in peopleFromUSA)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }
            Console.WriteLine();

            //2. Get all people above 30

            var peopleAbove30 = people.Where(p => p.Age > 30);
            Console.WriteLine("People above 30:");
            foreach (var person in peopleAbove30)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }
            Console.WriteLine();


            //3. Sort people by name

            var sortedPeopleByName = people.OrderBy(p => p.Name);
            Console.WriteLine("People sorted by name:");
            foreach (var person in sortedPeopleByName)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }
            Console.WriteLine();


            //4. Project/Select only Name and Country of all people

            var nameAndCountry = people.Select(p => new { p.Name, p.Country });
            Console.WriteLine("Name and Country of all people:");
            foreach (var person in nameAndCountry)
            {
                Console.WriteLine($"{person.Name}, {person.Country}");
            }
            Console.WriteLine();

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}