using Domain.Common;
using Domain.Entities;

namespace Infrastructure.Data.CosmosDb.Models
{
    public class Test : Secret
    {
        public string PK { get; set; }  
    }
}