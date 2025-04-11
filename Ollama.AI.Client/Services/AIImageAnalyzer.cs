using Microsoft.Extensions.AI;

public class AIImageAnalyzer<T> where T : class
{
    private readonly IChatClient _chatClient;

    public AIImageAnalyzer(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task AnalyzeImagesAsync(string directory, string filePattern, Func<T, string, string> formatter)
    {
        foreach (var filePath in Directory.GetFiles(directory, filePattern))
        {
            var name = Path.GetFileNameWithoutExtension(filePath);

            var message = CreateImageMessage(name, File.ReadAllBytes(filePath));

            var response = await _chatClient.GetResponseAsync<T>(message);

            Console.WriteLine(formatter(response.Result, name));
            Console.WriteLine();
        }
    }

    private ChatMessage CreateImageMessage(string name, byte[] imageBytes)
    {
        var message = new ChatMessage(ChatRole.User,
            $"""
            What's in this image {name}?
            Extract the information on the image, even if the image is a bit blurry.
            """);

        message.Contents.Add(new DataContent(imageBytes, "image/jpg"));
        return message;
    }
}
