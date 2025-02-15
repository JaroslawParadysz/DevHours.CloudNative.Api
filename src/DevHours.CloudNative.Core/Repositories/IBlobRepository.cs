using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DevHours.CloudNative.Core.Repositories
{
    public interface IBlobRepository<TKey>
    {
        IAsyncEnumerable<string> ListNamesAsync(TKey key, CancellationToken token = default);
        Task<(Stream Content, string ContentType)> DownloadAsync(TKey key, CancellationToken token = default);
        Task UploadAsync(TKey key, Stream contents, string type, CancellationToken token = default);
        Task RemoveAsync(TKey key, CancellationToken token = default);
    }
}