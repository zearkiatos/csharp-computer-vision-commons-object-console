using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Rest;
using ComputerVisionCommonsObjectConsole.Configuration;

class Program
{
    private static readonly string endpoint = AppConfiguration.azureComputerVisionBaseUrl;
    private static readonly string apiKey = AppConfiguration.azureComputerVisionApiKey;

    static async Task Main(string[] args)
    {
        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(apiKey))
        {
            Endpoint = endpoint
        };

        string imageUrl = AppConfiguration.azureBlobStorageImageUrl;
        try
        {
            var objects = await DetectObjects(client, imageUrl);
            Console.WriteLine("Objects:");
            foreach (var obj in objects)
            {
                Console.WriteLine($"- {obj.ObjectProperty} (Confidence: {obj.Confidence}) at location [Top: {obj.Rectangle.Y}, Left: {obj.Rectangle.X}, Width: {obj.Rectangle.W}, Height: {obj.Rectangle.H}]");
            }
        }
        catch (ComputerVisionErrorResponseException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    static async Task<IList<DetectedObject>> DetectObjects(ComputerVisionClient client, string imageUrl)
    {
        var features = new List<VisualFeatureTypes?> { VisualFeatureTypes.Objects };

        var response = await client.AnalyzeImageAsync(imageUrl, visualFeatures: features);

        return response.Objects;
    }
}

