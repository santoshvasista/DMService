using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.Interfaces
{
    public interface ILookupEntity : IEntity
    {
        string Name { get; set; }
    }
}
