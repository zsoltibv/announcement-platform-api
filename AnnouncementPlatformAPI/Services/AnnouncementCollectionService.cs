using AnnouncementPlatformAPI.Models;
using AnnouncementPlatformAPI.Settings;
using MongoDB.Driver;

namespace AnnouncementPlatformAPI.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        private readonly IMongoCollection<Announcement> _announcements;

        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }

        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(announcement => true) ;
            return result.ToList();
        }

        public async Task<Announcement> Get(Guid id)
        {
            return (await _announcements.FindAsync(announcement => announcement.Id == id))
                .FirstOrDefault();
        }

        public async Task<bool> Create(AnnouncementWithoudId model)
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

            await _announcements.InsertOneAsync(newAnnouncement);
            return true;
        }

        public async Task<bool> Update(Guid id, AnnouncementWithoudId model)
        {
            if (model == null)
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

            var result = await _announcements.ReplaceOneAsync(announcement => announcement.Id == id, updatedAnnouncementWithId);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _announcements.InsertOneAsync(updatedAnnouncementWithId);
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _announcements.DeleteOneAsync(announcement => announcement.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId)
        {
            return (await _announcements.FindAsync(announcement => announcement.CategoryId == categoryId))
                .ToList();
        }
    }
}
