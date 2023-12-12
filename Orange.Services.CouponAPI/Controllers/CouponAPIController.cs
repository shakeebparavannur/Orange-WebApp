using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orange.Services.CouponAPI.Data;
using Orange.Services.CouponAPI.Models;
using Orange.Services.CouponAPI.Models.Dtos;

namespace Orange.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto response;
        private readonly IMapper mapper;
        public CouponAPIController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            response = new();
            this.mapper = mapper;
        }
        [HttpGet]
        public ResponseDto Get()
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
                response.IsSuccess =false;
                response.Message = ex.Message;
                return response;
            }
           
        }
        [HttpGet("{id}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(x=>x.CouponId == id);
                if (coupon == null)
                {
                    response.IsSuccess =false;
                    response.Message = "Item Not Found";
                    return response;
                }
                response.IsSuccess = true;
                response.Result = coupon;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
           
        }
        [HttpGet("getbycode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(x=>x.CouponCode.ToLower().Equals(code.ToLower()));
                response.IsSuccess=true;
                response.Result = coupon;
                return response;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }
        [HttpPost]
        public ResponseDto Add([FromBody]CouponDto coupon)
        {
            try
            {   Coupon cpn = mapper.Map<Coupon>(coupon);
                _db.Coupons.Add(cpn);
                _db.SaveChanges();
                response.IsSuccess=true;
                response.Result = coupon;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }
        [HttpPut]
        public ResponseDto Update([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon cpn = mapper.Map<Coupon>(coupon);
                _db.Coupons.Update(cpn);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Result = coupon;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }
        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.Find(id);
                if (coupon != null)
                {
                    _db.Coupons.Remove(coupon);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Result = "Successfully Removed";
                    return response;
                }
                response.IsSuccess=false;
                response.Message = "Sorry Item not found";
                return response;
               
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
