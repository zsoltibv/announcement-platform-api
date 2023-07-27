using System.ComponentModel.DataAnnotations;

namespace AnnouncementPlatformAPI.Models
{
    public class Announcement
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Author name can only contain letters and spaces.")]
        public string Author { get; set; }
    }
}
