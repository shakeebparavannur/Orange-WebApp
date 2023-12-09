using OrangeWeb.Mode;
using OrangeWeb.Models;
using OrangeWeb.Services.IServices;

namespace OrangeWeb.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public Task<ResponseDto> CreateCouponAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetCouponAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetCouponByIdAsync(int couponId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
