namespace MauiTubePlayer.ViewControls.Common;

public partial class LoadingIndicator : VerticalStackLayout
{
    //Bindable Properties

    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        "IsBusy",
        typeof(bool),
        typeof(LoadingIndicator),
        false,
        BindingMode.OneWay,
        null,
        SetIsBusy);

    public bool IsBusy
    {
        get => (bool)this.GetValue(IsBusyProperty);
        set => this.SetValue(IsBusyProperty, value);
    }

    private static void SetIsBusy(BindableObject bindable, object oldValue, object newValue)
    {
        LoadingIndicator control = bindable as LoadingIndicator;

        control.IsVisible = (bool)newValue;
        control.actIndicator.IsRunning = (bool)newValue;
    }


    public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
        "LoadingText",
        typeof(string),
        typeof(LoadingIndicator),
        string.Empty,
        BindingMode.OneWay,
        null,
        SetLoadingText);

    public string LoadingText
    {
        get => (string)this.GetValue(LoadingTextProperty);
        set => this.SetValue(LoadingTextProperty, value);
    }

    private static void SetLoadingText(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as LoadingIndicator).lblLoadingText.Text = (string)newValue;

    public LoadingIndicator()
	{
		InitializeComponent();
	}
}
