using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmPanel.Models
{
    [Table("AbpVote")]
    public class Vote : FullAuditedEntity<long>
    {
        [Column("FilmAndSeriesId")]
        [Required]
        public long FilmAndSeriesId { get; set; }

        [Column("Point")]
        public long Point { get; set; }

        [Column("Description")]
        [MaxLength(256)]
        public string Description { get; set; }

        [Column("IsVoting")]
        [Required]
        public bool IsVoting { get; set; }

        [ForeignKey("FilmAndSeriesId")]
        public FilmAndSeries FilmAndSeries { get; set; }
    }
}
