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
        public IActionResult GetAnnouncements()
        {
            List<Announcement> Announcements = _announcementCollectionService.GetAll();
            return Ok(Announcements);
        }

        /// <summary>
        /// Get Announcement by id.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetAnnouncementById(Guid id)
        {
            var announcement = _announcementCollectionService.Get(id);
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
        public IActionResult CreateAnnouncement([FromBody] AnnouncementWithoudId announcement)
        {
            if (_announcementCollectionService.Create(announcement))
            {
                return Ok("Announcement has been created!");
            }
            return BadRequest();
        }

        /// <summary>
        /// Update Announcement.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateAnnouncement(Guid id, [FromBody] AnnouncementWithoudId updatedAnnouncement)
        {
            if(_announcementCollectionService.Update(id, updatedAnnouncement))
            {
                return Ok("Announcement has been updated!");
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Announcement.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteAnnouncement(Guid id)
        {
            if (_announcementCollectionService.Delete(id))
            {
                return Ok("Announcement has been deleted!");
            }
            return NotFound();
        }

        /// <summary>
        /// Get announcements by category id.
        /// </summary>
        [HttpGet("category/{id}")]
        public IActionResult GetAnnouncementsByCategoryId(string id)
        {
            var announcements = _announcementCollectionService.GetAnnouncementsByCategoryId(id);
            if(announcements.Count != 0) { 
                return Ok(announcements);
            }
            return NotFound();
        }
    }
}
