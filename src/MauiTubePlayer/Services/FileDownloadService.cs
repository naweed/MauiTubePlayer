namespace MauiTubePlayer.Services;

public class FileDownloadService : IDownloadFileService
{
    public async Task<string> DownloadFileAsync(string fileUrl, string fileName, IProgress<double> progress, CancellationToken token)
    {
        try
        {
            var _client = new HttpClient();
            int bufferSize = 4095;

            // Step 1 : Get call
            var response = await _client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead, token);

            response.EnsureSuccessStatusCode();

            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            // Step 2 : Get total of data
            var totalData = response.Content.Headers.ContentLength.GetValueOrDefault(-1L);


            // Step 3 : Download data
            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, bufferSize))
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var totalRead = 0L;
                    var buffer = new byte[bufferSize];
                    var isMoreDataToRead = true;

                    do
                    {
                        token.ThrowIfCancellationRequested();

                        var read = await stream.ReadAsync(buffer, 0, buffer.Length, token);

                        if (read == 0)
                        {
                            isMoreDataToRead = false;
                        }
                        else
                        {
                            // Write data on disk.
                            await fileStream.WriteAsync(buffer, 0, read);

                            totalRead += read;

                            progress.Report((totalRead * 1d) / (totalData * 1d));
                        }
                    }
                    while (isMoreDataToRead);
                }
            }

            //Return the downloaded file path
            return filePath;
        }
        catch (Exception e)
        {
            // Manage the exception as you need here.
        }

        return "";
    }
}
