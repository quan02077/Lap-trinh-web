using System.ComponentModel.DataAnnotations;

namespace  shopweb3.Models
{
    public class Category{
        public int CatId{get;set;}

        [Required(ErrorMessage="Ten danh muc khong duoc de trong")]
        [StringLength(100)]
        public String CatName{get; set;}="";//string.Empty;
    }    
    // public class Category
    // {
    //     public int CatId { get; set; }

    //     [Required(ErrorMessage = "Tên danh mục không được để trống")]
    //     [StringLength(100)]
    //     public string CatName { get; set; } = string.Empty;
    // }
}