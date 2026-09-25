using System.ComponentModel.DataAnnotations;

namespace LapTrinhWeb_2001240388.ViewModels
{
    public class ProductViewModel
    {
        public int ProId { get; set; }

        [Required(ErrorMessage = "Nhap Ten SP")]
        public string ProName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nhap gia SP")]
        public decimal Price { get; set; }

        public decimal? Discount { get; set; } = 0;

        public string? ExistingImg { get; set; }

        public IFormFile? ImageFile { get; set; }

        public int? CatId { get; set; }
    }
}
