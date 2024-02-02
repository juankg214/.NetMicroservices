using AutoMapper;
using Mago.Services.CouponApi.Data;
using Mago.Services.CouponApi.Models;
using Mago.Services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mago.Services.CouponApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CouponApiController : ControllerBase
	{
		private readonly AppDbContext _db;
		private IMapper _mapper;

		public CouponApiController(AppDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		[HttpGet]
		public ResponseDto<IEnumerable<CouponDto>> Get()
		{
			var response = new ResponseDto<IEnumerable<CouponDto>>();
			try
			{
				IEnumerable<Coupon> objList = _db.Coupons.ToList();
				response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[HttpGet]
		[Route("{id:int}")]
		public ResponseDto<CouponDto> Get(int id)
		{
			var response = new ResponseDto<CouponDto>();
			try
			{
				Coupon coupon = _db.Coupons.First(c => c.CouponId == id);
				response.Result = _mapper.Map<CouponDto>(coupon);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[HttpGet]
		[Route("GetByCode/{code}")]
		public ResponseDto<CouponDto> Get(string code)
		{
			var response = new ResponseDto<CouponDto>();
			try
			{
				Coupon coupon = _db.Coupons.First(c => c.CouponCode.ToLower() == code.ToLower());
				response.Result = _mapper.Map<CouponDto>(coupon);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[HttpPost]
		public ResponseDto<CouponDto> Post([FromBody] CouponDto coupon)
		{
			var response = new ResponseDto<CouponDto>();
			try
			{
				Coupon obj = _mapper.Map<Coupon>(coupon);
				_db.Coupons.Add(obj);
				_db.SaveChanges();
				response.Result = _mapper.Map<CouponDto>(obj);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[HttpPut]
		public ResponseDto<CouponDto> Put([FromBody] CouponDto coupon)
		{
			var response = new ResponseDto<CouponDto>();
			try
			{
				Coupon obj = _mapper.Map<Coupon>(coupon);
				_db.Coupons.Update(obj);
				_db.SaveChanges();
				response.Result = _mapper.Map<CouponDto>(obj);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[HttpDelete]
		public ResponseDto<CouponDto> Delete(int id)
		{
			var response = new ResponseDto<CouponDto>();
			try
			{
				Coupon obj = _db.Coupons.Find(id);
				_db.Coupons.Remove(obj);
				_db.SaveChanges();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}
	}
}
