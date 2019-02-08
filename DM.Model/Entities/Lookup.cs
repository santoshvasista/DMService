using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.Entities
{
    public class Lookup
    {
        public Guid Id { get; set; }
        public Guid LookupTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
