﻿using Services.Basket.Dtos;
using Shared.Dtos;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not delete",500);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if(string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket Not Found",404);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket),200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId,JsonSerializer.Serialize(basketDto));

            if(!status)
            {
                return Response<bool>.Fail("Basket could not update or save",500);
            }

            return Response<bool>.Success(204);

            //return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save", 500);
        }   
    }
}
