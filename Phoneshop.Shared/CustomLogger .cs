using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Phoneshop.Shared
{
    public class CustomLogger : ILogger
    {

        private readonly string _name;

        private readonly Func<ColorConsoleLoggerConfiguration> _getCurrentConfig;
        public CustomLogger(string name,
        Func<ColorConsoleLoggerConfiguration> getCurrentConfig) =>
        (_name, _getCurrentConfig) = (name, getCurrentConfig);

        public IDisposable BeginScope<TState>(TState state) where TState : notnull => default!;

        public bool IsEnabled(LogLevel logLevel)
        {
            Debug.WriteLine(_getCurrentConfig() == null);
            return _getCurrentConfig().LogLevelToColorMap.ContainsKey(logLevel);
        }
        public void Log<TState>(
       LogLevel logLevel,
       EventId eventId,
       TState state,
       Exception? exception,
       Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            ColorConsoleLoggerConfiguration config = _getCurrentConfig();
            if (config.EventId == 0 || config.EventId == eventId.Id)
            {
                ConsoleColor originalColor = Console.ForegroundColor;

                Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
                Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");

                Console.ForegroundColor = originalColor;
                Console.Write($"     {_name} - ");

                Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
                Console.Write($"{formatter(state, exception)}");

                Console.ForegroundColor = originalColor;
                Console.WriteLine("over");
            }

        }

    }
}

public sealed class ColorConsoleLoggerConfiguration
{
    public int EventId { get; set; }

    public Dictionary<LogLevel, ConsoleColor> LogLevelToColorMap { get; set; } = new();

}
