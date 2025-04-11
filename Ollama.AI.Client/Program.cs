using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

ServiceConfigurator.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

var runMode = builder.Configuration["RunMode"];

if (string.IsNullOrWhiteSpace(runMode))
{
    Console.WriteLine("Choose mode:");
    Console.WriteLine("1. Chat");
    Console.WriteLine("2. Image Analysis");
    Console.Write("Enter 1 or 2: ");
    var choice = Console.ReadLine()?.Trim();
    runMode = choice == "1" ? "Chat" : "ImageAnalysis";
}

if (runMode == "Chat")
{
    var chatConsole = app.Services.GetRequiredService<AIChat>();
    await chatConsole.StartAsync();
}

if (runMode == "ImageAnalysis")
{
    var analyzer = app.Services.GetRequiredService<AIImageAnalyzer<TrafficCamResult>>();
    await analyzer.AnalyzeImagesAsync(
        "Images", "*.jpg",
        (result, name) =>
        {
            var updated = result with { CameraName = name };
            return updated.ToString();
        });
}

    