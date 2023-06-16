namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
            string filePath = "C:\\Users\\promact\\source\\repos\\Nandini\\week-1\\day-5\\exercise-1\\FileLoggerDisposableApp\\log.txt";

            using (FileLogger logger = new FileLogger(filePath))
            {
                logger.Log("This is a log message 1");
                logger.Log("This is a log message 2");
                logger.Log("This is a log message 3");

            }

            Console.WriteLine("Logging complete. Press any key to exit.");
            Console.ReadKey();

        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            // Initialize StreamWriter instance
            _writer = new StreamWriter(filePath, true);
        }

        public void Dispose()
        {
            // Implement IDisposable pattern
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _writer.Dispose();
            }
        }


        public void Log(string message)
        {
            // Write message to the file
            _writer.WriteLine(message);

        }
    }
}