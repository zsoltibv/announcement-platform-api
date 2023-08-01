using AnnouncementPlatformAPI.Models;

namespace AnnouncementPlatformAPI.Services
{
    public interface IAnnouncementCollectionService : ICollectionService<Announcement, AnnouncementWithoudId>
    {
        List<Announcement> GetAnnouncementsByCategoryId(string categoryId);
    }
}
