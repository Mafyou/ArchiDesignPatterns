namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class FactoryPatternPage : ContentPage
{
    private string? _selectedVehicleType;

    public FactoryPatternPage(FactoryPatternViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnTypeSelected(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedIndex >= 0)
        {
            var selected = picker.Items[picker.SelectedIndex];
            _selectedVehicleType = selected.Split(' ')[0]; // Extract "Voiture", "Vélo", or "Avion"
        }
    }

    private void OnCreateObjectClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_selectedVehicleType))
        {
            ResultLabel.Text = "Please select a vehicle type first.";
            return;
        }

        var factory = new VehicleFactory();
        var vehicle = factory.CreateVehicle(_selectedVehicleType);
        ResultLabel.Text = vehicle.Move();
    }

    // Product Interface
    private interface IVehicle
    {
        string Move();
    }

    // Concrete Products
    private class Car : IVehicle
    {
        public string Move() => "🚗 The car is driving on the road";
    }

    private class Bike : IVehicle
    {
        public string Move() => "🚲 The bike is pedaling down the street";
    }

    private class Plane : IVehicle
    {
        public string Move() => "✈️ The plane is flying through the sky";
    }

    // Factory
    private class VehicleFactory
    {
        public IVehicle CreateVehicle(string type)
        {
            return type switch
            {
                "Voiture" => new Car(),
                "Vélo" => new Bike(),
                "Avion" => new Plane(),
                _ => throw new ArgumentException($"Unknown vehicle type: {type}")
            };
        }
    }
}
