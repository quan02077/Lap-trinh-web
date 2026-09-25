using System.ComponentModel.DataAnnotations;

namespace LapTrinhWeb_2001240388.Models.Buoi6
{
    public class Category
    {
        public int CatId { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100)]
        public string CatName { get; set; }
    }
}
