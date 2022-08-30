namespace MauiTubePlayer.IServices;

public interface IDownloadFileService
{
    Task<string> DownloadFileAsync(string fileUrl, string fileName, IProgress<double> progress, CancellationToken token);
}