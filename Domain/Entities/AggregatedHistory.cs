using System;

namespace Domain.Entities
{
    public class AggregatedHistory
    {
        public DateTime Hour { get; set; }
        public AggregatedItem AggregatedItems { get; set; }
        
    }
}
