namespace ArchiDesignPatterns.Mobile.Abstractions;

public interface IQuizService
{
    Task<string> GenerateQuestionAsync(string topic, CancellationToken ct = default);
    Task<string> EvaluateAnswerAsync(string topic, string question, string answer, CancellationToken ct = default);
}