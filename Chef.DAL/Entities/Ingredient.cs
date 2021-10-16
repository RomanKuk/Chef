using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public VolumeMetric VolumeMetric { get; set; }
    }
}
