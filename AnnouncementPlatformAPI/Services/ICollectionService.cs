namespace AnnouncementPlatformAPI.Services
{
    public interface ICollectionService<T1, T2>
    {
        Task<List<T1>> GetAll();

        Task<T1> Get(Guid id);

        Task<bool> Create(T2 model);

        Task<bool> Update(Guid id, T2 model);

        Task<bool> Delete(Guid id);
    }
}
