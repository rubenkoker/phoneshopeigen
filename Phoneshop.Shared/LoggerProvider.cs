using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Phoneshop.Shared
{
    [ProviderAlias("ColorConsole")]
    public sealed class LoggerProvider : ILoggerProvider
    {

        private IDisposable? _onChangeToken;
        private ColorConsoleLoggerConfiguration _currentConfig;
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers =
            new(StringComparer.OrdinalIgnoreCase);

        public LoggerProvider(
            IOptionsMonitor<ColorConsoleLoggerConfiguration> config)
        {
            Debug.WriteLine($"test {config.CurrentValue == null}");
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, GetCurrentConfig));

        private ColorConsoleLoggerConfiguration GetCurrentConfig() => _currentConfig;

        public void Dispose()
        {
            _loggers.Clear();
            _onChangeToken?.Dispose();
        }
    }
}

