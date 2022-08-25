namespace MauiTubePlayer.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
{
    private string nextToken = string.Empty;
    private string searchTerm = "iPhone 14";

    [ObservableProperty]
    private ObservableCollection<YoutubeVideo> youtubeVideos;


    public StartPageViewModel(IApiService appApiService) : base(appApiService)
	{
		this.Title = "TUBE PLAYER";
	}

    public override async void OnNavigatedTo(object parameters)
    {
        Search();
    }

    private async void Search()
    {
        SetDataLodingIndicators(true);

        LoadingText = "Hold on while we search for Youtube videos...";

        YoutubeVideos = new();

        try
        {
            //Search for videos
            await GetYouTubeVideo();

            this.DataLoaded = true;
        }
        catch (InternetConnectionException iex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "nointernet.png";
        }
        catch (Exception ex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = $"Something went wrong. If the problem persists, plz contact support at {Constants.EmailAddress} with the error message:" + Environment.NewLine + Environment.NewLine + ex.Message;
            ErrorImage = "error.png";
        }
        finally
        {
            SetDataLodingIndicators(false);
        }
    }

    private async Task GetYouTubeVideo()
    {
        //Search the videos
        var videoSearchResult = await _appApiService.SearchVideos(searchTerm, nextToken);

        nextToken = videoSearchResult.NextPageToken;

        //Get Channel URLs
        var channelIDs = string.Join(",",
            videoSearchResult.Items.Select(video => video.Snippet.ChannelId).Distinct());

        var channelSearchResult = await _appApiService.GetChannels(channelIDs);

        //Set Channel URL in the Video
        videoSearchResult.Items.ForEach(video =>
            video.Snippet.ChannelImageURL = channelSearchResult.Items.Where(channel =>
                channel.Id == video.Snippet.ChannelId).First().Snippet.Thumbnails.High.Url);

        //Add the Videos for Display
        YoutubeVideos.AddRange(videoSearchResult.Items);
    }

    [RelayCommand]
    private async void OpenSettingPage()
    {
        await PageService.DisplayAlert("Setting", "This implemention is outside the scope of this course.", "Got it!");
    }
}

