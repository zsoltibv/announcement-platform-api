using AnnouncementPlatformAPI.Models;
using AnnouncementPlatformAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }

        /// <summary>
        /// Get Announcements.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> Announcements = await _announcementCollectionService.GetAll();
            return Ok(Announcements);
        }

        /// <summary>
        /// Get Announcement by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById(Guid id)
        {
            var announcement = await _announcementCollectionService.Get(id);
            if(announcement == null)
            {
                return NotFound();
            }
            return Ok(announcement);
        }

        /// <summary>
        /// Create a new announcement.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] AnnouncementWithoudId announcement)
        {
            if (await _announcementCollectionService.Create(announcement))
            {
                return Ok("Announcement has been created!");
            }
            return BadRequest();
        }

        /// <summary>
        /// Update Announcement.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncement(Guid id, [FromBody] AnnouncementWithoudId updatedAnnouncement)
        {
            if(await _announcementCollectionService.Update(id, updatedAnnouncement))
            {
                return Ok("Announcement has been updated!");
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Announcement.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid id)
        {
            if (await _announcementCollectionService.Delete(id))
            {
                return Ok("Announcement has been deleted!");
            }
            return NotFound();
        }

        /// <summary>
        /// Get announcements by category id.
        /// </summary>
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAnnouncementsByCategoryId(string id)
        {
            var announcements = await _announcementCollectionService.GetAnnouncementsByCategoryId(id);
            if(announcements.Count != 0) { 
                return Ok(announcements);
            }
            return NotFound();
        }
    }
}
