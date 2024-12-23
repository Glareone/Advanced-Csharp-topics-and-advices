using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;

namespace AzureFunction.Scheduler.ServiceBus;

public class ServiceBusHandler(ServiceBusSender serviceBusSender, ILogger<ServiceBusHandler> log)
{
    public async Task SendRecordsInBatchesAsync(IList<Record> records, int batchSize = 30)
    {
        var totalRecords = records.Count;
        var totalBatches = (int)Math.Ceiling((double)totalRecords / batchSize);

        for (var i = 0; i < totalBatches; i++)
        {
            var batch = records.Skip(i * batchSize).Take(batchSize).ToList();
            await SendMessageBatchAsync(batch);
        }
    }

    private async Task SendMessageBatchAsync(IEnumerable<Record> csvMetadataBatch)
    {
        try
        {
            ServiceBusMessageBatch messageBatch = await serviceBusSender.CreateMessageBatchAsync();

            // Add CSV Metadata to Batches and sendMessages as batches to Service Bus Queue
            foreach (var csvMetadata in csvMetadataBatch)
            {
                var json = JsonSerializer.Serialize(csvMetadata);
                if (!messageBatch.TryAddMessage(new ServiceBusMessage(json)))
                {
                    // If message is too large for the batch
                    // Immediately send the MessageBatch, Dispose it
                    // Create new MessageBatch and add the message there
                    await serviceBusSender.SendMessagesAsync(messageBatch);

                    // Dispose the current batch before creating a new one
                    messageBatch.Dispose();

                    // Start a new batch
                    // Ensure the message that did not fit in the previous batch is added to the new batch
                    messageBatch = await serviceBusSender.CreateMessageBatchAsync();
                    if (!messageBatch.TryAddMessage(new ServiceBusMessage(json)))
                    {
                        throw new Exception("Message is too large to fit in an empty batch");
                    }
                }
            }

            // Send the final batch, if it contains any messages
            if (messageBatch.Count > 0)
            {
                await serviceBusSender.SendMessagesAsync(messageBatch);
            }

            // Ensure the batch is disposed after use
            // Using is not used because there is an issue with Immutable Message
            messageBatch.Dispose();
        }
        catch (Exception e)
        {
            log.LogError(e, "One of message batches cannot be sent to the Service Bus, error: {Error}", e.Message);
            throw;
        }

    }
}

public class Record
{
    public string Str { get; set; }
}