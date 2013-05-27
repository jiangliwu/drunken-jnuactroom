using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jnu_actroom.Models
{
    public class PosterModel
    {
        public int Id { get; set; }



        [Required]
        [StringLength(100, ErrorMessage = "标题的长度 {0} 最小需要 {2} 字符长度.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "主题标题")]
        public string title {get;set;}
        public int UserId { get; set; }
        public int CatalogId { get; set; }
        public DateTime PostTime { get; set; }
        public DateTime ModifyTime { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "主题内容")]
        public string Text { get; set; }

    }

    public class PosterDBContext : DbContext
    {
        public PosterDBContext() {}
        public DbSet<PosterModel> Posters {get;set;}
    }
}