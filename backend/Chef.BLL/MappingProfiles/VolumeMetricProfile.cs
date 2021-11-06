using AutoMapper;
using Chef.Common.DTO.VolumeMetric;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class VolumeMetricProfile : Profile
    {
        public VolumeMetricProfile()
        {
            CreateMap<VolumeMetric, VolumeMetricDto>();

            CreateMap<VolumeMetricDto, VolumeMetric>();
        }
    }
}
