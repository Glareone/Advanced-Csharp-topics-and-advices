// using Azure.Data.Tables;
// using Azure.Messaging.ServiceBus;
// using Azure.Storage;
// using Azure.Storage.Blobs;
using AzureFunction.Scheduler.ServiceBus;
using Common.Logger;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Exceptions;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(
        builder =>
        {
            // Add support of custom telemetry property to reflect component name.
            // https://learn.microsoft.com/en-us/azure/azure-monitor/app/worker-service#add-telemetry-initializers
            builder.Services
                .AddSingleton<ITelemetryInitializer, TelemetryInitializer>();
        })
    .ConfigureServices(
        (context, services) =>
        {
            services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();

            // CONFIGURE SETTINGS SECTION
            
            // services.AddOptions<AzureBlobStorageClientSettings>().Configure(
            //     options =>
            //     {
            //         options.Uri = context.Configuration["AzureBlobStorageClientSettingsUri"]!;
            //         options.AccountName = context.Configuration["AzureBlobStorageClientSettingsAccountName"]!;
            //         options.ContainerName = context.Configuration["AzureBlobStorageClientSettingsContainer"]!;
            //         options.Key = context.Configuration["AzureBlobStorageClientSettingsKey"]!;
            //     });

            // services.AddOptions<ServiceBusClientSettings>().Configure(
            //     options =>
            //     {
            //         options.ServiceBusConnectionString = context.Configuration["ServiceBusSettingsConnectionString"]!;
            //         options.QueueName = context.Configuration["ServiceBusSettingsQueueName"]!;
            //     });

            // CONFIGURE SERVICES SECTION
            
            // services.AddSingleton(
            //     s =>
            //     {
            //         var settings = s.GetService<IOptions<AzureBlobStorageClientSettings>>()!.Value;
            //
            //         return new BlobServiceClient(
            //             new Uri(settings.Uri),
            //             new StorageSharedKeyCredential(settings.AccountName, settings.Key));
            //     });

            // services.AddSingleton(
            //     serviceProvider =>
            //     {
            //         var settings = serviceProvider.GetRequiredService<IOptions<ServiceBusClientSettings>>().Value;
            //
            //         return new ServiceBusClient(settings.ServiceBusConnectionString);
            //     });

            // services.AddSingleton(
            //     serviceProvider =>
            //     {
            //         var client = serviceProvider.GetRequiredService<ServiceBusClient>();
            //         var settings = serviceProvider.GetRequiredService<IOptions<ServiceBusClientSettings>>().Value;
            //
            //         return client.CreateSender(settings.QueueName);
            //     });

            // services.AddSingleton<ServiceBusHandler>();
        })
    .ConfigureLogging(
        logging =>
        {
            // The Application Insights SDK adds a default logging filter that instructs ILogger to capture
            // only Warning and the more severe events. Application Insights requires an explicit override.
            logging.Services
                .Configure<LoggerFilterOptions>(
                    options =>
                    {
                        LoggerFilterRule defaultRule = options.Rules.FirstOrDefault(
                            rule => rule.ProviderName == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");

                        if (defaultRule is not null)
                        {
                            options.Rules.Remove(defaultRule);
                        }
                    });

            // Add console structured log output for debug and analysis.
            logging.AddSerilog(
                new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Enrich.WithCorrelationId()
                    .Enrich.WithExceptionDetails()
                    .WriteTo.Console()
                    .CreateLogger());
        })
    .Build();

await host.RunAsync();