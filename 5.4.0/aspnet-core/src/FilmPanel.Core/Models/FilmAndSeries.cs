using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FilmPanel.Models
{
    [Table("AbpFilmAndSeries")]
  public  class FilmAndSeries : FullAuditedEntity<long>
    {
        [Column("Title")]
        [MaxLength(256)]
        
        public string Title { get; set; }

        [Column("Description")]
        [MaxLength(256)]

        public string Description { get; set; }

        [Column("ProgramType")]
        [MaxLength(256)]

        public string ProgramType { get; set; }


        [Column("Url")]
        [MaxLength(256)]

        public string Url { get; set; }


        [Column("ReleaseYear")]
        

        public int? ReleaseYear { get; set; }

    }
}
