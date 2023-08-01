using AnnouncementPlatformAPI.Models;

namespace AnnouncementPlatformAPI.Services
{
    public interface IAnnouncementCollectionService : ICollectionService<Announcement, AnnouncementWithoudId>
    {
        Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);
    }
}
