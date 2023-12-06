using AutoMapper;
using Orange.Services.CouponAPI.Models;
using Orange.Services.CouponAPI.Models.Dtos;

namespace Orange.Services.CouponAPI.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Coupon,CouponDto>().ReverseMap();
        }
    }
}
