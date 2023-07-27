using AnnouncementPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : ControllerBase
    {

        static List<Announcement> _announcements = new List<Announcement> {
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "First Announcement", Description = "First Announcement Description" , Author = "Author_1"},
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Second Announcement", Description = "Second Announcement Description", Author = "Author_1" },
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Third Announcement", Description = "Third Announcement Description", Author = "Author_2"  },
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fourth Announcement", Description = "Fourth Announcement Description", Author = "Author_3"  },
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fifth Announcement", Description = "Fifth Announcement Description", Author = "Author_4"  }
        };

        /// <summary>
        /// Get Announcements.
        /// </summary>
        [HttpGet]
        public IActionResult GetAnnouncements()
        {
            return Ok(_announcements);
        }

        /// <summary>
        /// Create Announcement.
        /// </summary>
        [HttpPost]
        public IActionResult CreateAnnouncement([FromBody] AnnouncementWithoudId announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement cannot be null");
            }

            Announcement newAnnouncement = new()
            {
                Id = Guid.NewGuid(),
                CategoryId = announcement.CategoryId,
                Title = announcement.Title,
                Description = announcement.Description,
                Author = announcement.Author,
            };

            _announcements.Add(newAnnouncement);
            return Ok(newAnnouncement);
        }

        /// <summary>
        /// Update Announcement.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateAnnouncement(Guid id, [FromBody] AnnouncementWithoudId updatedAnnouncement)
        {
            if (updatedAnnouncement == null)
            {
                return BadRequest("Invalid announcement data.");
            }

            var announcementIndex = _announcements.FindIndex(a => a.Id == id);
            if (announcementIndex == -1)
            {
                return NotFound();
            }

            Announcement updatedAnnouncementWithId = new()
            {
                Id = id,
                CategoryId = updatedAnnouncement.CategoryId,
                Title = updatedAnnouncement.Title,
                Description = updatedAnnouncement.Description,
                Author = updatedAnnouncement.Author,
            };

            _announcements[announcementIndex] = updatedAnnouncementWithId;

            string message = $"Announcement with ID {id} updated successfully!";
            return Ok(message);
        }

        /// <summary>
        /// Delete Announcement.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteAnnouncement(Guid id)
        {
            var existingAnnouncement = _announcements.FirstOrDefault(a => a.Id == id);
            if (existingAnnouncement == null)
            {
                return NotFound();
            }
            else
            {
                _announcements.Remove(existingAnnouncement);
            }

            string message = $"Announcement with ID {id} deleted successfully!";
            return Ok(message);
        }

        /// <summary>
        /// Partially Update Announcement(title and description).
        /// </summary>
        [HttpPatch("{id}")]
        public IActionResult UpdateTitleAndDescription(Guid id,
            [FromBody] AnnouncementUpdateModel updateModel)
        {
            var announcementIndex = _announcements.FindIndex(a => a.Id == id);
            if (announcementIndex == -1)
            {
                return NotFound();
            }

            _announcements[announcementIndex].Title = updateModel.Title;
            _announcements[announcementIndex].Description = updateModel.Description;
            return Ok("Announcement updated!");
        }
    }
}
