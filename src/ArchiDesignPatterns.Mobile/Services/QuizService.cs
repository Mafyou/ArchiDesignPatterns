namespace ArchiDesignPatterns.Mobile.Services;

public class QuizService(IChatCompletionService chat) : IQuizService
{
    private readonly IChatCompletionService _chat = chat;

    public async Task<string> GenerateQuestionAsync(string topic, CancellationToken ct = default)
    {
        var chat = new ChatHistory();
        chat.AddSystemMessage($"Tu génères une question à choix multiple courte (4 propositions A-D) sur le sujet: {topic} en français. Format: QUESTION\\nA) ...\\nB) ...\\nC) ...\\nD) ...");
        var result = await _chat.GetChatMessageContentAsync(chat, cancellationToken: ct);
        return result.Content ?? string.Empty;
    }

    public async Task<string> EvaluateAnswerAsync(string topic, string question, string answer, CancellationToken ct = default)
    {
        var chat = new ChatHistory();
        chat.AddSystemMessage($"Tu évalues la réponse fournie à la question suivante pour le sujet: {topic}. Tu réponds juste par Correct ou Incorrect et une brève explication.");
        chat.AddUserMessage($"Question:{question}\\nRéponse proposée:{answer}");
        var result = await _chat.GetChatMessageContentAsync(chat, cancellationToken: ct);
        return result.Content ?? string.Empty;
    }
}
