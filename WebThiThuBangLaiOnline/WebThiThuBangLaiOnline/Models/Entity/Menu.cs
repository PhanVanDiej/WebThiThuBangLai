using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebThiThuBangLaiOnline.Models.Entity
{
    [Table("tb_Menu")]
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        public int Position { get; set; }
    }
}