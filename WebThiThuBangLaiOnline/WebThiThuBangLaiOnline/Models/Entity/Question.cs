using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebThiThuBangLai.Models.Entities
{
    [Table("tb_Question")]
    public class Question
    {
        public string ID { get; set; }
        public string TestID { get; set; }
        public string DetailQuestion { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer { get; set; }
        public int Type { get; set; }
        public string Explain { get; set; }
        public string Image { get; set; }
        public virtual Test Test { get; set; }
    }
}