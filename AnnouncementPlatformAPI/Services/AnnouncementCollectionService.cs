using AnnouncementPlatformAPI.Models;

namespace AnnouncementPlatformAPI.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        List<Announcement> _announcements = new List<Announcement> {
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "First Announcement", Description = "First Announcement Description" , Author = "Author_1"},
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Second Announcement", Description = "Second Announcement Description", Author = "Author_1" },
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Third Announcement", Description = "Third Announcement Description", Author = "Author_2"  },
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fourth Announcement", Description = "Fourth Announcement Description", Author = "Author_3"  },
            new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fifth Announcement", Description = "Fifth Announcement Description", Author = "Author_4"  }
        };

        public List<Announcement> GetAll()
        {
            return _announcements;
        }

        public Announcement Get(Guid id)
        {
            var announcementFound = _announcements.FirstOrDefault(a => a.Id == id);
            if(announcementFound != null)
            {
                return announcementFound;
            }
            return new Announcement();
        }

        public bool Create(AnnouncementWithoudId model)
        {
            if (model == null)
            {
                return false;
            }

            Announcement newAnnouncement = new()
            {
                Id = Guid.NewGuid(),
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
            };

            _announcements.Add(newAnnouncement);
            return true;
        }

        public bool Update(Guid id, AnnouncementWithoudId model)
        {
            if (model == null)
            {
                return false;
            }

            var announcementIndex = _announcements.FindIndex(a => a.Id == id);
            if (announcementIndex == -1)
            {
                return false;
            }

            Announcement updatedAnnouncementWithId = new()
            {
                Id = id,
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
            };

            _announcements[announcementIndex] = updatedAnnouncementWithId;

            return true;
        }

        public bool Delete(Guid id)
        {
            var existingAnnouncement = _announcements.FirstOrDefault(a => a.Id == id);
            if (existingAnnouncement == null)
            {
                return false;
            }
            else
            {
                _announcements.Remove(existingAnnouncement);
            }
            return true;
        }

        public List<Announcement> GetAnnouncementsByCategoryId(string categoryId)
        {
            var filteredAnnouncements = _announcements.Where(a => a.CategoryId == categoryId).ToList();
            return filteredAnnouncements;
        }
    }
}
