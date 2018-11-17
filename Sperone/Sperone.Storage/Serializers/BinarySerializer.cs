using DataTanker;

namespace Sperone.Storage.Serializers
{
    class BinarySerializer : ISerializer<byte[]>
    {
        public byte[] Deserialize(byte[] bytes) => bytes;

        public byte[] Serialize(byte[] obj) => obj;

        public static readonly BinarySerializer Singleton = new BinarySerializer();
    }
}
