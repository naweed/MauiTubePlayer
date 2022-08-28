namespace XGENO.Maui.Controls;

public partial class BottomSheet : ContentView
{
    private const uint shortDuration = 250u;
    private const uint regularDuration = shortDuration * 2u;

    public IList<Microsoft.Maui.IView> BottomSheetContent => BottomSheetContentGrid.Children;

    #region Bindable Properties

    public static readonly BindableProperty SheetHeightProperty = BindableProperty.Create(
        nameof(SheetHeight),
        typeof(double),
        typeof(BottomSheet),
        360d,
        BindingMode.OneWay,
        validateValue: (_, value) => value != null);

    public double SheetHeight
    {
        get => (double)GetValue(SheetHeightProperty);
        set => SetValue(SheetHeightProperty, value);
    }

    public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(
        nameof(HeaderText),
        typeof(string),
        typeof(BottomSheet),
        string.Empty,
        BindingMode.OneWay,
        validateValue: (_, value) => value != null);

    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    public static readonly BindableProperty HeaderStyleProperty = BindableProperty.Create(
        nameof(HeaderStyle),
        typeof(Style),
        typeof(BottomSheet),
        new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = 24
                }
            }
        },
        BindingMode.OneWay,
        validateValue: (_, value) => value != null);

    public Style HeaderStyle
    {
        get => (Style)GetValue(HeaderStyleProperty);
        set => SetValue(HeaderStyleProperty, value);
    }

    public static readonly BindableProperty ThemeProperty = BindableProperty.Create(
        nameof(Theme),
        typeof(DisplayTheme),
        typeof(BottomSheet),
        DisplayTheme.Light,
        BindingMode.OneWay,
        validateValue: (_, value) => value != null,
        propertyChanged:
        (bindableObject, oldValue, newValue) =>
        {
            if (newValue is not null && bindableObject is BottomSheet sheet && newValue != oldValue)
            {
                sheet.UpdateTheme();
            }
        });

    public DisplayTheme Theme
    {
        get => (DisplayTheme)GetValue(ThemeProperty);
        set => SetValue(ThemeProperty, value);
    }

    private void UpdateTheme()
    {
        MainContent.BackgroundColor = Color.FromArgb(Theme == DisplayTheme.Dark ? "#333333" : "#FFFFFF");
        MainContent.Stroke = Color.FromArgb(Theme == DisplayTheme.Dark ? "#333333" : "#FFFFFF");
    }

    #endregion

    public BottomSheet()
	{
		InitializeComponent();

        //Set the Theme
        UpdateTheme();

        //Set Close Icon from Local Resource
        CloseBottomSheetButton.Source = ImageSource.FromResource($"XGENO.Maui.Controls.BottomSheet.icnmenuclose.png");
    }

    public async Task OpenBottomSheet()
    {
        this.InputTransparent = false;
        BackgroundFader.IsVisible = true;
        CloseBottomSheetButton.IsVisible = true;

        _ = BackgroundFader.FadeTo(1, shortDuration, Easing.SinInOut);
        await MainContent.TranslateTo(0, 0, regularDuration, Easing.SinInOut);
        _ = CloseBottomSheetButton.FadeTo(1, regularDuration, Easing.SinInOut);
    }

    public async Task CloseBottomSheet()
    {
        await CloseBottomSheetButton.FadeTo(0, shortDuration, Easing.SinInOut);
        _ = MainContent.TranslateTo(0, SheetHeight, shortDuration, Easing.SinInOut);
        await BackgroundFader.FadeTo(0, shortDuration, Easing.SinInOut);

        BackgroundFader.IsVisible = true;
        CloseBottomSheetButton.IsVisible = true;
        this.InputTransparent = true;
    }

    async void CloseBottomSheetButton_Tapped(System.Object sender, System.EventArgs e) =>
        await CloseBottomSheet();
}
