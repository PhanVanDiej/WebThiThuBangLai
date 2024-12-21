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
        [Required(ErrorMessage = "ID câu hỏi không được để trống")]
        public string ID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Trường này không được để trống")]

        public string TestID { get; set; }
        [ForeignKey("TestID")]
        public virtual Test Test { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [StringLength(1000)]
        public string DetailQuestion { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [StringLength(2000)]
        public string OptionA { get; set; }
        [Required(ErrorMessage = "Trường này được để trống")]
        [StringLength(500)]
        public string OptionB { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [StringLength(500)]
        public string OptionC { get; set; }
        
        [Required(ErrorMessage = "Đáp án câu hỏi không được để trống")]
        [StringLength(500)]
        public string Answer { get; set; }
        public int Type { get; set; }
        [Required(ErrorMessage = "Trường này câu hỏi không được để trống")]
        [StringLength(1000)]
        public string Explain { get; set; }
        public string Image { get; set; }
        public string Alias { get; set; }
    }
}