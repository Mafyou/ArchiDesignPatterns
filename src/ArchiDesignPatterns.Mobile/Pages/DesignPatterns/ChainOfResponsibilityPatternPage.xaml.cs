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
        results.AppendLine(lowHandler.Handle("Low priority request"));
        results.AppendLine(lowHandler.Handle("Medium priority request"));
        results.AppendLine(lowHandler.Handle("High priority request"));

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
            return "Request not handled";
        }
    }

    // Concrete handlers
    private class LowPriorityHandler : RequestHandler
    {
        public override string Handle(string request)
        {
            if (request.Contains("Low"))
            {
                return $"LowPriorityHandler: Handled '{request}'";
            }
            return base.Handle(request);
        }
    }

    private class MediumPriorityHandler : RequestHandler
    {
        public override string Handle(string request)
        {
            if (request.Contains("Medium"))
            {
                return $"MediumPriorityHandler: Handled '{request}'";
            }
            return base.Handle(request);
        }
    }

    private class HighPriorityHandler : RequestHandler
    {
        public override string Handle(string request)
        {
            if (request.Contains("High"))
            {
                return $"HighPriorityHandler: Handled '{request}'";
            }
            return base.Handle(request);
        }
    }
}