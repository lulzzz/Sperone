using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using Sperone.Base;
using Sperone.Storage;

namespace Sperone.Clustering.Collections
{
    class CollectionGrain<T> : Grain, ICollectionGrain
    {
        private readonly ILogger _logger;
        private readonly ObjectStorage<T> _storage;

        public CollectionGrain(ILogger<CollectionGrain<T>> logger)
        {
            _logger = logger;
            _storage = new ObjectStorage<T>(Configuration.Default, new Collection{ Name = this.GetPrimaryKeyString() });
        }

        public Task<DocumentId> Store(T obj)
        {
            return Task.FromResult(_storage.Save(obj));
        }
    }
}
