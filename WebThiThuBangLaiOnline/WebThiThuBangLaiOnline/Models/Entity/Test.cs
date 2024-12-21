using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebThiThuBangLaiOnline.Models.Entity;

namespace WebThiThuBangLaiOnline.Models.Entity
{
    [Table("tb_Test")]
    public class Test
    {
        public Test() 
        {
            this.Questions = new HashSet<Question>();
        }
        [Key]
        [Required(ErrorMessage = "ID bộ câu hỏi không được để trống")]
        public string TestID { get; set; }
        [Required(ErrorMessage = "Tên bộ câu hỏi không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn thể loại cho bộ câu hỏi")]
        public string Type { get; set; }
        public int NumOfQuestion { get; set; }
        public string Alias { get; set; }
        public ICollection<Question> Questions { get; set; } // 1 Bo de gom nhieu cau hoi
    }
}