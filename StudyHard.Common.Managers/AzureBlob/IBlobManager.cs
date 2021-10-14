using Azure;
using Azure.Storage.Blobs.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Common.Managers.AzureBlob
{
    public interface IBlobManager
    {
        Task UploadAsync(Stream stream, string blobName, string containerName, CancellationToken cancellationToken);
        Task<Stream> GetAsync(string fileName, string containerName, CancellationToken cancellationToken);
        Task DeleteAsync(string fileName, string containerName, CancellationToken cancellationToken);
    }
}