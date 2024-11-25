using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebThiThuBangLaiOnline.Models.Entity
{
    [Table("tb_QuestionImage")]
    public class QuestionImage
    {
        [Key]
        public string ID { get; set; }
        public string QuestionID { get; set; }
        public string Image {  get; set; }
    }
}