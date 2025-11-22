namespace ArchiDesignPatterns.Mobile.ViewModels;

// public partial class QuizViewModel(IQuizService quiz) : ObservableObject
public partial class QuizViewModel : ObservableObject
{
    // private readonly IQuizService _quiz = quiz;

    [ObservableProperty]
    private string _topic = string.Empty;

    [ObservableProperty]
    private string _question = string.Empty;

    [ObservableProperty]
    private string _answer = string.Empty;

    [ObservableProperty]
    private string _result = string.Empty;

    [RelayCommand]
    private async Task GenerateAsync(CancellationToken stoppingToken)
    {
        if (string.IsNullOrWhiteSpace(Topic)) { Question = "Veuillez entrer un sujet."; return; }
        Question = "Génération...";
        // var reponse = await _quiz.GenerateQuestionAsync(Topic, stoppingToken);
        // Question = reponse.Replace("\n", Environment.NewLine);
        Result = string.Empty;
    }

    [RelayCommand]
    private async Task EvaluateAsync(CancellationToken stoppingToken)
    {
        if (string.IsNullOrWhiteSpace(Question)) { Result = "Aucune question."; return; }
        if (string.IsNullOrWhiteSpace(Answer)) { Result = "Veuillez entrer une réponse."; return; }
        Result = "Évaluation...";
        // var response = await _quiz.EvaluateAnswerAsync(Topic, Question, Answer, stoppingToken);
        // Result = response.Replace("\n", Environment.NewLine);
    }
}