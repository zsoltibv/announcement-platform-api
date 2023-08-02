using Moq;
using AnnouncementPlatformAPI.Services;
using AnnouncementPlatformAPI.Models;
using AnnouncementPlatformAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementPlatformAPIUnitTests
{
    public class UnitTest1
    {
        private readonly Mock<IAnnouncementCollectionService> announcementService;
        private readonly AnnouncementController announcementController;

        public UnitTest1() { 
            this.announcementService = new Mock<IAnnouncementCollectionService>(); 
            this.announcementController = new AnnouncementController(this.announcementService.Object);
        }

        [Fact]
        public async Task UnitTestGet()
        {
            var sampleAnnouncements = new List<Announcement>
            {
                new Announcement { Id = Guid.NewGuid(), Title = "Announcement 1" },
                new Announcement { Id = Guid.NewGuid(), Title = "Announcement 2" },
            };

            announcementService.Setup(service => service.GetAll()).ReturnsAsync(sampleAnnouncements);

            var result = await this.announcementController.GetAnnouncements();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IActionResult>(result);
            var list = (result as OkObjectResult)?.Value as List<Announcement>;
            Assert.NotNull(list);
            Assert.Equal(list.Count, 2);
        }

        [Fact]
        public async Task UnitTestPost()
        {
            announcementService.Setup(service => service.GetAll()).ReturnsAsync(sampleAnnouncements);

            var result = await this.announcementController.GetAnnouncements();

        }
    }
}