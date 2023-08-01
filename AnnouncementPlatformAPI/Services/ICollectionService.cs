namespace AnnouncementPlatformAPI.Services
{
    public interface ICollectionService<T1, T2>
    {
        List<T1> GetAll();

        T1 Get(Guid id);

        bool Create(T2 model);

        bool Update(Guid id, T2 model);

        bool Delete(Guid id);

    }
}
