using System.ComponentModel.DataAnnotations;

namespace GameApp.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a positive number.")]
        public int StockQuantity { get; set; }
    }
}