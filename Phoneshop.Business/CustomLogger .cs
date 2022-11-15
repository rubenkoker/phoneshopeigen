using Microsoft.Extensions.Logging;

namespace Phoneshop.Business
{
    public class CustomLogger : ILogger
    {
        private readonly string CategoryName;
        private readonly string _logPrefix;

        public CustomLogger(string categoryName, string logPrefix)
        {
            CategoryName = categoryName;
            _logPrefix = logPrefix;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = _logPrefix;
            if (formatter != null)
            {
                message += formatter(state, exception);
            }
            // Implement log writter as you want. I am using Console
            Console.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {CategoryName} - {message}");
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }

    }
}
