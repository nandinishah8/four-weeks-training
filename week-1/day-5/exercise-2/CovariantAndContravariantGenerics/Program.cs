using System;
namespace CovariantAndContravariantGenerics
{
    public interface IProcessor<in TInput, out TResult>
    {
        TResult Process(TInput input);
    }

   public class StringToIntProcessor : IProcessor<string, int>
    {
        // Implement Process method
        public int Process(string input)
        {
            return input.Length;
        }
    }

    public class DoubleToStringProcessor : IProcessor<double, string>
    {
        // Implement Process method
        public string Process(double input)
        {
            return input.ToString();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {

            // Demonstrate covariance and contravariance with IProcessor interface
            IProcessor<string, int> stringProcessor = new StringToIntProcessor();
            string inputString = "Hello, World!";
            object result = stringProcessor.Process(inputString);
            Console.WriteLine($"Length of input string: {result}");

            
            IProcessor<double, string> doubleProcessor = new DoubleToStringProcessor();
            double inputDouble = 3.14159;
            string stringResult = doubleProcessor.Process(inputDouble);
            Console.WriteLine($"String representation of input double: {stringResult}");
        }
    }
}