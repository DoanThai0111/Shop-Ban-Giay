using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassShop.Models
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Tên sản phẩm ko được để rỗng !")]
        [StringLength(255)]
        public string Name { get; set; }

        public string Slug { get; set; }

        public int? ParentId { get; set; }
        public int? Orders { get; set; }

        [Required(ErrorMessage = "Từ khóa ko được để rỗng !")]
        public int? MetaDesc { get; set; }
        public int? MetaKey { get; set; }
        [Required(ErrorMessage = "Mô tả ko được để rỗng !")]
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int? Status { get; set; }

    }
}
