namespace MauiTubePlayer.IServices;

public interface IApiService
{
    Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "");
    Task<ChannelSearchResult> GetChannels(string channelIDs);
    Task<YoutubeVideoDetail> GetVideoDetails(string videoID);
    Task<CommentsSearchResult> GetComments(string videoID);
}

