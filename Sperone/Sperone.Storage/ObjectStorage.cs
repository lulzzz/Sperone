using System.Collections.Generic;
using System.IO;
using DataTanker;
using Sperone.Base;
using Sperone.Storage.Serializers;

namespace Sperone.Storage
{
    public class ObjectStorage<T>
    {
        private static readonly StorageFactory Factory = new StorageFactory();

        DocumentId _topId;
        readonly IBPlusTreeKeyValueStorage<ComparableKeyOf<DocumentId>, ValueOf<T>> _storage;

        public ObjectStorage(Configuration configuration, Collection collection)
        {
            var dirPath = Path.Combine(configuration.DataPath, collection.Name);
            Directory.CreateDirectory(dirPath);

            var settings = Utils.StorageSettings(configuration,32);
            _storage = Factory.CreateBPlusTreeStorage(DocumentIdSerializer.Singleton,new NativeSerializer<T>(), settings);
            _storage.OpenOrCreate(dirPath);

            _topId = _storage.Max() ?? new DocumentId();
        }

        public IEnumerable<DocumentId> All()
        {
            var id = new DocumentId();

            do
            {
                id = _storage.NextTo(id);
                yield return id; 

            } while (id!=null);
        }

        public DocumentId Save(T value)
        {
            var next = _topId.Next();
            _storage.Set(next, value);
            _topId = next;

            _storage.Flush();
            return _topId;
        }
    }
}
