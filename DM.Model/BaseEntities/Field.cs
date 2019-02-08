using DM.Model;

namespace Titan.Model.BaseEntities
{
    public class Field: Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsRequired { get; set; }
        public bool IsInitialized { get; set; }
        public bool AllowMultiSelect { get; set; }
        public bool IsMainField { get; set; }
    }
}
