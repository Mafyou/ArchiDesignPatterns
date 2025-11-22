namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class ChainOfResponsibilityPatternPage : ContentPage
{
    public ChainOfResponsibilityPatternPage()
    {
        InitializeComponent();
    }

    private void OnHandleRequestClicked(object sender, EventArgs e)
    {
        // Create chain of handlers
        var lowHandler = new LowPriorityHandler();
        var mediumHandler = new MediumPriorityHandler();
        var highHandler = new HighPriorityHandler();

        // Set up chain
        lowHandler.SetNext(mediumHandler);
        mediumHandler.SetNext(highHandler);

        // Test requests
        var results = new System.Text.StringBuilder();
        results.AppendLine(lowHandler.Handle("Demande priorité faible"));
        results.AppendLine(lowHandler.Handle("Demande priorité moyenne"));
        results.AppendLine(lowHandler.Handle("Demande priorité élevée"));

        ResultLabel.Text = results.ToString();
    }

    // Base handler
    private abstract class RequestHandler
    {
        private RequestHandler? _nextHandler;

        public void SetNext(RequestHandler handler)
        {
            _nextHandler = handler;
        }

        public virtual string Handle(string request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            return "Demande non traitée";
        }
    }

    // Concrete handlers
    private class LowPriorityHandler : RequestHandler
    {
        public override string Handle(string request)
        {
            if (request.Contains("faible"))
            {
                return $"GestionnairePrioritéFaible : Traité '{request}'";
            }
            return base.Handle(request);
        }
    }

    private class MediumPriorityHandler : RequestHandler
    {
        public override string Handle(string request)
        {
            if (request.Contains("moyenne"))
            {
                return $"GestionnairePrioritéMoyenne : Traité '{request}'";
            }
            return base.Handle(request);
        }
    }

    private class HighPriorityHandler : RequestHandler
    {
        public override string Handle(string request)
        {
            if (request.Contains("élevée"))
            {
                return $"GestionnairePrioritéÉlevée : Traité '{request}'";
            }
            return base.Handle(request);
        }
    }
}