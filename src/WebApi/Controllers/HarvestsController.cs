using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestsController : ControllerBase
    {
        private IHarvestService _harvestService;

        public HarvestsController(IHarvestService harvestService)
        {
            _harvestService = harvestService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _harvestService.GetAll();
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _harvestService.GetById(id);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("getallbyharvesttypeid")]
        public IActionResult GetAllByHarvestTypeId(int harvestTypeId)
        {
            var result = _harvestService.GetAllByHarvestTypeId(harvestTypeId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Harvest harvest)
        {
            var result = _harvestService.Add(harvest);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Harvest harvest)
        {
            var result = _harvestService.Update(harvest);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Harvest harvest)
        {
            var result = _harvestService.Delete(harvest);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}