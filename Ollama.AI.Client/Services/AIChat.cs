using Microsoft.Extensions.AI;

public class AIChat
{
    private readonly IChatClient _chatClient;

    public AIChat(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task StartAsync()
    {
        Console.WriteLine("AI Chat - type 'exit' to quit\n");

        var messages = new List<ChatMessage>();

        while (true)
        {
            Console.Write("Prompt: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Trim().ToLower() == "exit")
                break;

            var userMessage = new ChatMessage(ChatRole.User, input);
            messages.Add(userMessage);

            var response = await _chatClient.GetResponseAsync(messages);
            var assistantMessage = response.Text;

            messages.Add(new ChatMessage(ChatRole.Assistant, assistantMessage));

            Console.WriteLine($"AI: {assistantMessage}\n");
        }
    }
}