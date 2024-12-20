﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebThiThuBangLai.Models.Entities
{
    [Table("tb_User")]
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}