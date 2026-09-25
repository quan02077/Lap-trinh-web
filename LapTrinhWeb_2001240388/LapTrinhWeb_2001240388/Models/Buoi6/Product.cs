namespace LapTrinhWeb_2001240388.Models.Buoi6
{
    public class Product
    {
        public int ProId { get; set; }
        public string ProName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Img { get; set; }
        public int? CatId { get; set; }

        public string? CatName { get; set; }
    }
}
