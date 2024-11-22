using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebThiThuBangLai.Models.Entities
{
    [Table("tb_Menu")]
    public class Menu
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
    }
}