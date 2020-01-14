using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Api
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(60)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [StringLength(128)]
        public string OpenId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AddTime { get; set; } = DateTime.Now;

    }
}
