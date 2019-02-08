using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? ModifiedById { get; set; }
    }
}
