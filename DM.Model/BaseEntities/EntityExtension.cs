using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using DM.Model;

namespace DM.Model.BaseEntities
{
    public class EntityExtension : TenantAwareEntity
    {
        public IEnumerable<EntityExtensionField> ExtensionFields { get; set; }
        [IgnoreDataMember]
        public dynamic ExtensionFieldsObject { get; set; }
    }
}