using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.Entities
{
    public class LookupConstantViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
