using System.ComponentModel.DataAnnotations;

namespace FilmPanel.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}