using AutoMapper;
using Chef.Common.DTO.Instruction;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class InstructionProfile : Profile
    {
        public InstructionProfile()
        {
            CreateMap<Instruction, InstructionDto>();

            CreateMap<InstructionDto, Instruction>();
        }
    }
}
