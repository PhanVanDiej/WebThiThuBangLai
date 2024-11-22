using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebThiThuBangLai.Models.Entities
{
    [Table("tb_QuestionImage")]
    public class QuestionImage
    {
        public string ID { get; set; }
        public string QuestionID { get; set; }
        public string Image {  get; set; }
    }
}