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
        [Required(ErrorMessage ="ID Menu không được để trống!")]
        public int ID { get; set; }     
        [StringLength(500)]
        [Required(ErrorMessage = "Tiêu đề Menu không được để trống!")]      
        public string Title { get; set; }

        [Required(ErrorMessage = "Thứ tự Menu không được để trống!")]           
        public int Position { get; set; }
        public string Alias { get; set; }
    }
}