namespace MauiTubePlayer.Views.Base;

public class ViewBase<TViewModel> : PageBase where TViewModel : AppViewModelBase
{
    protected bool _isLoaded = false;

    protected TViewModel ViewModel { get; set; }
    protected object ViewModelParameters { get; set; }

    protected event EventHandler ViewModelInitialized;

    public ViewBase() : base()
    {
    }

    public ViewBase(object initParameters) : base() =>
        ViewModelParameters = initParameters;

    protected override void OnAppearing()
    {
        //Initialize only if page is not loaded previously
        if (!_isLoaded)
        {
            base.OnAppearing();

            BindingContext = ViewModel = ServiceHelpers.GetService<TViewModel>();

            ViewModel.NavigationService = this.Navigation;
            ViewModel.PageService = this;

            //Raise Event to notify that ViewModel has been Initialized
            ViewModelInitialized?.Invoke(this, new EventArgs());

            //Navigate to View Model's OnNavigatedTo method
            ViewModel.OnNavigatedTo(ViewModelParameters);

            _isLoaded = true;
        }
    }

}

