namespace MauiTubePlayer.ViewModels;

public partial class VideoDetailsPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    private YoutubeVideoDetail theVideo;

    [ObservableProperty]
    private List<YoutubeVideo> similarVideos;

    [ObservableProperty]
    private Channel theChannel;

    [ObservableProperty]
    private bool similarVideosAvailable;

    [ObservableProperty]
    private List<Comment> comments;

    public event EventHandler DownloadCompleted;


    public VideoDetailsPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "TUBE PLAYER";
    }

    public override async void OnNavigatedTo(object parameters)
    {
        var videoID = (string)parameters;

        SetDataLodingIndicators(true);

        this.LoadingText = "Hold on while we load the video details...";

        try
        {
            SimilarVideos = new();
            Comments = new();

            //Get Video Details
            TheVideo = await _appApiService.GetVideoDetails(videoID);

            //Get Channel URL and set in the video
            var channelSearchResult = await _appApiService.GetChannels(TheVideo.Snippet.ChannelId);
            TheChannel = channelSearchResult.Items.First();

            //Find Similar Videos
            if (TheVideo.Snippet.Tags is not null)
            {
                var similarVideosSearchResult = await _appApiService.SearchVideos(TheVideo.Snippet.Tags.First(), "");

                SimilarVideos = similarVideosSearchResult.Items;
                SimilarVideosAvailable = (SimilarVideos?.Count > 0);
            }

            //Get Comments
            var commentsSearchResult = await _appApiService.GetComments(videoID);
            Comments = commentsSearchResult.Items;


            //Raise Data Load completed event to the UI
            this.DataLoaded = true;

            //Raise the Event to notify the UI of download completion
            DownloadCompleted?.Invoke(this, new EventArgs());
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

}

