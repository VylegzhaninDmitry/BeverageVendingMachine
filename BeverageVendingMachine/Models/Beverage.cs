using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeverageVendingMachine
{
    public class Beverage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public int BeverageCount { get; set; }

        [Required]
        public byte[] Image { get; set; } = Array.Empty<byte>();
    }
}
