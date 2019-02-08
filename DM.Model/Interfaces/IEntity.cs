using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        Guid CreatedById { get; set; }
        DateTime CreatedOn { get; set; }
        Guid? ModifiedById { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
