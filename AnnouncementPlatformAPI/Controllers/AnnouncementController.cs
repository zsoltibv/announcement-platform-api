using Microsoft.AspNetCore.Mvc;

namespace AnnouncementPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : ControllerBase
    {
        /// <summary>
        /// Get Message.
        /// </summary>
        [HttpGet]
        public IActionResult GetMessage()
        {
            string message = "Hello, this is a sample message!";
            return Ok(message);
        }

        /// <summary>
        /// Create Message.
        /// </summary>
        [HttpPost]
        public IActionResult CreateItem()
        {
            string message = "Item created successfully!";
            return Ok(message);
        }

        /// <summary>
        /// Update Message.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id)
        {
            string message = $"Item with ID {id} updated successfully!";
            return Ok(message);
        }

        /// <summary>
        /// Delete Message.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            string message = $"Item with ID {id} deleted successfully!";
            return Ok(message);
        }
    }
}
