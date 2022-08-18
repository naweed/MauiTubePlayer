
using System.Net;
using Maui.Apps.Framework.Services;
using MauiTubePlayer.IServices;
using MonkeyCache;

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
}

