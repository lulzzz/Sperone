using System.Threading.Tasks;

namespace Sperone.Clustering
{
    /// <summary>
    /// Orleans grain communication interface IHello
    /// </summary>
    public interface ICollectionGrain : Orleans.IGrainWithStringKey
    {
    }
}
