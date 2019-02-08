using System;
using System.Collections.Generic;
using System.Text;
using Titan.Model.BaseEntities;

namespace DM.Model.BaseEntities
{
    public class EntityExtensionField : Field
    {
        public EntityExtensionField()
        {
            IsMainField = false;
        }
    }

    public class EntityField : Field
    {
    }
}
