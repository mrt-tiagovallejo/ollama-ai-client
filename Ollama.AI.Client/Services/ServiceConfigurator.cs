using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public static class ServiceConfigurator
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AISettings>(configuration.GetSection("Ai"));

        services.AddSingleton<IChatClient>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<AISettings>>().Value;
            return new OllamaChatClient(new Uri(options.BaseUri), options.ModelName);
        });

        services.AddTransient(typeof(AIImageAnalyzer<>));
        services.AddTransient<AIChat>();
    }
}