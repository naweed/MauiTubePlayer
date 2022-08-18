
namespace Maui.Apps.Framework.Extensions;

public class EnumerationContainsElementConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        (value as IEnumerable<object>)?.Count() > 0;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}

