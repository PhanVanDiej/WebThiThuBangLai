using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebThiThuBangLaiOnline.Models.Entity
{
    [Table("tb_User")]
    public class User
    {
        [Key]
        [Required(ErrorMessage ="ID người dùng không được để trống")]
        public string ID { get; set; }
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email người dùng không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ngày sinh người dùng không được để trống")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập người dùng không được để trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu người dùng không được để trống")]
        public string Password { get; set; }
        public string Alias { get; set; }
    }
}