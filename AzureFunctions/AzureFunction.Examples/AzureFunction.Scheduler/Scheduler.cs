using System.Globalization;
using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureFunction.Scheduler.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureFunction.Scheduler;

public class Scheduler(
    // BlobServiceClient azureBlobServiceClient,
    // TableServiceClient azureTableServiceClient,
    // IOptions<AzureBlobStorageClientSettings> azureBlobStorageClientSettings,
    // IOptions<TableStorageClientSettings> tableStorageClientSettings,
    // ServiceBusHandler serviceBusHandler
    )
{

    // Important
    // To run it locally it requires Azurite running in Docker
    [Function(nameof(Scheduler))]
    public async Task RunAsync([TimerTrigger("0 * * * * *")] TimerInfo myTimer, FunctionContext context)
    {
        var logger = context.GetLogger<Scheduler>();

        try
        {

        }
        catch (Exception e)
        {
            logger.LogError(e, "Scheduler failed with the following global error: {ErrorMessage}", [e.Message]);

            // Re-throw exception to attempt re-processing according to fault tolerance policy.
            throw;
        }
    }
}