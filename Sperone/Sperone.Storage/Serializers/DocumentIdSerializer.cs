using DataTanker;
using Sperone.Base;

namespace Sperone.Storage.Serializers
{
    class DocumentIdSerializer : ISerializer<DocumentId>
    {
        public DocumentId Deserialize(byte[] bytes) => DocumentId.FromBytes(bytes);

        public byte[] Serialize(DocumentId obj) => obj.ToBytes();

        public static readonly DocumentIdSerializer Singleton = new DocumentIdSerializer();
    }
}
