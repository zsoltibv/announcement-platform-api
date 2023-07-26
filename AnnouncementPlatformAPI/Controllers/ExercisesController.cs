using AnnouncementPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        public static List<string> list = new List<string>{ "mere", "pere", "afine" };

        [HttpGet("byname/{name}")]
        public IActionResult GetCategoryByName(string name)
        {
            var category = CategoriesController.categories.FirstOrDefault
                (c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (category != null)
                return Ok(category);

            return NotFound();
        }

        [HttpGet("interpolation/{queryParam1}/{queryParam2}")]
        public IActionResult StringInterpolation(string queryParam1, string queryParam2)
        {
            string message = String.Format("param1: {0}, param2: {1}", queryParam1, queryParam2);

            if (message != null)
                return Ok(message);

            return NotFound();
        }

        [HttpGet("sum")]
        public IActionResult GetSumOfNumbers([FromQuery] List<double> numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                return BadRequest("The list of numbers is null or empty.");
            }

            double sum = numbers.Sum();
            return Ok(sum);
        }

        [HttpGet]
        public IActionResult GetListOfStrings()
        {
            if(list!=null)
                return Ok(list);
            return BadRequest("List Not Found");
        }

        [HttpPut("{index}")]
        public IActionResult UpdateListValue(int index, [FromBody] string newValue)
        {
            if (index < 0 || index >= list.Count)
            {
                return BadRequest("Invalid index. The index is out of bounds.");
            }

            if (string.IsNullOrEmpty(newValue))
            {
                return BadRequest("Invalid value. The new value cannot be null or empty.");
            }

            list[index] = newValue;

            return Ok(list);
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteListElementByName(string name)
        {
            var listElement = list.FirstOrDefault(c => c == name);
            if (listElement != null)
            {
                list.Remove(listElement);
                return Ok(listElement);
            }
            return NotFound();
        }
    }
}
