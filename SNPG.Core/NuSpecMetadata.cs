using System.Collections.Generic;

namespace SNPG.Core
{
    public class NuspecMetadata
    {
        public string Id { get; set; }

        public string Version { get; set; }

        public string Authors { get; set; }

        public string Description { get; set; }

        public List<string> ReferenceList { get; set; }
    }
}
