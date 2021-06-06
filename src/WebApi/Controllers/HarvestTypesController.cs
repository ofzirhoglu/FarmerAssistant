using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestTypesController : ControllerBase
    {
        private IHarvestTypeService _harvestTypeService;

        public HarvestTypesController(IHarvestTypeService harvestTypeService)
        {
            _harvestTypeService = harvestTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _harvestTypeService.GetAll();
            return result.Success
                ? Ok(result)
                : BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _harvestTypeService.GetById(id);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(HarvestType harvestType)
        {
            var result = _harvestTypeService.Add(harvestType);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(HarvestType harvestType)
        {
            var result = _harvestTypeService.Update(harvestType);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(HarvestType harvestType)
        {
            var result = _harvestTypeService.Delete(harvestType);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}