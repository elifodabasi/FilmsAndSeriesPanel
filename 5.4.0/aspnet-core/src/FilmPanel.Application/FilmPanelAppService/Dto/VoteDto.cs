using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FilmPanel.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmPanel.FilmPanelAppService.Dto
{
    [AutoMapFrom(typeof(Vote))]
    public class VoteDto : FullAuditedEntityDto<long>
    {
        [Required]
        public long FilmAndSeriesId { get; set; }

        public long Point { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [Required]
        public bool IsVoting { get; set; }

        public FilmAndSeriesDtocs FilmAndSeries { get; set; }
    }
}
