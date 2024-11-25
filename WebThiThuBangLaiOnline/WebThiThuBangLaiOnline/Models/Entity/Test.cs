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
        public string TestID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumOfQuestion { get; set; }
        public ICollection<Question> Questions { get; set; } // 1 Bo de gom nhieu cau hoi
    }
}