namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSach")]
    public partial class DanhSach
    {
        public int ID { get; set; }

        
        [Required(ErrorMessage = "ten khong duoc de trong")]
        [StringLength(300, ErrorMessage = "ten khong duoc qua 30 ki tu")]
        [Display(Name = "ten")]
        public string Author { get; set; }

        [Required(ErrorMessage = "tieu de khong duoc de trong")]
        [StringLength(100, ErrorMessage = "tieu de khong duoc qua 100 ki tu")]
        [Display(Name = "tieu de")]
        public string Title { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "khong duoc de trong")]
        public string Description { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "khong duoc de trong")]
        public string Image { get; set; }
        [Required(ErrorMessage = "khong duoc de trong")]
        [Range(1000, 1000000, ErrorMessage = "gia tu 1000 - 1000000")]
        [Display(Name = "gia")]
        public float? Price { get; set; }
    }
}
