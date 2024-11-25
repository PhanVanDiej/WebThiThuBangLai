using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebThiThuBangLaiOnline.Models.Entity;

namespace WebThiThuBangLaiOnline.Models.Entity
{
    [Table("tb_Question")]
    public class Question
    {
        [Key]
        public string ID { get; set; }
        public string TestID { get; set; }

        [ForeignKey("TestID")]

        public virtual Test Test { get; set; }
        [StringLength(1000)]
        public string DetailQuestion { get; set; }
        [StringLength(500)]
        public string OptionA { get; set; }
        [StringLength(500)]
        public string OptionB { get; set; }
        [StringLength(500)]
        public string OptionC { get; set; }
        [StringLength(500)]
        public string OptionD { get; set; }
        [StringLength(500)]
        public string Answer { get; set; }
        public int Type { get; set; }
        [StringLength(1000)]
        public string Explain { get; set; }
        public string Image { get; set; }
    }
}