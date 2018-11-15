using System;
using System.Linq;

namespace Sperone.Base
{
    public class DocumentId : IComparable<DocumentId>, IComparable
    {
        public long Number { get; set; }

        public Guid Guid { get; set; }

        public long Ticks { get; set; }

        public DocumentId Next() => new DocumentId
        {
            Guid = Guid.NewGuid(),
            Number = Number+1,
            Ticks = DateTime.Now.ToBinary()
        };
        
        public int CompareTo(DocumentId other)
        {
            return Number.CompareTo(other.Number);
        }

        public int CompareTo(object obj)
        {
            if(obj is DocumentId)
            {
                return CompareTo(obj as DocumentId);
            }
            return -1;
        }


        public byte[] ToBytes()
        {
            return BitConverter.GetBytes(Number)
              .Concat(Guid.ToByteArray())
              .Concat(BitConverter.GetBytes(Ticks))
              .ToArray();
        }

        public static DocumentId FromBytes(byte[] bytes)
        {
            return new DocumentId
            {
                Number = BitConverter.ToInt64(bytes),
                Guid = new Guid(bytes.Skip(8).Take(16).ToArray()),
                Ticks = BitConverter.ToInt64(bytes,8+16),
            };
        }
    }
}
