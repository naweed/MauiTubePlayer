

namespace MauiTubePlayer.IServices;

public interface IApiService
{
    Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "");
}

