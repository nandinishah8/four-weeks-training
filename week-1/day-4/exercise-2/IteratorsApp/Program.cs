namespace IteratorsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fibonacci = FibonacciSequence().Take(10);
            foreach (int number in fibonacci)
            {
                Console.WriteLine(number);
            }
        }
        
        public static IEnumerable<int> FibonacciSequence()
        {
            int current = 0;
            int next = 1;

            while (true)
            {
                yield return current;   
                int temp = current;
                current = next;
                next = temp + next;
            }
            
        }
    }
}