using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs.Models;


namespace Sensor.API.Endpoints.Sensor;

    [ApiController]
    [Route("[controller]")]
    public class BlobController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public BlobController()
        {
            // Initialize Azure Storage connection string and container name
            _connectionString = "DefaultEndpointsProtocol=https;AccountName=iotstorage100;AccountKey=am+1epYnj/NyL5J05vAqRbEJhb41XKH2A90IRBmdScurOIoT/i+ZOLbsuMJy/z1jJ5CZah2zndkL+AStUl1ytA==;EndpointSuffix=core.windows.net";
            _containerName = "containermediot";
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            try
            {
                // Create a BlobServiceClient object which will be used to create a container client
                BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

                // Get a reference to a container
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                // Get a reference to a blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                // Download the blob's contents
                BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();

                // Read the blob's contents into a string
                string blobContent;
                using (var reader = new StreamReader(blobDownloadInfo.Content))
                {
                    blobContent = await reader.ReadToEndAsync();
                }

                // Return the blob's contents
                return Ok(blobContent);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

