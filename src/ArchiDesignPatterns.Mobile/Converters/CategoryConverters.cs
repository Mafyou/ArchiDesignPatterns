namespace ArchiDesignPatterns.Mobile.Converters;

public class CategoryToColorConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values is null || values.Length == 0 || values[0] is not string category)
            return Colors.Gray;

        return category?.ToLower() switch
        {
            "creational" or "créationnel" => Color.FromArgb("#10B981"),
            "structural" or "structurel" => Color.FromArgb("#3B82F6"),
            "behavioral" or "comportemental" => Color.FromArgb("#F59E0B"),
            _ => Color.FromArgb("#6366F1")
        };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class CategoryToIconConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values is null || values.Length == 0 || values[0] is not string category)
            return "📐";

        return category?.ToLower() switch
        {
            "creational" or "créationnel" => "🏗️",
            "structural" or "structurel" => "🔧",
            "behavioral" or "comportemental" => "⚡",
            _ => "📐"
        };
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class StringToBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return !string.IsNullOrWhiteSpace(value as string);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
