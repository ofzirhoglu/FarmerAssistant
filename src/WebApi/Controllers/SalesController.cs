using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _saleService.GetAll();
            return result.Success
                ? Ok(result)
                : BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _saleService.GetById(id);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("getallbysaletypeid")]
        public IActionResult GetAllBySaleTypeId(int saleTypeId)
        {
            var result = _saleService.GetAllBySaleTypeId(saleTypeId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Sale sale)
        {
            var result = _saleService.Add(sale);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Sale sale)
        {
            var result = _saleService.Update(sale);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Sale sale)
        {
            var result = _saleService.Delete(sale);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}