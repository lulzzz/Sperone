using System;

namespace Sperone.Base
{
    public class Configuration
    {
        public static Configuration Default => new Configuration
        {
            DataPath = "./data",

            //Indexing engine
            MaxCachedPages = 3000,
            MaxDirtyPages = 1000,
            PageSize = 4096,
            ForcedWrites = false,
            MaxKeySize = 500,
            MaxEmptyPages = 100,
            AutoFlushInterval = 100000,
            AutoFlushTimeout = TimeSpan.Zero
        };

        public string DataPath { get; set; }

        //Indexing engine
        public int MaxEmptyPages { get; set; }
        public TimeSpan AutoFlushTimeout { get; set; }
        public int AutoFlushInterval { get; set; }
        public int MaxKeySize { get; set; }
        public bool ForcedWrites { get; set; }
        public int PageSize { get; set; }
        public int MaxDirtyPages { get; set; }
        public int MaxCachedPages { get; set; }
    }
}
