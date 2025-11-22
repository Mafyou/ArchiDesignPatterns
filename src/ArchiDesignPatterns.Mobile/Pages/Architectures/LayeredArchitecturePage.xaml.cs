using Microsoft.Maui.Controls;
using ArchiDesignPatterns.Mobile.ViewModels;

namespace ArchiDesignPatterns.Mobile.Pages.Architectures
{
    public partial class LayeredArchitecturePage : ContentPage
    {
        private BusinessLayer _business = new();
        public LayeredArchitecturePage()
        {
            InitializeComponent();
            BindingContext = new LayeredArchitectureViewModel();
        }

        private void OnCallServiceClicked(object sender, EventArgs e)
        {
            var result = _business.Process();
            ResultLabel.Text = $"Résultat : {result}";
        }

        public class DataLayer { public string GetData() => "Donnée"; }
        public class BusinessLayer { private DataLayer _dl = new(); public string Process() => _dl.GetData() + " traitée"; }
        public class PresentationLayer { public void Show(string d) { /* Affichage */ } }
    }
}
