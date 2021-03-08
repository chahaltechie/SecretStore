using System.Collections.Generic;

namespace Infrastructure.Data.CosmosDb.Configuration
{
    public class CosmosDbSettings
    {
        public string EndPointUrl { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseName { get; set; }
        public List<ContainerInfo> Containers { get; set; }
    }
    public class ContainerInfo
    {
        /// <summary>
        ///     Container Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     Container partition Key
        /// </summary>
        public string PartitionKey { get; set; }
    }
}