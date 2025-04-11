using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

ServiceConfigurator.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

var runMode = builder.Configuration["RunMode"];

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

    