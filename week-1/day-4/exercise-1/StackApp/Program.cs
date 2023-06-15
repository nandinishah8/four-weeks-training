namespace StackApp
{
    public class Stack<T>
    {
        private T[] items;
        private int top;

        public Stack()
        {
            items = new T[10];
            top = -1;
        }

        public void Push(T item)
        {
            if (top == items.Length - 1)
            {
                Console.WriteLine("Stack is full.");
                return;
            }

            top++;
            items[top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty Stack");
                return default(T);
            }

            T poppedItem = items[top];
            top--;
            return poppedItem;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            Console.WriteLine("Popped item from intStack: " + intStack.Pop());
            Console.WriteLine("Is intStack empty? " + intStack.IsEmpty());


            Stack<string> stringStack = new Stack<string>();
            stringStack.Push("Hello");
            stringStack.Push("World");
            Console.WriteLine("Popped item from stringStack: " + stringStack.Pop());
            Console.WriteLine("Is stringStack empty? " + stringStack.IsEmpty());
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;

            Stack<Person> personStack = new Stack<Person>();
            Person person1 = new Person("John", 25);
            Person person2 = new Person("Jane", 30);
            personStack.Push(person1);
            personStack.Push(person2);
            Console.WriteLine("Popped item from personStack: " + personStack.Pop().Name);
            Console.WriteLine("Is personStack empty? " + personStack.IsEmpty());
        }
    }
}


