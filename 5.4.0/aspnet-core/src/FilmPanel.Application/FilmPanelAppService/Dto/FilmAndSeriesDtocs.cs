using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FilmPanel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FilmPanel.FilmPanelAppService.Dto
{
    [AutoMapFrom (typeof(FilmAndSeries))]
   public class FilmAndSeriesDtocs : FullAuditedEntityDto<long>
    {

        [MaxLength(256)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string ProgramType { get; set; }


        [MaxLength(256)]
        public string Url { get; set; }


        public int? ReleaseYear { get; set; }
    }
}
