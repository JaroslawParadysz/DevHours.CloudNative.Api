using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DevHours.CloudNative.Core.Repositories;

namespace DevHours.CloudNative.Core.Services
{
    public class RoomImagesService
    {
        private readonly IBlobRepository<string> imagesRepository;

        public RoomImagesService(IBlobRepository<string> imagesRepository)
            => this.imagesRepository = imagesRepository;

        public IAsyncEnumerable<string> ListNamesAsync(int roomId, CancellationToken token = default)
            => imagesRepository.ListNamesAsync($"{roomId}", token);

        public async Task<(Stream, string)> DownloadAsync(int roomId, Guid imageId, CancellationToken token = default)
            => await imagesRepository.DownloadAsync($"{roomId}/{imageId}", token);

        public async Task<string> UploadAsync(int roomId, Guid imageId, Stream contents, string type, CancellationToken token = default)
        {
            await imagesRepository.UploadAsync($"{roomId}/{imageId}", contents, type, token);
            return $"{roomId}/{imageId}";
        }

        public Task RemoveAsync(int roomId, Guid imageId, CancellationToken token = default)
            => imagesRepository.RemoveAsync($"{roomId}/{imageId}", token);
    }
}