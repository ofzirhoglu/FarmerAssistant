using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldsController : ControllerBase
    {
        private IFieldService _fieldService;

        public FieldsController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fieldService.GetAll();

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("getbyId")]
        public IActionResult GetById(int id)
        {
            var result = _fieldService.GetById(id);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Field field)
        {
            var result = _fieldService.Add(field);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Field field)
        {
            var result = _fieldService.Update(field);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Field field)
        {
            var result = _fieldService.Delete(field);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}