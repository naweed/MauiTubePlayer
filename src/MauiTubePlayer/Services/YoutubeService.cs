namespace MauiTubePlayer.Services;

public class YoutubeService : RestServiceBase, IApiService
{
	public YoutubeService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
	{
        SetBaseURL(Constants.ApiServiceURL);
	}

    public async Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "")
    {
        var resourceUri = $"search?part=snippet&maxResults=10&type=video&key={Constants.ApiKey}&q={WebUtility.UrlEncode(searchQuery)}"
            +
            (!string.IsNullOrEmpty(nextPageToken)? $"&pageToken={nextPageToken}" : "");

        var result = await GetAsync<VideoSearchResult>(resourceUri, 4);

        return result;
    }

    public async Task<ChannelSearchResult> GetChannels(string channelIDs)
    {
        var resourceUri = $"channels?part=snippet,statistics&maxResults=10&key={Constants.ApiKey}&id={channelIDs}";

        var result = await GetAsync<ChannelSearchResult>(resourceUri, 4); //Cached for 4 hours

        return result;
    }
}

