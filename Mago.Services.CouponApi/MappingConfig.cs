using AutoMapper;
using Mago.Services.CouponApi.Models;
using Mago.Services.CouponApi.Models.Dto;

namespace Mago.Services.CouponApi
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<Coupon,CouponDto>();
				config.CreateMap<CouponDto, Coupon>();
			});

			return mappingConfig;
		}
	}
}
