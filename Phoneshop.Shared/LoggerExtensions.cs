using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Phoneshop.Shared.extensions
{
    public static class LoggerExtensions
    {
        public static ILoggingBuilder AddColorConsoleLogger(
        this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, LoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions
                <ColorConsoleLoggerConfiguration, CustomLogger>(builder.Services);

            return builder;
        }

        public static ILoggingBuilder AddColorConsoleLogger(
       this ILoggingBuilder builder, Action<ColorConsoleLoggerConfiguration> configure)
        {
            builder.AddColorConsoleLogger();

            builder.Services.Configure(configure);

            return builder;
        }
    }
}