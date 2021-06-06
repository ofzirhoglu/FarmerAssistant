using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleTypesController : ControllerBase
    {
        private ISaleTypeService _saleTypeService;

        public SaleTypesController(ISaleTypeService saleTypeService)
        {
            _saleTypeService = saleTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _saleTypeService.GetAll();
            return result.Success
                ? Ok(result)
                : BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _saleTypeService.GetById(id);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(SaleType saleType)
        {
            var result = _saleTypeService.Add(saleType);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(SaleType saleType)
        {
            var result = _saleTypeService.Update(saleType);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(SaleType saleType)
        {
            var result = _saleTypeService.Delete(saleType);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}