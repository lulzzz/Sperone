using DataTanker.Settings;
using Sperone.Base;

namespace Sperone.Storage
{
    class Utils
    {
        public static BPlusTreeStorageSettings StorageSettings(Configuration configuration, int keySize)
        {
            return new BPlusTreeStorageSettings()
            {
                AutoFlushInterval = configuration.AutoFlushInterval,
                AutoFlushTimeout = configuration.AutoFlushTimeout,
                CacheSettings = new CacheSettings
                {
                    MaxCachedPages = configuration.MaxCachedPages,
                    MaxDirtyPages = configuration.MaxDirtyPages
                },
                ForcedWrites = configuration.ForcedWrites,
                MaxEmptyPages = configuration.MaxEmptyPages,
                MaxKeySize = keySize,
                PageSize = (PageSize) configuration.PageSize,
            };
        }
    }
}
