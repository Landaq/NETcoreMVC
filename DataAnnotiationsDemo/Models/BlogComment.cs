using System.ComponentModel.DataAnnotations;

namespace DataAnnotiationsDemo.Models
{
    public class BlogComment
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [OffensiveWordBlacklist(DisallowedWords = new string[] {"offensive1", "offensive2", "offensive3"})]
        public string CommentText { get; set; }
    }
}
