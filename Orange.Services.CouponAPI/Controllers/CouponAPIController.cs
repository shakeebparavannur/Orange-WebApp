using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orange.Services.CouponAPI.Data;
using Orange.Services.CouponAPI.Models;
using Orange.Services.CouponAPI.Models.Dtos;

namespace Orange.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        protected ResponseDto response;
        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            response = new();
        }
        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                //return objList;
                response.IsSuccess = true;
                response.Result = objList;
                return response;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        [HttpGet("{id}")]
        public object GetById(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(x => x.CouponId == id);
                return coupon;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
