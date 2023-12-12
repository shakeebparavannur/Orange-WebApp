﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrangeWeb.Mode;
using OrangeWeb.Models;
using OrangeWeb.Services.IServices;

namespace OrangeWeb.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = new();
            ResponseDto response = await _couponService.GetAllCouponAsync();
            if(response !=  null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            
            return View(list);
        }
    }
}
