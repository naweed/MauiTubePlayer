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

    //[JsonPropertyName("statistics")]
    //public Statistics Statistics { get; set; }

}