using DataTanker;
using DataTanker.Settings;
using Sperone.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sperone.Indexing
{
    public class Storage<TValue>
    {
        static StorageFactory factory = new StorageFactory();

        DocumentId topId;
        IBPlusTreeKeyValueStorage<ComparableKeyOf<DocumentId>, ValueOf<TValue>> storage;

        public Storage()
        {
            Directory.CreateDirectory("./test");
            var settings = BPlusTreeStorageSettings.Default(32);
            storage = factory.CreateBPlusTreeStorage<DocumentId, TValue>(settings);
            storage.OpenOrCreate("./test");

            topId = storage.Max() ?? new DocumentId();
        }

        public IEnumerable<DocumentId> All()
        {
            var id = new DocumentId();

            do
            {
                id = storage.NextTo(id);
                yield return id; 

            } while (id!=null);
        }

        public DocumentId Save(TValue value)
        {
            var next = topId.Next();
            storage.Set(next, value);
            topId = next;

            storage.Flush();
            return topId;
        }
    }
}
