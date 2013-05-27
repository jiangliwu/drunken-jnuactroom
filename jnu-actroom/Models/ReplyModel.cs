using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace jnu_actroom.Models
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public int PoserId { get; set; }
      
        public int UserId { get; set; }

        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
    }

     public class ReplyDBContext : DbContext
     {
         public ReplyDBContext() 
         {

         }
         public DbSet<ReplyModel> Replys { get; set; }
     }
}