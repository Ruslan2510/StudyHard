using Azure.Storage.Blobs;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace StudyHard.Common.Managers.AzureBlob
{
    public class BlobManager : IBlobManager
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobManager(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task UploadAsync(Stream stream, string blobName, string containerName, CancellationToken cancellationToken)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(stream, cancellationToken);
        }

        public async Task<Stream> GetAsync(string fileName, string containerName, CancellationToken cancellationToken)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            var response = await blobClient.DownloadAsync(cancellationToken);
            return response.Value.Content;
        }

        public async Task DeleteAsync(string fileName, string containerName, CancellationToken cancellationToken)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        }
    }
}