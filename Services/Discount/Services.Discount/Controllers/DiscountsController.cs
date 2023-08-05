using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Discount.Services;
using Shared.ControllerBases;
using Shared.Services;
using System.Threading.Tasks;

namespace Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountsController(ISharedIdentityService sharedIdentityService, IDiscountService discountService)
        {
            _sharedIdentityService = sharedIdentityService;
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _discountService.GetAll();
            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var discount = await _discountService.GetById(id);
            return CreateActionResultInstance(discount);
        }

        [HttpGet("/api/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _sharedIdentityService.GetUserId;

            var discount = await _discountService.GetByCodeAndUserId(code,userId);
            return CreateActionResultInstance(discount);
        }
        [HttpPost, Route("/api/[controller]/[action]")]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            var response = await _discountService.Save(discount);
            return CreateActionResultInstance(response);
        }


        [HttpPost,Route("/api/[controller]/[action]")]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
             var response = await _discountService.Update(discount);
            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _discountService.Delete(id);
            return CreateActionResultInstance(response);
        }   
    }
}
