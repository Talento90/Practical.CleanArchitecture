using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using System;
using System.IO;

namespace ClassifiedAds.Infrastructure.Logging
{
    public class Logger
    {
        public static void Configure(string contentRootPath, string applicationName, LoggerOptions options)
        {
            var logsPath = Path.Combine(contentRootPath, "logs");
            Directory.CreateDirectory(logsPath);
            var loggerConfiguration = new LoggerConfiguration();

            loggerConfiguration = loggerConfiguration
                .Enrich.WithProperty("Application", applicationName)
                .WriteTo.File(Path.Combine(logsPath, "log.txt"),
                    fileSizeLimitBytes: 10 * 1024 * 1024,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug);

            if (options.Elasticsearch != null && options.Elasticsearch.IsEnabled)
            {
                loggerConfiguration = loggerConfiguration
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(options.Elasticsearch.Host))
                    {
                        MinimumLogEventLevel = options.Elasticsearch.MinimumLogEventLevel,
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                        IndexFormat = options.Elasticsearch.IndexFormat + "-{0:yyyy.MM.dd}",
                        // BufferBaseFilename = Path.Combine(env.ContentRootPath, "logs", "buffer"),
                        InlineFields = true,
                        EmitEventFailure = EmitEventFailureHandling.WriteToFailureSink,
                        FailureSink = new FileSink(Path.Combine(logsPath, "elasticsearch-failures.txt"), new JsonFormatter(), null)
                    });
            }

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }
}
