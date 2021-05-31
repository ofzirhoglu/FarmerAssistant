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

        ///<summary>
        /// Get field list
        ///</summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fieldService.GetAll();

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        ///<summary>
        /// Get field by id
        ///</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getbyId")]
        public IActionResult GetById(int id)
        {
            var result = _fieldService.GetById(id);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// Add field
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Field
        ///     {
        ///        "fieldName":"Field Name"
        ///        "fieldDesc": "Field Description",
        ///        "fieldM2": 100
        ///     }
        ///
        /// </remarks>
        /// <param name="field"></param>
        /// <returns>A newly created field</returns>
        /// <response code="201">Returns the newly created field</response>
        /// <response code="400">If the field is null</response> 
        [HttpPost("add")]
        public IActionResult Add(Field field)
        {
            var result = _fieldService.Add(field);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        ///<summary>
        /// Update the field
        ///</summary>
        /// <param name="field"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update(Field field)
        {
            var result = _fieldService.Update(field);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        ///<summary>
        /// Delete the field
        ///</summary>
        /// <param name="field"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(Field field)
        {
            var result = _fieldService.Delete(field);

            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}