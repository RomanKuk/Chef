using AutoMapper;
using Chef.Common.DTO.Review;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>();

            CreateMap<ReviewDto, Review>();
            CreateMap<NewReviewDto, Review>();
        }
    }
}
