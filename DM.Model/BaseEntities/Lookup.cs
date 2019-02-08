using System;
using DM.Model;
using DM.Model.Interfaces;

namespace Titan.Model.BaseEntities
{  
    public class Lookup: Entity, ILookupEntity
    {
        public string Name { get; set; }
        public Guid UserDeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
