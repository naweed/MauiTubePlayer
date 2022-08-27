namespace MauiTubePlayer.Models;


public class VideoSearchResult
{
    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; set; }

    [JsonPropertyName("pageInfo")]
    public PageInfo PageInfo { get; set; }

    [JsonPropertyName("items")]
    public List<YoutubeVideo> Items { get; set; }
}

public class PageInfo
{
    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("resultsPerPage")]
    public int ResultsPerPage { get; set; }
}

public class YoutubeVideo
{
    [JsonPropertyName("id")]
    public Id Id { get; set; }

    [JsonPropertyName("snippet")]
    public Snippet Snippet { get; set; }
}

public class Id
{
    [JsonPropertyName("videoId")]
    public string VideoId { get; set; }
}

public class Snippet
{
    [JsonPropertyName("publishedAt")]
    public DateTime PublishedAt { get; set; }

    [JsonPropertyName("channelId")]
    public string ChannelId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("thumbnails")]
    public Thumbnails Thumbnails { get; set; }

    [JsonPropertyName("channelTitle")]
    public string ChannelTitle { get; set; }

    public string ChannelImageURL { get; set; }

    //For Details
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    //For Comments
    [JsonPropertyName("topLevelComment")]
    public TopLevelComment TopLevelComment { get; set; }

    [JsonPropertyName("textDisplay")]
    public string TextDisplay { get; set; }

    [JsonPropertyName("authorDisplayName")]
    public string AuthorDisplayName { get; set; }

    [JsonPropertyName("authorProfileImageUrl")]
    public string AuthorProfileImageUrl { get; set; }

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }

}

public class Thumbnails
{
    [JsonPropertyName("medium")]
    public Thumbnail Medium { get; set; }

    [JsonPropertyName("high")]
    public Thumbnail High { get; set; }
}

public class Thumbnail
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}

//Channel related models

public class ChannelSearchResult
{
    [JsonPropertyName("items")]
    public List<Channel> Items { get; set; }
}

public class Channel
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("snippet")]
    public Snippet Snippet { get; set; }

    [JsonPropertyName("statistics")]
    public Statistics Statistics { get; set; }

    public string SubscribersCount
    {
        get => $"{Statistics.SubscriberCount.FormattedNumber()} subscribers";
    }


}

//Video Details related models
public class VideoDetailsResult
{
    [JsonPropertyName("items")]
    public List<YoutubeVideoDetail> Items { get; set; }
}

public class YoutubeVideoDetail
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("snippet")]
    public Snippet Snippet { get; set; }

    //For Details
    [JsonPropertyName("statistics")]
    public Statistics Statistics { get; set; }

    [JsonPropertyName("contentDetails")]
    public ContentDetails ContentDetails { get; set; }

    public string VideoSubtitle
    {
        get => $"{Statistics.ViewCount.FormattedNumber()} views | {Snippet.PublishedAt.ToTimeAgo()}";
    }

    public string LikesCount
    {
        get => Statistics.LikeCount.FormattedNumber();
    }

    public string VideoDuration
    {
        get => ContentDetails.Duration.ToTimeSpan().ToReadableString();
    }

    public string CommentsCount
    {
        get => Statistics.CommentCount.FormattedNumber();
    }

}

public class ContentDetails
{
    [JsonPropertyName("duration")]
    public string Duration { get; set; }
}

public class Statistics
{
    [JsonPropertyName("viewCount")]
    public string ViewCount { get; set; }

    [JsonPropertyName("likeCount")]
    public string LikeCount { get; set; }

    [JsonPropertyName("commentCount")]
    public string CommentCount { get; set; }

    [JsonPropertyName("subscriberCount")]
    public string SubscriberCount { get; set; }

}

//Comments related models
public class CommentsSearchResult
{
    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; set; }

    [JsonPropertyName("items")]
    public List<Comment> Items { get; set; }
}

public class Comment
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("snippet")]
    public Snippet Snippet { get; set; }
}

public class TopLevelComment
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("snippet")]
    public Snippet Snippet { get; set; }
}