using Moq;

namespace AnnouncementPlatformAPIUnitTests
{
    public class UnitTest1
    {
        private readonly Mock<IAnnouncementCollectionService> announcementService;

        public UnitTest1(Mock<IAnnouncementCollectionService> announcementService)
        {
            this.announcementService = announcementService;
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(4, Add(2, 2));
        }
    }
}