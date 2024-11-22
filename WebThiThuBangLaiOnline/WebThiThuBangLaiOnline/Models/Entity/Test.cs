using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebThiThuBangLai.Models.Entities
{
    [Table("tb_Test")]
    public class Test
    {
        public Test() 
        {
            this.Questions = new HashSet<Question>();
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumOfQuestion { get; set; }
        public ICollection<Question> Questions { get; set; } // 1 Bo de gom nhieu cau hoi
    }
}